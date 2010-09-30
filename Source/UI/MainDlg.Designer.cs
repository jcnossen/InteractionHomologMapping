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
	partial class MainDlg
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
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.wikiTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.queryInteractionsForSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.textBB = new System.Windows.Forms.TextBox();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.listBB = new System.Windows.Forms.ListView();
			this.menuStrip.SuspendLayout();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.generateToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(589, 24);
			this.menuStrip.TabIndex = 0;
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.newToolStripMenuItem.Text = "New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// generateToolStripMenuItem
			// 
			this.generateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wikiTableToolStripMenuItem,
            this.queryInteractionsForSelectionToolStripMenuItem});
			this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
			this.generateToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
			this.generateToolStripMenuItem.Text = "Generate";
			// 
			// wikiTableToolStripMenuItem
			// 
			this.wikiTableToolStripMenuItem.Name = "wikiTableToolStripMenuItem";
			this.wikiTableToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
			this.wikiTableToolStripMenuItem.Text = "Wiki table";
			this.wikiTableToolStripMenuItem.Visible = false;
			this.wikiTableToolStripMenuItem.Click += new System.EventHandler(this.wikiTableToolStripMenuItem_Click);
			// 
			// queryInteractionsForSelectionToolStripMenuItem
			// 
			this.queryInteractionsForSelectionToolStripMenuItem.Name = "queryInteractionsForSelectionToolStripMenuItem";
			this.queryInteractionsForSelectionToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
			this.queryInteractionsForSelectionToolStripMenuItem.Text = "Query interactions for selection";
			this.queryInteractionsForSelectionToolStripMenuItem.Click += new System.EventHandler(this.queryInteractionsForSelectionToolStripMenuItem_Click);
			// 
			// textBB
			// 
			this.textBB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.textBB.Location = new System.Drawing.Point(3, 3);
			this.textBB.Name = "textBB";
			this.textBB.Size = new System.Drawing.Size(190, 20);
			this.textBB.TabIndex = 2;
			this.textBB.TextChanged += new System.EventHandler(this.textBB_TextChanged);
			this.textBB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBB_KeyDown);
			// 
			// splitContainer
			// 
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.Location = new System.Drawing.Point(0, 24);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.listBB);
			this.splitContainer.Panel1.Controls.Add(this.textBB);
			this.splitContainer.Size = new System.Drawing.Size(589, 280);
			this.splitContainer.SplitterDistance = 196;
			this.splitContainer.TabIndex = 3;
			// 
			// listBB
			// 
			this.listBB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.listBB.CheckBoxes = true;
			this.listBB.Location = new System.Drawing.Point(3, 29);
			this.listBB.Name = "listBB";
			this.listBB.Size = new System.Drawing.Size(190, 248);
			this.listBB.TabIndex = 3;
			this.listBB.UseCompatibleStateImageBehavior = false;
			this.listBB.View = System.Windows.Forms.View.List;
			this.listBB.SelectedIndexChanged += new System.EventHandler(this.listBB_SelectedIndexChanged);
			this.listBB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBB_MouseDown);
			// 
			// MainDlg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(589, 304);
			this.Controls.Add(this.splitContainer);
			this.Controls.Add(this.menuStrip);
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip;
			this.Name = "MainDlg";
			this.Text = "STRING Homolog Interactions";
			this.Load += new System.EventHandler(this.MainDlg_Load);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel1.PerformLayout();
			this.splitContainer.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.TextBox textBB;
		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem wikiTableToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem queryInteractionsForSelectionToolStripMenuItem;
		private System.Windows.Forms.ListView listBB;
	}
}

