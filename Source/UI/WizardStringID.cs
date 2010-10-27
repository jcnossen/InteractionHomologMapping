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
	public partial class WizardStringIDPage : UserControl, IWizardPage
	{
		WizardState wstate;

		public WizardStringIDPage()
		{
			InitializeComponent();
		}

		public void InitWizard(WizardState ws)
		{
			wstate = ws;
			partListControl.PartList = ws.partList;
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Util.OpenWebAddr("http://string-db.org/newstring_cgi/show_input_page.pl?input_page_type=single_sequence");
		}

	}
}
