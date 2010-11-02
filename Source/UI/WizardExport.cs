using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace InteractionMapping
{
	public partial class WizardExport : UserControl, IWizardPage
	{
		WizardState wstate;

		public WizardExport()
		{
			InitializeComponent();
		}

		public void InitWizard(WizardState ws) 
		{
			wstate = ws;
		}

		private void buttonExportCytoscape_Click(object sender, EventArgs e)
		{
			if (wstate.species == null || wstate.set == null) {
				MessageBox.Show("Finish step 3 first");
				return;
			}

			var exporter = new CytoscapeGraphExporter() {
				URL = textCytoscapeServiceURL.Text,
				destSpeciesID = wstate.species.speciesId
			};

			exporter.Export(wstate.set, checkExportNative.Checked, true);
		}

		private void buttonExportToCSV_Click(object sender, EventArgs e)
		{
			var sfd = new SaveFileDialog() {
				Title = "Export to CSV",
			};

			if (sfd.ShowDialog() == DialogResult.OK) {
				using (Stream stream = sfd.OpenFile()) {
					
				}
			}
		}
	}
}
