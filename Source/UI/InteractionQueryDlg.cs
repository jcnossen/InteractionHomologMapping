/*
 Copyright (c) 2010 Jelmer Cnossen

 Permission is hereby granted, free of charge, to any person obtaining a copy
 of this software and associated documentation files (the "Software"), to deal
 in the Software without restriction, including without limitation the rights
 to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 copies of the Software, and to permit persons to whom the Software is
 furnished to do so, subject to the following conditions:

 The above copyright notice and this permission notice shall be included in
 all copies or substantial portions of the Software.

 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 THE SOFTWARE.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Globalization;

namespace InteractionMapping
{
	public partial class InteractionQueryDlg : Form
	{
		InteractionSet set;
		Dictionary<Protein, TreeNode> treeNodes = new Dictionary<Protein, TreeNode>();

		static StringDatabaseSearch.dbSpecies[] speciesList;

		public StringDatabaseSearch.dbSpecies[] SpeciesList
		{
			get {
				if (speciesList == null) 
					using (var sds = new StringDatabaseSearch())
						speciesList = sds.LoadSpecies();
				return speciesList;
			}
		}

		public float MinInteractionScore
		{
			get { return float.Parse(textMinIntAct.Text, CultureInfo.InvariantCulture); }
		}

		public InteractionQueryDlg(InteractionSet set)
		{
			InitializeComponent();

			this.set = set;
			using (var strdb = new StringDatabaseSearch()) {
				foreach (Protein prot in set.proteins.Values)
					if (prot.stringID == 0) {
						strdb.UpdateProtein(prot);
						treeView.Nodes.Add(CreateProteinNode(prot));
					}
			}

			comboSpecies.Items.AddRange(SpeciesList);
			comboSpecies.SelectedIndex = Array.IndexOf(SpeciesList, 
				SpeciesList.FirstOrDefault(s => s.speciesId == 83333));

			treeView.ExpandAll();
			UpdateGraph();
		}

		void SetInProgress(bool state)
		{
			labelInProgress.Visible = state;
			buttonFindHomologs.Enabled = !state;
			buttonLocalExtend.Enabled = !state;
			buttonNativeExtend.Enabled = !state;
		}

		void BeginQuery()
		{
			Invoke(new Action(delegate {
				SetInProgress(true);
			}));
		}

		void EndQuery()
		{
			Invoke(new Action(delegate { 
				UpdateGraph();
				SetInProgress(false);
			}));
		}

		class GraphEdge
		{
			public Protein a,b;
			public string type;
			public float strength;
		}

		public void UpdateGraph()
		{
			if (!checkUseCytoscape.Checked)
				return;

			try {
				using (CytoscapeRPC.cytoscape.CytoscapeService ct = new CytoscapeRPC.cytoscape.CytoscapeService()) {
					ct.Url = textCytoscapeServiceURL.Text;

					List<GraphEdge> edges = new List<GraphEdge>();
					if (checkShowOriginalInteractions.Checked)
						edges.AddRange(GetOriginalInteractions());
					else
						edges.AddRange(GetMappedInteractions());

					HashSet<Protein> nodes = new HashSet<Protein>();

					foreach(GraphEdge ge in edges) {
						if (!nodes.Contains(ge.a))
							nodes.Add(ge.a);
						if (!nodes.Contains(ge.b))
							nodes.Add(ge.b);
					}

					// Also add all the start proteins even if they have no edges
					foreach (Protein p in set.startProteins)
						nodes.Add(p);

					string ctNetworkID = null;

					if (ctNetworkID == null)
						ctNetworkID = ct.createNetwork("STRING Interaction search");

					ct.setCurrentNetwork(ctNetworkID);

					foreach (Protein p in nodes) {
						string nodeID = p.stringExternalID;

						if (ct.nodeExists(ctNetworkID, nodeID))
							continue;

						ct.createNodeInCurrent(p.stringExternalID);
						ct.addStringNodeAttribute("label", nodeID, p.name);

						foreach (var kv in p.attributes)
							ct.addStringNodeAttribute(kv.Key, nodeID, kv.Value);
					}
					ct.setNodeFillColor(ctNetworkID, set.startProteins.Select(p => p.stringExternalID).ToArray(), 0, 0, 255);

					string[] edgeIDs = ct.createEdges(ctNetworkID,
						(from e in edges select e.a.stringExternalID).ToArray(),
						(from e in edges select e.b.stringExternalID).ToArray(),
						Util.RepeatValue(edges.Count, "interaction"),
						Util.RepeatValue(edges.Count, true), true);
					ct.addStringEdgeAttributes("mappingType", edgeIDs, 
						(from e in edges select e.type).ToArray());
					ct.addDoubleEdgeAttributes("strength", edgeIDs,
						(from e in edges select (double)e.strength).ToArray());

					ct.setNodeLabel(ctNetworkID, "label", "?", "default");

					//string[] modifiables = ct.getVisualStyleModifiables();
					//Array.ForEach(modifiables, m => Console.WriteLine(m));
					ct.discreteMapper(ctNetworkID, "default", "mappingType", "Edge Color", "0,0,0",
						new string[] { "MappedInteraction", "MissingHomolog", "NativeInteraction", "LocalInteraction" }, 
						new string[] { "0,255,0", "255,0,0", "100, 100, 100", "150, 150, 150" });

					ct.discreteMapper(ctNetworkID, "default", "missing", "Node Color", "0,255,0",
						new string[] { "yes" },
						new string[] { "255,100,100" });
				}
			}
			catch (WebException e) {
				MessageBox.Show(e.Message);
			}
		}

		private IEnumerable<GraphEdge> GetMappedInteractions()
		{
			var interactionMap = set.InteractionMap();
			var homologMap = set.HomologMap();

			var species = (StringDatabaseSearch.dbSpecies)comboSpecies.SelectedItem;
			int speciesID = species.speciesId;

			List<GraphEdge> edges = new List<GraphEdge>();

			foreach (Protein prot in set.startProteins)
				foreach (Interaction interaction in interactionMap[prot.stringID]) {
					var homologs = homologMap[interaction.b.stringID];

					foreach (Homolog h in homologs) {
						edges.Add(new GraphEdge() {
							a = prot,
							b = h.B,
							strength = interaction.score * h.bitscore,
							type = "MappedInteraction"
						});
					}

					if (set.startProteins.Contains(interaction.b) && prot!=interaction.b) {
						edges.Add(new GraphEdge() {
							a = prot,
							b = interaction.b,
							strength = interaction.score,
							type = "NativeInteraction"
						});
					} else if (checkShowMissing.Checked && homologs.Count==0) {
						var missing = new Protein() {
							name = "Missing: " + interaction.b.name,
							speciesID = speciesID,
							stringID = 0,
							stringExternalID = "missing-" + interaction.b.stringExternalID
						};
						missing.attributes["missing"] = "yes";
						edges.Add(new GraphEdge() {
							a = prot,
							b = missing,
							strength = 0,
							type = "MissingHomolog"
						});
					}
				}
			return edges;
		}

		private IEnumerable<GraphEdge> GetOriginalInteractions()
		{
			return set.interactions.Select(i => new GraphEdge() {
				a = i.a,
				b = i.b,
				strength = i.score,
				type = i.b.fromHomolog ? "LocalInteraction" : "NativeInteraction"
			}).Concat(
				set.homologs.Select(h => new GraphEdge() {
					a = h.a, b = h.b,
					strength = h.bitscore,
					type = "Homolog"
				})
			);
		}

		private void checkUseCytoscape_CheckedChanged(object sender, EventArgs e)
		{
			textCytoscapeServiceURL.Enabled = checkUseCytoscape.Checked;

			UpdateGraph();
		}

		private void buttonNativeExtend_Click(object sender, EventArgs e)
		{
			ThreadPool.QueueUserWorkItem(new WaitCallback(delegate {
				BeginQuery();

				List<Protein> natives = new List<Protein>();

				foreach (Protein p in set.proteins.Values)
					if (!p.fromHomolog)
						natives.Add(p);

				using (StringDatabaseSearch strdb = new StringDatabaseSearch()) {
					strdb.ExtendInteractions(set, natives, MinInteractionScore, TreeUpdateLogCallback);
				}

				EndQuery();
			}));
		}

		private void buttonLocalExtend_Click(object sender, EventArgs e)
		{
			ThreadPool.QueueUserWorkItem(new WaitCallback(delegate {
				BeginQuery();
				List<Protein> locals = new List<Protein>();

				foreach (Protein p in set.proteins.Values)
					if (p.fromHomolog)
						locals.Add(p);

				using (StringDatabaseSearch strdb = new StringDatabaseSearch()) {
					strdb.ExtendInteractions(set, locals, MinInteractionScore, TreeUpdateLogCallback);
				}
				EndQuery();
			}));
		}

		void TreeUpdateLogCallback(Protein org, Protein prot, string msg)
		{
			treeView.Invoke(new Action(delegate {
				if (treeNodes.ContainsKey(prot))
					return;

				if (!treeNodes.ContainsKey(org))
					treeView.Nodes.Add(CreateProteinNode(prot));

				string annotation = null;
				prot.attributes.TryGetValue("annotation", out annotation);
				treeNodes[prot] = treeNodes[org].Nodes.Add(prot.name + (annotation != null ? ": " + annotation : ""));
			}));
		}

		private TreeNode CreateProteinNode(Protein prot)
		{
			treeNodes[prot] = new TreeNode(prot.name);
			treeNodes[prot].Expand();
			return treeNodes[prot];
		}

		private void buttonFindHomologs_Click(object sender, EventArgs e)
		{
			var species = (StringDatabaseSearch.dbSpecies)comboSpecies.SelectedItem;
			int speciesID = species.speciesId;

			ThreadPool.QueueUserWorkItem(new WaitCallback(delegate
			{
				BeginQuery();

				List<Protein> natives = new List<Protein>();
				foreach (Protein p in set.proteins.Values)
					if (!p.fromHomolog)
						natives.Add(p);

				using (StringDatabaseSearch strdb = new StringDatabaseSearch())
				{
					strdb.ExtendBestHomologs(set, natives, speciesID, 0, TreeUpdateLogCallback);
				}

				EndQuery();
			}));
		}

		private void buttonClear_Click(object sender, EventArgs e)
		{

		}

		private void checkShowOriginalInteractions_CheckedChanged(object sender, EventArgs e)
		{
			UpdateGraph();
		}

		private void checkShowMissing_CheckedChanged(object sender, EventArgs e)
		{
			UpdateGraph();
		}

	}
}
