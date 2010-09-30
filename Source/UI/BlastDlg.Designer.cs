namespace InteractionMapping
{
	partial class BlastDlg
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
			this.txtSeq = new System.Windows.Forms.TextBox();
			this.buttonBlast = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtSeq
			// 
			this.txtSeq.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txtSeq.Location = new System.Drawing.Point(12, 71);
			this.txtSeq.Multiline = true;
			this.txtSeq.Name = "txtSeq";
			this.txtSeq.Size = new System.Drawing.Size(382, 173);
			this.txtSeq.TabIndex = 0;
			// 
			// buttonBlast
			// 
			this.buttonBlast.Location = new System.Drawing.Point(12, 12);
			this.buttonBlast.Name = "buttonBlast";
			this.buttonBlast.Size = new System.Drawing.Size(139, 29);
			this.buttonBlast.TabIndex = 1;
			this.buttonBlast.Text = "Blast";
			this.buttonBlast.UseVisualStyleBackColor = true;
			this.buttonBlast.Click += new System.EventHandler(this.buttonBlast_Click);
			// 
			// BlastDlg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(406, 256);
			this.Controls.Add(this.buttonBlast);
			this.Controls.Add(this.txtSeq);
			this.Name = "BlastDlg";
			this.Text = "NCBI Blast";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtSeq;
		private System.Windows.Forms.Button buttonBlast;
	}
}