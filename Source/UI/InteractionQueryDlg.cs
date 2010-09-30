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

		public void UpdateGraph()
		{
			if (!checkUseCytoscape.Checked)
				return;

			try {
				var species = (StringDatabaseSearch.dbSpecies)comboSpecies.SelectedItem;

				var exporter = new CytoscapeGraphExporter() {
					URL = textCytoscapeServiceURL.Text,
					destSpeciesID = species.speciesId
				};

				exporter.Export(set, checkShowOriginalInteractions.Checked, checkShowMissing.Checked);
			}
			catch (WebException e) {
				MessageBox.Show(e.Message);
			}
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
