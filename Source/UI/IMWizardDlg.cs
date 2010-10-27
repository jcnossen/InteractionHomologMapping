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
	public partial class IMWizardDlg : Form
	{
		WizardState wizardState;

		Label[] stepLabels;
		int currentStep;

		/*
		 * 1: PartList
		 * 2: PartList + STRING IDs
		 * 3: PartList + STRING IDs -> InteractionSet
		 * 4: 
		 */

		public IMWizardDlg()
		{
			InitializeComponent();

			stepLabels = new Label[]{
				labelStepPP, 
				labelStepStringID, 
				labelStepMapInteractions, 
				labelStepExport
			};

			wizardState = new WizardState();
			wizardState.partList = new PartList();

			SetStep(0);
		}

		public void SetStep(int s)
		{
			foreach(Label l in stepLabels)
				l.BackColor=Color.Transparent;

			currentStep = s;
			stepLabels[s].BackColor = Color.FromArgb(128,255,128);

			buttonPrevStep.Enabled = s > 0;
			buttonNextStep.Enabled = s < 3;

			stepPanel.Controls.Clear();

			UserControl page = null;
			switch (s)
			{
				case 0:
					page = new WizardEnterPartsPage();
					break;
				case 1:
					page = new WizardStringIDPage();
					break;
				case 2:
					page = new WizardMapInteractions();
					break;
				case 3:
					page = new WizardExport();
					break;
			}
			page.Dock = DockStyle.Fill;
			stepPanel.Controls.Add(page);

			((IWizardPage)page).InitWizard(wizardState);
		}

		private void buttonNextStep_Click(object sender, EventArgs e)
		{
			SetStep(currentStep+1);
		}

		private void buttonPrevStep_Click(object sender, EventArgs e)
		{
			SetStep(currentStep-1);
		}

		private void labelStepPP_Click(object sender, EventArgs e)
		{
			SetStep(0);
		}

		private void labelStepStringID_Click(object sender, EventArgs e)
		{
			SetStep(1);
		}

		private void labelStepMapInteractions_Click(object sender, EventArgs e)
		{
			SetStep(2);
		}

		private void labelStepExport_Click(object sender, EventArgs e)
		{
			SetStep(3);
		}

	}
}
