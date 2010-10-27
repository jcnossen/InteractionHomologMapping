namespace InteractionMapping
{
	partial class PartListControl
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
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.labelHint = new System.Windows.Forms.Label();
			this.partListBox = new InteractionMapping.UI.PartListBox();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer
			// 
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.partListBox);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.labelHint);
			this.splitContainer.Size = new System.Drawing.Size(351, 230);
			this.splitContainer.SplitterDistance = 115;
			this.splitContainer.TabIndex = 5;
			// 
			// labelHint
			// 
			this.labelHint.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelHint.Location = new System.Drawing.Point(0, 0);
			this.labelHint.Name = "labelHint";
			this.labelHint.Size = new System.Drawing.Size(232, 230);
			this.labelHint.TabIndex = 0;
			this.labelHint.Text = "Click on a part to display information";
			this.labelHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// partListBox
			// 
			this.partListBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.partListBox.Location = new System.Drawing.Point(0, 0);
			this.partListBox.Name = "partListBox";
			this.partListBox.PartList = null;
			this.partListBox.Size = new System.Drawing.Size(115, 229);
			this.partListBox.TabIndex = 0;
			this.partListBox.SelectedIndexChanged += new System.EventHandler(this.listBB_SelectedIndexChanged);
			// 
			// PartListControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Name = "PartListControl";
			this.Size = new System.Drawing.Size(351, 230);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			this.splitContainer.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer;
		private InteractionMapping.UI.PartListBox partListBox;
		private System.Windows.Forms.Label labelHint;
	}
}
