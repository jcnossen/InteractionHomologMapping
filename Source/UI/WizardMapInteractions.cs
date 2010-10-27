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

		public WizardMapInteractions()
		{
			InitializeComponent();
		}

		public void InitWizard(WizardState ws)
		{
			wstate = ws;
			InitializeSet();
		}

		public void InitializeSet()
		{
			wstate.set = PartList.BuildInteractionSet(wstate.partList.parts);

			RunQuery(delegate
			{
				var speciesList = SpeciesList;

				using (var strdb = new StringDatabaseSearch())
				{
					foreach (Protein prot in wstate.set.proteins.Values)
						if (prot.stringID == 0)
							strdb.UpdateProtein(prot);
				}

				Invoke(new Action(delegate {
					comboSpecies.Items.AddRange(speciesList);
					comboSpecies.SelectedIndex = Array.IndexOf(SpeciesList,
						SpeciesList.FirstOrDefault(s => s.speciesId == 83333));

					foreach (Protein prot in wstate.set.proteins.Values)
						if (prot.stringID == 0)
							treeView.Nodes.Add(CreateProteinNode(prot));

					treeView.ExpandAll();
				}));
			});
		}

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
				try
				{
					queryFunc();
				}
				catch (Exception e)
				{
					Invoke(new Action(delegate { MessageBox.Show("Error: " + e.Message); }));
				}
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
			List<Protein> natives = new List<Protein>();

			foreach (Protein p in wstate.set.proteins.Values)
				if (!p.fromHomolog)
					natives.Add(p);

			using (StringDatabaseSearch strdb = new StringDatabaseSearch())
			{
				strdb.ExtendInteractions(wstate.set, natives, MinInteractionScore, TreeUpdateLogCallback);
			}

		}

		private void buttonLocalExtend_Click(object sender, EventArgs e)
		{
			RunQuery(delegate
			{
				List<Protein> locals = new List<Protein>();

				foreach (Protein p in wstate.set.proteins.Values)
					if (p.fromHomolog)
						locals.Add(p);

				using (StringDatabaseSearch strdb = new StringDatabaseSearch())
				{
					strdb.ExtendInteractions(wstate.set, locals, MinInteractionScore, TreeUpdateLogCallback);
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
	
	}
}
