using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace InteractionMapping
{
	public partial class WizardMapInteractions : UserControl, IWizardPage
	{
		WizardState wstate;
		Dictionary<Protein, TreeNode> treeNodes = new Dictionary<Protein, TreeNode>();
		StringDatabaseSearch.dbSpecies[] speciesList;

		public WizardMapInteractions()
		{
			InitializeComponent();
		}

		public void InitWizard(WizardState ws)
		{
			wstate = ws;

			if (ws.set == null)
				InitializeSet();
		}

		public void InitializeSet()
		{
			RunQuery(delegate
			{
				var speciesList = SpeciesList;
				wstate.speciesList = speciesList.Select(s=>s.compactName).ToArray();

				using (var strdb = new StringDatabaseSearch())
				{
					wstate.set = PartList.BuildInteractionSet(wstate.partList.parts.Where(p => p.enabled));

					foreach (Protein prot in wstate.set.proteins.Values)
						if (prot.stringID == 0)
							strdb.UpdateProtein(prot);
				}

				Invoke(new Action(delegate {
					comboSpecies.Items.AddRange(speciesList);
					comboSpecies.SelectedIndex = Array.IndexOf(speciesList,
						speciesList.FirstOrDefault(s => s.speciesId == 83333));

					foreach (Protein prot in wstate.set.proteins.Values)
						treeView.Nodes.Add(CreateProteinNode(prot));

					treeView.ExpandAll();
				}));
			});
		}

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

		void SetInProgress(bool state)
		{
			labelInProgress.Visible = state;
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
				SetInProgress(false);
			}));
		}

		void RunQuery(Action queryFunc)
		{
			ThreadPool.QueueUserWorkItem(new WaitCallback(delegate
			{
				BeginQuery();
				queryFunc();
/*				try
				{
					queryFunc();
				}
				catch (Exception e)
				{
					Invoke(new Action(delegate { MessageBox.Show("Error: " + e.Message); }));
				}*/
				EndQuery();
			}));
		}

		private void buttonNativeExtend_Click(object sender, EventArgs e)
		{
			RunQuery(delegate
			{
				NativeExtend();
			});
		}

		private void NativeExtend()
		{
			using (StringDatabaseSearch strdb = new StringDatabaseSearch())
			{
				strdb.ExtendInteractions(wstate.set, wstate.set.proteins.Values.Where(p => !p.fromHomolog).ToArray(), 
					MinInteractionScore, true, TreeUpdateLogCallback);

				// Find the interactions between the newly added nodes
//				strdb.ExtendInteractions(wstate.set, wstate.set.proteins.Values.Where(p => !p.fromHomolog).ToArray(),
	//				MinInteractionScore, false, TreeUpdateLogCallback);
			}
		}

		private void buttonLocalExtend_Click(object sender, EventArgs e)
		{
			RunQuery(delegate
			{
				using (StringDatabaseSearch strdb = new StringDatabaseSearch())
				{
					strdb.ExtendInteractions(wstate.set, wstate.set.proteins.Values.Where(p => p.fromHomolog), 
						MinInteractionScore, true, TreeUpdateLogCallback);
				}
			});
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

			RunQuery(delegate{
				List<Protein> natives = new List<Protein>();
				foreach (Protein p in wstate.set.proteins.Values)
					if (!p.fromHomolog)
						natives.Add(p);

				using (StringDatabaseSearch strdb = new StringDatabaseSearch())
				{
					strdb.ExtendBestHomologs(wstate.set, natives, speciesID, 0, TreeUpdateLogCallback);
				}
			});
		}

		private void buttonMapInteractions_Click(object sender, EventArgs e)
		{
			var species = (StringDatabaseSearch.dbSpecies)comboSpecies.SelectedItem;
			int speciesID = species.speciesId;

			RunQuery(delegate
			{
				NativeExtend();

				List<Protein> natives = new List<Protein>();
				foreach (Protein p in wstate.set.proteins.Values)
					if (!p.fromHomolog)
						natives.Add(p);

				using (StringDatabaseSearch strdb = new StringDatabaseSearch())
				{
					strdb.ExtendBestHomologs(wstate.set, natives, speciesID, 0, TreeUpdateLogCallback);
				}
			});
		}

		private void comboSpecies_SelectedIndexChanged(object sender, EventArgs e)
		{
			wstate.species = (StringDatabaseSearch.dbSpecies)comboSpecies.SelectedItem;
		}

		private void buttonClear_Click(object sender, EventArgs e)
		{
			treeNodes.Clear();
			treeView.Nodes.Clear();
			InitializeSet();
		}
	
	}
}
