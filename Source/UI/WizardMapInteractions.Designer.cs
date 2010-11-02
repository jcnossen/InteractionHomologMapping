namespace InteractionMapping
{
	partial class WizardMapInteractions
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
			this.textMinHomolog = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textMinIntAct = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.comboSpecies = new System.Windows.Forms.ComboBox();
			this.labelInProgress = new System.Windows.Forms.Label();
			this.treeView = new System.Windows.Forms.TreeView();
			this.label5 = new System.Windows.Forms.Label();
			this.buttonMapInteractions = new System.Windows.Forms.Button();
			this.buttonClear = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textMinHomolog
			// 
			this.textMinHomolog.Location = new System.Drawing.Point(154, 60);
			this.textMinHomolog.Name = "textMinHomolog";
			this.textMinHomolog.Size = new System.Drawing.Size(77, 20);
			this.textMinHomolog.TabIndex = 15;
			this.textMinHomolog.Text = "0.5";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(123, 13);
			this.label3.TabIndex = 14;
			this.label3.Text = "Minimum homolog score:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(132, 13);
			this.label2.TabIndex = 13;
			this.label2.Text = "Minimum interaction score:";
			// 
			// textMinIntAct
			// 
			this.textMinIntAct.Location = new System.Drawing.Point(154, 34);
			this.textMinIntAct.Name = "textMinIntAct";
			this.textMinIntAct.Size = new System.Drawing.Size(77, 20);
			this.textMinIntAct.TabIndex = 12;
			this.textMinIntAct.Text = "0.5";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 89);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 13);
			this.label1.TabIndex = 19;
			this.label1.Text = "Species:";
			// 
			// comboSpecies
			// 
			this.comboSpecies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboSpecies.FormattingEnabled = true;
			this.comboSpecies.Location = new System.Drawing.Point(74, 86);
			this.comboSpecies.Name = "comboSpecies";
			this.comboSpecies.Size = new System.Drawing.Size(268, 21);
			this.comboSpecies.TabIndex = 18;
			this.comboSpecies.SelectedIndexChanged += new System.EventHandler(this.comboSpecies_SelectedIndexChanged);
			// 
			// labelInProgress
			// 
			this.labelInProgress.AutoSize = true;
			this.labelInProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelInProgress.Location = new System.Drawing.Point(237, 34);
			this.labelInProgress.Name = "labelInProgress";
			this.labelInProgress.Size = new System.Drawing.Size(120, 13);
			this.labelInProgress.TabIndex = 22;
			this.labelInProgress.Text = "Query In Progress...";
			this.labelInProgress.Visible = false;
			// 
			// treeView
			// 
			this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.treeView.Location = new System.Drawing.Point(0, 139);
			this.treeView.Name = "treeView";
			this.treeView.PathSeparator = "/";
			this.treeView.Size = new System.Drawing.Size(458, 163);
			this.treeView.TabIndex = 23;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(12, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(386, 13);
			this.label5.TabIndex = 24;
			this.label5.Text = "Make sure that StringDbSettings.xml contains the right information!";
			// 
			// buttonMapInteractions
			// 
			this.buttonMapInteractions.Location = new System.Drawing.Point(3, 109);
			this.buttonMapInteractions.Name = "buttonMapInteractions";
			this.buttonMapInteractions.Size = new System.Drawing.Size(145, 24);
			this.buttonMapInteractions.TabIndex = 25;
			this.buttonMapInteractions.Text = "Map interactions";
			this.buttonMapInteractions.UseVisualStyleBackColor = true;
			this.buttonMapInteractions.Click += new System.EventHandler(this.buttonMapInteractions_Click);
			// 
			// buttonClear
			// 
			this.buttonClear.Location = new System.Drawing.Point(154, 109);
			this.buttonClear.Name = "buttonClear";
			this.buttonClear.Size = new System.Drawing.Size(118, 23);
			this.buttonClear.TabIndex = 26;
			this.buttonClear.Text = "Clear";
			this.buttonClear.UseVisualStyleBackColor = true;
			this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
			// 
			// WizardMapInteractions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.buttonClear);
			this.Controls.Add(this.buttonMapInteractions);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.treeView);
			this.Controls.Add(this.labelInProgress);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboSpecies);
			this.Controls.Add(this.textMinHomolog);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textMinIntAct);
			this.Name = "WizardMapInteractions";
			this.Size = new System.Drawing.Size(461, 305);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textMinHomolog;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textMinIntAct;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboSpecies;
		private System.Windows.Forms.Label labelInProgress;
		private System.Windows.Forms.TreeView treeView;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button buttonMapInteractions;
		private System.Windows.Forms.Button buttonClear;
	}
}
