namespace InteractionMapping
{
	partial class IMWizardDlg
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.stepPanel = new System.Windows.Forms.Panel();
			this.labelStepPP = new System.Windows.Forms.Label();
			this.labelStepStringID = new System.Windows.Forms.Label();
			this.labelStepMapInteractions = new System.Windows.Forms.Label();
			this.labelStepExport = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonNextStep = new System.Windows.Forms.Button();
			this.buttonPrevStep = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 44);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 18);
			this.label1.TabIndex = 1;
			this.label1.Text = "Steps:";
			// 
			// stepPanel
			// 
			this.stepPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.stepPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.stepPanel.Location = new System.Drawing.Point(202, 42);
			this.stepPanel.Name = "stepPanel";
			this.stepPanel.Size = new System.Drawing.Size(451, 290);
			this.stepPanel.TabIndex = 2;
			// 
			// labelStepPP
			// 
			this.labelStepPP.BackColor = System.Drawing.Color.Transparent;
			this.labelStepPP.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelStepPP.Location = new System.Drawing.Point(11, 62);
			this.labelStepPP.Name = "labelStepPP";
			this.labelStepPP.Size = new System.Drawing.Size(186, 46);
			this.labelStepPP.TabIndex = 3;
			this.labelStepPP.Text = "1. Enter parts and\r\n    proteins";
			this.labelStepPP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelStepPP.Click += new System.EventHandler(this.labelStepPP_Click);
			// 
			// labelStepStringID
			// 
			this.labelStepStringID.BackColor = System.Drawing.Color.Transparent;
			this.labelStepStringID.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelStepStringID.Location = new System.Drawing.Point(12, 108);
			this.labelStepStringID.Name = "labelStepStringID";
			this.labelStepStringID.Size = new System.Drawing.Size(185, 48);
			this.labelStepStringID.TabIndex = 4;
			this.labelStepStringID.Text = "2. Find STRING protein\r\n    identifiers";
			this.labelStepStringID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelStepStringID.Click += new System.EventHandler(this.labelStepStringID_Click);
			// 
			// labelStepMapInteractions
			// 
			this.labelStepMapInteractions.BackColor = System.Drawing.Color.Transparent;
			this.labelStepMapInteractions.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelStepMapInteractions.Location = new System.Drawing.Point(11, 156);
			this.labelStepMapInteractions.Name = "labelStepMapInteractions";
			this.labelStepMapInteractions.Size = new System.Drawing.Size(185, 44);
			this.labelStepMapInteractions.TabIndex = 5;
			this.labelStepMapInteractions.Text = "3. Map interactions to\r\n    organism";
			this.labelStepMapInteractions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelStepMapInteractions.Click += new System.EventHandler(this.labelStepMapInteractions_Click);
			// 
			// labelStepExport
			// 
			this.labelStepExport.BackColor = System.Drawing.Color.Transparent;
			this.labelStepExport.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelStepExport.Location = new System.Drawing.Point(11, 200);
			this.labelStepExport.Name = "labelStepExport";
			this.labelStepExport.Size = new System.Drawing.Size(185, 44);
			this.labelStepExport.TabIndex = 6;
			this.labelStepExport.Text = "4. Export to \r\n    Cytoscape or CSV";
			this.labelStepExport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelStepExport.Click += new System.EventHandler(this.labelStepExport_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(11, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(258, 24);
			this.label2.TabIndex = 7;
			this.label2.Text = "Homolog Interaction Mapping";
			// 
			// buttonNextStep
			// 
			this.buttonNextStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonNextStep.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonNextStep.Location = new System.Drawing.Point(544, 338);
			this.buttonNextStep.Name = "buttonNextStep";
			this.buttonNextStep.Size = new System.Drawing.Size(109, 30);
			this.buttonNextStep.TabIndex = 8;
			this.buttonNextStep.Text = "Next Step";
			this.buttonNextStep.UseVisualStyleBackColor = true;
			this.buttonNextStep.Click += new System.EventHandler(this.buttonNextStep_Click);
			// 
			// buttonPrevStep
			// 
			this.buttonPrevStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonPrevStep.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonPrevStep.Location = new System.Drawing.Point(388, 338);
			this.buttonPrevStep.Name = "buttonPrevStep";
			this.buttonPrevStep.Size = new System.Drawing.Size(150, 30);
			this.buttonPrevStep.TabIndex = 9;
			this.buttonPrevStep.Text = "Previous Step";
			this.buttonPrevStep.UseVisualStyleBackColor = true;
			this.buttonPrevStep.Click += new System.EventHandler(this.buttonPrevStep_Click);
			// 
			// IMWizardDlg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(665, 373);
			this.Controls.Add(this.buttonPrevStep);
			this.Controls.Add(this.buttonNextStep);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.labelStepExport);
			this.Controls.Add(this.labelStepMapInteractions);
			this.Controls.Add(this.labelStepStringID);
			this.Controls.Add(this.labelStepPP);
			this.Controls.Add(this.stepPanel);
			this.Controls.Add(this.label1);
			this.Name = "IMWizardDlg";
			this.Text = "Homolog Interaction Mapping";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel stepPanel;
		private System.Windows.Forms.Label labelStepPP;
		private System.Windows.Forms.Label labelStepStringID;
		private System.Windows.Forms.Label labelStepMapInteractions;
		private System.Windows.Forms.Label labelStepExport;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button buttonNextStep;
		private System.Windows.Forms.Button buttonPrevStep;

	}
}