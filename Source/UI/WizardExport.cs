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

			try {
				exporter.Export(wstate.set, checkExportNative.Checked, true);
			}catch (Exception exc) {
				MessageBox.Show("Error occurred:\n" + exc.Message);
			}
		}

		private void buttonExportToCSV_Click(object sender, EventArgs e)
		{
			var sfd = new SaveFileDialog() {
				Title = "Export to CSV",
			};

			if (sfd.ShowDialog() == DialogResult.OK) {
				using (Stream stream = sfd.OpenFile()) {
					StreamWriter sw = new StreamWriter(stream);

					sw.WriteLine("start_protein; host_protein; interactionscore; homologyscore; host_protein_name; host_protein_annotation");
					foreach (MappedInteraction mi in wstate.set.GetMappedInteractions(true)) {
						sw.WriteLine("'{0}';'{1}';'{2}';'{3}';'{4}';'{5}'", mi.A.stringExternalID, mi.B.stringExternalID, mi.score, mi.homologyScore, mi.b.PreferredName, mi.b.Annotation);
					}
				}
			}
		}
	}
}
