using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace InteractionMapping
{
	using ServiceClient = NCBIBlastServiceAsync.JDispatcherServiceClient;
	using BlastOutputParameter = NCBIBlastServiceAsync.wsRawOutputParameter;
	using InputParameters = NCBIBlastServiceAsync.InputParameters;

	public partial class BlastDlg : Form
	{
		string jobID;

		NCBIBlastServiceAsync.JDispatcherServiceClient blastDispatch;

		public BlastDlg(string seq)
		{
			InitializeComponent();

			txtSeq.Text = seq;
			blastDispatch = new ServiceClient();
		}

		private void buttonBlast_Click(object sender, EventArgs e)
		{
			buttonBlast.Enabled=false;
			InputParameters p = new InputParameters();

			p.stype = "protein";
			p.sequence = txtSeq.Text.Replace('.', '*');
			p.database = new string[]{ "nrpl1" };
			p.program = "blastp";

			blastDispatch.Open();
			jobID = blastDispatch.run("blast@igempartview.appspot.com", "test", p);
			statusPollTimer.Start();
		}

		private void BlastDlg_Load(object sender, EventArgs e)
		{

		}

		private void statusPollTimer_Tick(object sender, EventArgs e)
		{
			string status = blastDispatch.getStatus(jobID);
			lblStatus.Text = status;
			if (status == "FINISHED") {
				BlastOutputParameter[] pm = new BlastOutputParameter[]{};
 
				byte[] result = blastDispatch.getResult(jobID, "", pm);
				string resultStr = Encoding.ASCII.GetString(result);
				Console.Write(resultStr);
				MessageBox.Show(resultStr);

				statusPollTimer.Stop();
				blastDispatch.Close();
				buttonBlast.Enabled = true;
			}
		}
	}
}
