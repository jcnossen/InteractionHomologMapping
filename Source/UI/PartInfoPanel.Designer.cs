namespace InteractionMapping
{
	partial class PartInfoPanel
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.labelDesc = new System.Windows.Forms.Label();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageDNA = new System.Windows.Forms.TabPage();
			this.textDNA = new System.Windows.Forms.TextBox();
			this.tabPageAA = new System.Windows.Forms.TabPage();
			this.textAA = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textStringID = new System.Windows.Forms.TextBox();
			this.labelName = new System.Windows.Forms.LinkLabel();
			this.blastBackgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.buttonOpenStringWeb = new System.Windows.Forms.Button();
			this.tabControl.SuspendLayout();
			this.tabPageDNA.SuspendLayout();
			this.tabPageAA.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Description";
			// 
			// labelDesc
			// 
			this.labelDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.labelDesc.Location = new System.Drawing.Point(93, 37);
			this.labelDesc.Name = "labelDesc";
			this.labelDesc.Size = new System.Drawing.Size(298, 21);
			this.labelDesc.TabIndex = 5;
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPageDNA);
			this.tabControl.Controls.Add(this.tabPageAA);
			this.tabControl.Location = new System.Drawing.Point(3, 89);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(395, 158);
			this.tabControl.TabIndex = 7;
			// 
			// tabPageDNA
			// 
			this.tabPageDNA.Controls.Add(this.textDNA);
			this.tabPageDNA.Location = new System.Drawing.Point(4, 22);
			this.tabPageDNA.Name = "tabPageDNA";
			this.tabPageDNA.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageDNA.Size = new System.Drawing.Size(387, 132);
			this.tabPageDNA.TabIndex = 0;
			this.tabPageDNA.Text = "DNA";
			this.tabPageDNA.UseVisualStyleBackColor = true;
			// 
			// textDNA
			// 
			this.textDNA.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textDNA.Location = new System.Drawing.Point(3, 3);
			this.textDNA.Multiline = true;
			this.textDNA.Name = "textDNA";
			this.textDNA.Size = new System.Drawing.Size(381, 126);
			this.textDNA.TabIndex = 0;
			// 
			// tabPageAA
			// 
			this.tabPageAA.Controls.Add(this.textAA);
			this.tabPageAA.Location = new System.Drawing.Point(4, 22);
			this.tabPageAA.Name = "tabPageAA";
			this.tabPageAA.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageAA.Size = new System.Drawing.Size(387, 132);
			this.tabPageAA.TabIndex = 1;
			this.tabPageAA.Text = "AA";
			this.tabPageAA.UseVisualStyleBackColor = true;
			// 
			// textAA
			// 
			this.textAA.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textAA.Location = new System.Drawing.Point(3, 3);
			this.textAA.Multiline = true;
			this.textAA.Name = "textAA";
			this.textAA.Size = new System.Drawing.Size(381, 126);
			this.textAA.TabIndex = 0;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(11, 66);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(62, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "STRING-ID";
			// 
			// textStringID
			// 
			this.textStringID.Location = new System.Drawing.Point(98, 63);
			this.textStringID.Name = "textStringID";
			this.textStringID.Size = new System.Drawing.Size(191, 20);
			this.textStringID.TabIndex = 9;
			this.textStringID.TextChanged += new System.EventHandler(this.textStringID_TextChanged);
			// 
			// labelName
			// 
			this.labelName.Location = new System.Drawing.Point(92, 5);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(194, 26);
			this.labelName.TabIndex = 10;
			this.labelName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelName_LinkClicked);
			// 
			// blastBackgroundWorker
			// 
			this.blastBackgroundWorker.WorkerReportsProgress = true;
			// 
			// buttonOpenStringWeb
			// 
			this.buttonOpenStringWeb.Location = new System.Drawing.Point(295, 61);
			this.buttonOpenStringWeb.Name = "buttonOpenStringWeb";
			this.buttonOpenStringWeb.Size = new System.Drawing.Size(96, 22);
			this.buttonOpenStringWeb.TabIndex = 11;
			this.buttonOpenStringWeb.Text = "Open Website";
			this.buttonOpenStringWeb.UseVisualStyleBackColor = true;
			this.buttonOpenStringWeb.Click += new System.EventHandler(this.buttonOpenStringWeb_Click);
			// 
			// PartInfoPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.buttonOpenStringWeb);
			this.Controls.Add(this.labelName);
			this.Controls.Add(this.textStringID);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.labelDesc);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "PartInfoPanel";
			this.Size = new System.Drawing.Size(399, 247);
			this.tabControl.ResumeLayout(false);
			this.tabPageDNA.ResumeLayout(false);
			this.tabPageDNA.PerformLayout();
			this.tabPageAA.ResumeLayout(false);
			this.tabPageAA.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label labelDesc;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageDNA;
		private System.Windows.Forms.TabPage tabPageAA;
		private System.Windows.Forms.TextBox textDNA;
		private System.Windows.Forms.TextBox textAA;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textStringID;
		private System.Windows.Forms.LinkLabel labelName;
		private System.ComponentModel.BackgroundWorker blastBackgroundWorker;
		private System.Windows.Forms.Button buttonOpenStringWeb;
	}
}
