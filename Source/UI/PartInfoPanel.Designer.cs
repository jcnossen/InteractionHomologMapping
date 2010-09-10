﻿namespace InteractionMapping
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
			this.label3 = new System.Windows.Forms.Label();
			this.labelDesc = new System.Windows.Forms.Label();
			this.labelLength = new System.Windows.Forms.Label();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageDNA = new System.Windows.Forms.TabPage();
			this.textDNA = new System.Windows.Forms.TextBox();
			this.tabPageAA = new System.Windows.Forms.TabPage();
			this.textAA = new System.Windows.Forms.TextBox();
			this.tabInteractions = new System.Windows.Forms.TabPage();
			this.textInteractions = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textStringID = new System.Windows.Forms.TextBox();
			this.labelName = new System.Windows.Forms.LinkLabel();
			this.blastBackgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.buttonOpenStringWeb = new System.Windows.Forms.Button();
			this.tabControl.SuspendLayout();
			this.tabPageDNA.SuspendLayout();
			this.tabPageAA.SuspendLayout();
			this.tabInteractions.SuspendLayout();
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
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 61);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Length";
			// 
			// labelDesc
			// 
			this.labelDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.labelDesc.Location = new System.Drawing.Point(93, 37);
			this.labelDesc.Name = "labelDesc";
			this.labelDesc.Size = new System.Drawing.Size(263, 21);
			this.labelDesc.TabIndex = 5;
			// 
			// labelLength
			// 
			this.labelLength.Location = new System.Drawing.Point(93, 61);
			this.labelLength.Name = "labelLength";
			this.labelLength.Size = new System.Drawing.Size(91, 21);
			this.labelLength.TabIndex = 6;
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPageDNA);
			this.tabControl.Controls.Add(this.tabPageAA);
			this.tabControl.Controls.Add(this.tabInteractions);
			this.tabControl.Location = new System.Drawing.Point(3, 111);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(360, 136);
			this.tabControl.TabIndex = 7;
			// 
			// tabPageDNA
			// 
			this.tabPageDNA.Controls.Add(this.textDNA);
			this.tabPageDNA.Location = new System.Drawing.Point(4, 22);
			this.tabPageDNA.Name = "tabPageDNA";
			this.tabPageDNA.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageDNA.Size = new System.Drawing.Size(352, 110);
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
			this.textDNA.Size = new System.Drawing.Size(346, 104);
			this.textDNA.TabIndex = 0;
			// 
			// tabPageAA
			// 
			this.tabPageAA.Controls.Add(this.textAA);
			this.tabPageAA.Location = new System.Drawing.Point(4, 22);
			this.tabPageAA.Name = "tabPageAA";
			this.tabPageAA.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageAA.Size = new System.Drawing.Size(352, 110);
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
			this.textAA.Size = new System.Drawing.Size(346, 104);
			this.textAA.TabIndex = 0;
			// 
			// tabInteractions
			// 
			this.tabInteractions.Controls.Add(this.textInteractions);
			this.tabInteractions.Location = new System.Drawing.Point(4, 22);
			this.tabInteractions.Name = "tabInteractions";
			this.tabInteractions.Padding = new System.Windows.Forms.Padding(3);
			this.tabInteractions.Size = new System.Drawing.Size(352, 110);
			this.tabInteractions.TabIndex = 3;
			this.tabInteractions.Text = "Interactions";
			this.tabInteractions.UseVisualStyleBackColor = true;
			// 
			// textInteractions
			// 
			this.textInteractions.AcceptsReturn = true;
			this.textInteractions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textInteractions.Location = new System.Drawing.Point(3, 3);
			this.textInteractions.Multiline = true;
			this.textInteractions.Name = "textInteractions";
			this.textInteractions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textInteractions.Size = new System.Drawing.Size(346, 104);
			this.textInteractions.TabIndex = 0;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(9, 85);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(62, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "STRING-ID";
			// 
			// textStringID
			// 
			this.textStringID.Location = new System.Drawing.Point(96, 82);
			this.textStringID.Name = "textStringID";
			this.textStringID.Size = new System.Drawing.Size(191, 20);
			this.textStringID.TabIndex = 9;
			this.textStringID.TextChanged += new System.EventHandler(this.textStringID_TextChanged);
			// 
			// labelName
			// 
			this.labelName.Location = new System.Drawing.Point(93, 11);
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
			this.buttonOpenStringWeb.Location = new System.Drawing.Point(293, 80);
			this.buttonOpenStringWeb.Name = "buttonOpenStringWeb";
			this.buttonOpenStringWeb.Size = new System.Drawing.Size(52, 22);
			this.buttonOpenStringWeb.TabIndex = 11;
			this.buttonOpenStringWeb.Text = "Open";
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
			this.Controls.Add(this.labelLength);
			this.Controls.Add(this.labelDesc);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "PartInfoPanel";
			this.Size = new System.Drawing.Size(364, 247);
			this.tabControl.ResumeLayout(false);
			this.tabPageDNA.ResumeLayout(false);
			this.tabPageDNA.PerformLayout();
			this.tabPageAA.ResumeLayout(false);
			this.tabPageAA.PerformLayout();
			this.tabInteractions.ResumeLayout(false);
			this.tabInteractions.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label labelDesc;
		private System.Windows.Forms.Label labelLength;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageDNA;
		private System.Windows.Forms.TabPage tabPageAA;
		private System.Windows.Forms.TextBox textDNA;
		private System.Windows.Forms.TextBox textAA;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textStringID;
		private System.Windows.Forms.TabPage tabInteractions;
		private System.Windows.Forms.LinkLabel labelName;
		private System.Windows.Forms.TextBox textInteractions;
		private System.ComponentModel.BackgroundWorker blastBackgroundWorker;
		private System.Windows.Forms.Button buttonOpenStringWeb;
	}
}
