namespace InteractionMapping
{
	partial class WizardEnterPartsPage
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
			this.textBB = new System.Windows.Forms.TextBox();
			this.buttonAddPart = new System.Windows.Forms.Button();
			this.buttonLoad = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.partListControl = new InteractionMapping.PartListControl();
			this.SuspendLayout();
			// 
			// textBB
			// 
			this.textBB.Location = new System.Drawing.Point(118, 43);
			this.textBB.Name = "textBB";
			this.textBB.Size = new System.Drawing.Size(143, 20);
			this.textBB.TabIndex = 2;
			// 
			// buttonAddPart
			// 
			this.buttonAddPart.Location = new System.Drawing.Point(3, 41);
			this.buttonAddPart.Name = "buttonAddPart";
			this.buttonAddPart.Size = new System.Drawing.Size(109, 23);
			this.buttonAddPart.TabIndex = 5;
			this.buttonAddPart.Text = "Add part by ID:";
			this.buttonAddPart.UseVisualStyleBackColor = true;
			this.buttonAddPart.Click += new System.EventHandler(this.buttonAddPart_Click);
			// 
			// buttonLoad
			// 
			this.buttonLoad.Location = new System.Drawing.Point(3, 12);
			this.buttonLoad.Name = "buttonLoad";
			this.buttonLoad.Size = new System.Drawing.Size(109, 23);
			this.buttonLoad.TabIndex = 6;
			this.buttonLoad.Text = "Load part list";
			this.buttonLoad.UseVisualStyleBackColor = true;
			this.buttonLoad.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(118, 12);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(114, 23);
			this.buttonSave.TabIndex = 7;
			this.buttonSave.Text = "Save part list";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(238, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(85, 23);
			this.button1.TabIndex = 8;
			this.button1.Text = "Clear list";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
			// 
			// partListControl
			// 
			this.partListControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.partListControl.Location = new System.Drawing.Point(3, 70);
			this.partListControl.Name = "partListControl";
			this.partListControl.Size = new System.Drawing.Size(339, 241);
			this.partListControl.TabIndex = 9;
			// 
			// WizardEnterPartsPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.partListControl);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.buttonLoad);
			this.Controls.Add(this.buttonAddPart);
			this.Controls.Add(this.textBB);
			this.Name = "WizardEnterPartsPage";
			this.Size = new System.Drawing.Size(345, 314);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBB;
		private System.Windows.Forms.Button buttonAddPart;
		private System.Windows.Forms.Button buttonLoad;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button button1;
		private PartListControl partListControl;
	}
}
