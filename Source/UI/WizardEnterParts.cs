using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InteractionMapping
{
	public partial class WizardEnterPartsPage : UserControl, IWizardPage
	{
		WizardState wstate;

		public WizardEnterPartsPage()
		{
			InitializeComponent();
		}

		void UpdateView()
		{
			partListControl.PartList = wstate.partList;
		}

		public void LoadFile(string file)
		{
			PartList partList = PartList.LoadXML(file);

			partList.LoadParts(delegate
			{
				wstate.partList = partList;
				Invoke(new Action(delegate {
					partListControl.PartList = partList;
				}));
			});

		}


		private void MainDlg_Load(object sender, EventArgs e)
		{
			UpdateView();
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			wstate.partList = new PartList();
			UpdateView();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var ofd = new OpenFileDialog()
			{
				Filter = "Biobrick List XML (*.xml)|*.xml",
				Title = "Select assembly to load"
			};

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				LoadFile(ofd.FileName);
			}
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var sfd = new SaveFileDialog()
			{
				Filter = "Biobrick List XML (*.xml)|*.xml",
				Title = "Enter filename to save"
			};

			if (sfd.ShowDialog() == DialogResult.OK) {
				wstate.partList.SaveXML(sfd.FileName);
			}
		}


		private void buttonAddPart_Click(object sender, EventArgs e)
		{
			string bb = textBB.Text;
			BiobrickCache.Instance.GetPart(bb, (part, exc) => {
				if (part == null)
					MessageBox.Show(exc.Message);
				else {
					wstate.partList.parts.Add(new PartList.Part() {
						data = part,
						name = part.Name
					});
					UpdateView();
				}
			});
			textBB.Text = "";
		}

		#region IWizardPage Members

		public void InitWizard(WizardState state)
		{
			wstate = state;
			UpdateView();
		}

		#endregion
	}
}
