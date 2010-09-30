using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InteractionMapping
{
	public partial class BlastDlg : Form
	{
		NCBIBlastServiceAsync.JDispatcherServiceClient blastDispatch;

		public BlastDlg(string seq)
		{
			InitializeComponent();

			txtSeq.Text = seq;

			blastDispatch = new NCBIBlastServiceAsync.JDispatcherServiceClient();
		}

		private void buttonBlast_Click(object sender, EventArgs e)
		{
			NCBIBlastServiceAsync.InputParameters p = new InteractionMapping.NCBIBlastServiceAsync.InputParameters();

			p.sequence = txtSeq.Text;
			p.database = new string[]{ "nr" };
		
			blastDispatch.Open();

		}

	}
}
