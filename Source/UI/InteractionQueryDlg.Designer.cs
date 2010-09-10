/*
 Copyright (c) 2010 Jelmer Cnossen

 Permission is hereby granted, free of charge, to any person obtaining a copy
 of this software and associated documentation files (the "Software"), to deal
 in the Software without restriction, including without limitation the rights
 to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 copies of the Software, and to permit persons to whom the Software is
 furnished to do so, subject to the following conditions:

 The above copyright notice and this permission notice shall be included in
 all copies or substantial portions of the Software.

 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 THE SOFTWARE.
 */
namespace InteractionMapping
{
	partial class InteractionQueryDlg
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
			this.textCytoscapeServiceURL = new System.Windows.Forms.TextBox();
			this.comboSpecies = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonFindHomologs = new System.Windows.Forms.Button();
			this.buttonNativeExtend = new System.Windows.Forms.Button();
			this.buttonLocalExtend = new System.Windows.Forms.Button();
			this.treeView = new System.Windows.Forms.TreeView();
			this.textMinIntAct = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textMinHomolog = new System.Windows.Forms.TextBox();
			this.checkUseCytoscape = new System.Windows.Forms.CheckBox();
			this.checkShowOriginalInteractions = new System.Windows.Forms.CheckBox();
			this.checkShowMissing = new System.Windows.Forms.CheckBox();
			this.labelInProgress = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textCyNetworkName = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// textCytoscapeServiceURL
			// 
			this.textCytoscapeServiceURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.textCytoscapeServiceURL.Enabled = false;
			this.textCytoscapeServiceURL.Location = new System.Drawing.Point(134, 12);
			this.textCytoscapeServiceURL.Name = "textCytoscapeServiceURL";
			this.textCytoscapeServiceURL.Size = new System.Drawing.Size(497, 20);
			this.textCytoscapeServiceURL.TabIndex = 1;
			this.textCytoscapeServiceURL.Text = "http://localhost:9001/cytoscape/CytoscapeRPC";
			// 
			// comboSpecies
			// 
			this.comboSpecies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.comboSpecies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboSpecies.FormattingEnabled = true;
			this.comboSpecies.Location = new System.Drawing.Point(134, 38);
			this.comboSpecies.Name = "comboSpecies";
			this.comboSpecies.Size = new System.Drawing.Size(196, 21);
			this.comboSpecies.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(28, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Species:";
			// 
			// buttonFindHomologs
			// 
			this.buttonFindHomologs.Location = new System.Drawing.Point(12, 69);
			this.buttonFindHomologs.Name = "buttonFindHomologs";
			this.buttonFindHomologs.Size = new System.Drawing.Size(116, 23);
			this.buttonFindHomologs.TabIndex = 4;
			this.buttonFindHomologs.Text = "Find homologs";
			this.buttonFindHomologs.UseVisualStyleBackColor = true;
			this.buttonFindHomologs.Click += new System.EventHandler(this.buttonFindHomologs_Click);
			// 
			// buttonNativeExtend
			// 
			this.buttonNativeExtend.Location = new System.Drawing.Point(134, 69);
			this.buttonNativeExtend.Name = "buttonNativeExtend";
			this.buttonNativeExtend.Size = new System.Drawing.Size(146, 23);
			this.buttonNativeExtend.TabIndex = 5;
			this.buttonNativeExtend.Text = "Native species extend";
			this.buttonNativeExtend.UseVisualStyleBackColor = true;
			this.buttonNativeExtend.Click += new System.EventHandler(this.buttonNativeExtend_Click);
			// 
			// buttonLocalExtend
			// 
			this.buttonLocalExtend.Location = new System.Drawing.Point(286, 69);
			this.buttonLocalExtend.Name = "buttonLocalExtend";
			this.buttonLocalExtend.Size = new System.Drawing.Size(137, 23);
			this.buttonLocalExtend.TabIndex = 6;
			this.buttonLocalExtend.Text = "New species extend";
			this.buttonLocalExtend.UseVisualStyleBackColor = true;
			this.buttonLocalExtend.Click += new System.EventHandler(this.buttonLocalExtend_Click);
			// 
			// treeView
			// 
			this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.treeView.Location = new System.Drawing.Point(12, 150);
			this.treeView.Name = "treeView";
			this.treeView.PathSeparator = "/";
			this.treeView.Size = new System.Drawing.Size(619, 192);
			this.treeView.TabIndex = 7;
			// 
			// textMinIntAct
			// 
			this.textMinIntAct.Location = new System.Drawing.Point(150, 98);
			this.textMinIntAct.Name = "textMinIntAct";
			this.textMinIntAct.Size = new System.Drawing.Size(77, 20);
			this.textMinIntAct.TabIndex = 8;
			this.textMinIntAct.Text = "0.5";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 101);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(132, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Minimum interaction score:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 128);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(123, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Minimum homolog score:";
			// 
			// textMinHomolog
			// 
			this.textMinHomolog.Location = new System.Drawing.Point(150, 124);
			this.textMinHomolog.Name = "textMinHomolog";
			this.textMinHomolog.Size = new System.Drawing.Size(77, 20);
			this.textMinHomolog.TabIndex = 11;
			this.textMinHomolog.Text = "0.5";
			// 
			// checkUseCytoscape
			// 
			this.checkUseCytoscape.AutoSize = true;
			this.checkUseCytoscape.Location = new System.Drawing.Point(12, 14);
			this.checkUseCytoscape.Name = "checkUseCytoscape";
			this.checkUseCytoscape.Size = new System.Drawing.Size(116, 17);
			this.checkUseCytoscape.TabIndex = 0;
			this.checkUseCytoscape.Text = "Show in cytoscape";
			this.checkUseCytoscape.UseVisualStyleBackColor = true;
			this.checkUseCytoscape.CheckedChanged += new System.EventHandler(this.checkUseCytoscape_CheckedChanged);
			// 
			// checkShowOriginalInteractions
			// 
			this.checkShowOriginalInteractions.AutoSize = true;
			this.checkShowOriginalInteractions.Location = new System.Drawing.Point(265, 100);
			this.checkShowOriginalInteractions.Name = "checkShowOriginalInteractions";
			this.checkShowOriginalInteractions.Size = new System.Drawing.Size(146, 17);
			this.checkShowOriginalInteractions.TabIndex = 12;
			this.checkShowOriginalInteractions.Text = "Show original interactions";
			this.checkShowOriginalInteractions.UseVisualStyleBackColor = true;
			this.checkShowOriginalInteractions.CheckedChanged += new System.EventHandler(this.checkShowOriginalInteractions_CheckedChanged);
			// 
			// checkShowMissing
			// 
			this.checkShowMissing.AutoSize = true;
			this.checkShowMissing.Location = new System.Drawing.Point(265, 123);
			this.checkShowMissing.Name = "checkShowMissing";
			this.checkShowMissing.Size = new System.Drawing.Size(138, 17);
			this.checkShowMissing.TabIndex = 13;
			this.checkShowMissing.Text = "Show missing homologs";
			this.checkShowMissing.UseVisualStyleBackColor = true;
			this.checkShowMissing.CheckedChanged += new System.EventHandler(this.checkShowMissing_CheckedChanged);
			// 
			// labelInProgress
			// 
			this.labelInProgress.AutoSize = true;
			this.labelInProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelInProgress.Location = new System.Drawing.Point(445, 74);
			this.labelInProgress.Name = "labelInProgress";
			this.labelInProgress.Size = new System.Drawing.Size(120, 13);
			this.labelInProgress.TabIndex = 14;
			this.labelInProgress.Text = "Query In Progress.,,";
			this.labelInProgress.Visible = false;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(336, 41);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(134, 13);
			this.label4.TabIndex = 15;
			this.label4.Text = "Cytoscape Network Name:";
			// 
			// textCyNetworkName
			// 
			this.textCyNetworkName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textCyNetworkName.Location = new System.Drawing.Point(476, 38);
			this.textCyNetworkName.Name = "textCyNetworkName";
			this.textCyNetworkName.Size = new System.Drawing.Size(155, 20);
			this.textCyNetworkName.TabIndex = 16;
			this.textCyNetworkName.Text = "STRING Interaction search";
			// 
			// InteractionQueryDlg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(643, 354);
			this.Controls.Add(this.textCyNetworkName);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.labelInProgress);
			this.Controls.Add(this.checkShowMissing);
			this.Controls.Add(this.checkShowOriginalInteractions);
			this.Controls.Add(this.textMinHomolog);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textMinIntAct);
			this.Controls.Add(this.treeView);
			this.Controls.Add(this.buttonLocalExtend);
			this.Controls.Add(this.buttonNativeExtend);
			this.Controls.Add(this.buttonFindHomologs);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboSpecies);
			this.Controls.Add(this.textCytoscapeServiceURL);
			this.Controls.Add(this.checkUseCytoscape);
			this.Name = "InteractionQueryDlg";
			this.Text = "Query protein interactions";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textCytoscapeServiceURL;
		private System.Windows.Forms.ComboBox comboSpecies;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonFindHomologs;
		private System.Windows.Forms.Button buttonNativeExtend;
		private System.Windows.Forms.Button buttonLocalExtend;
		private System.Windows.Forms.TreeView treeView;
		private System.Windows.Forms.TextBox textMinIntAct;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textMinHomolog;
		private System.Windows.Forms.CheckBox checkUseCytoscape;
		private System.Windows.Forms.CheckBox checkShowOriginalInteractions;
		private System.Windows.Forms.CheckBox checkShowMissing;
		private System.Windows.Forms.Label labelInProgress;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textCyNetworkName;
	}
}