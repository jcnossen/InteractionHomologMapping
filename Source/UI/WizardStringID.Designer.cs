namespace InteractionMapping
{
	partial class WizardStringIDPage
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label2 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.partListControl = new InteractionMapping.PartListControl();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(33, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Go to";
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(46, 13);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(96, 13);
			this.linkLabel1.TabIndex = 6;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "http://string-db.org";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(141, 13);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(185, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "and enter the part protein sequences";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(15, 30);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(311, 35);
			this.label4.TabIndex = 8;
			this.label4.Text = "in the search window. Select the proteins with the best homology to the part sequ" +
					"ence";
			// 
			// partListControl
			// 
			this.partListControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.partListControl.Location = new System.Drawing.Point(0, 68);
			this.partListControl.Name = "partListControl";
			this.partListControl.PartList = null;
			this.partListControl.Size = new System.Drawing.Size(342, 243);
			this.partListControl.TabIndex = 9;
			// 
			// WizardStringIDPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.partListControl);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.label2);
			this.Name = "WizardStringIDPage";
			this.Size = new System.Drawing.Size(345, 314);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private PartListControl partListControl;
	}
}
