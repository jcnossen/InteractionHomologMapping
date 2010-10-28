namespace InteractionMapping
{
	partial class WizardExport
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
			this.textCytoscapeServiceURL = new System.Windows.Forms.TextBox();
			this.buttonExportCytoscape = new System.Windows.Forms.Button();
			this.buttonExportToCSV = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textCyNetworkName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// textCytoscapeServiceURL
			// 
			this.textCytoscapeServiceURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.textCytoscapeServiceURL.Enabled = false;
			this.textCytoscapeServiceURL.Location = new System.Drawing.Point(164, 91);
			this.textCytoscapeServiceURL.Name = "textCytoscapeServiceURL";
			this.textCytoscapeServiceURL.Size = new System.Drawing.Size(280, 20);
			this.textCytoscapeServiceURL.TabIndex = 19;
			this.textCytoscapeServiceURL.Text = "http://localhost:9001/cytoscape/CytoscapeRPC";
			// 
			// buttonExportCytoscape
			// 
			this.buttonExportCytoscape.Location = new System.Drawing.Point(6, 39);
			this.buttonExportCytoscape.Name = "buttonExportCytoscape";
			this.buttonExportCytoscape.Size = new System.Drawing.Size(135, 23);
			this.buttonExportCytoscape.TabIndex = 20;
			this.buttonExportCytoscape.Text = "Export to cytoscape";
			this.buttonExportCytoscape.UseVisualStyleBackColor = true;
			this.buttonExportCytoscape.Click += new System.EventHandler(this.buttonExportCytoscape_Click);
			// 
			// buttonExportToCSV
			// 
			this.buttonExportToCSV.Location = new System.Drawing.Point(6, 18);
			this.buttonExportToCSV.Name = "buttonExportToCSV";
			this.buttonExportToCSV.Size = new System.Drawing.Size(141, 23);
			this.buttonExportToCSV.TabIndex = 21;
			this.buttonExportToCSV.Text = "Export to text";
			this.buttonExportToCSV.UseVisualStyleBackColor = true;
			this.buttonExportToCSV.Click += new System.EventHandler(this.buttonExportToCSV_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.buttonExportToCSV);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(459, 56);
			this.groupBox1.TabIndex = 22;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Text file export";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.textCyNetworkName);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.buttonExportCytoscape);
			this.groupBox2.Controls.Add(this.textCytoscapeServiceURL);
			this.groupBox2.Location = new System.Drawing.Point(3, 65);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(459, 117);
			this.groupBox2.TabIndex = 23;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Cytoscape Export";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 94);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(123, 13);
			this.label2.TabIndex = 24;
			this.label2.Text = "CytoscapeRPC Address:";
			// 
			// textCyNetworkName
			// 
			this.textCyNetworkName.Location = new System.Drawing.Point(164, 65);
			this.textCyNetworkName.Name = "textCyNetworkName";
			this.textCyNetworkName.Size = new System.Drawing.Size(280, 20);
			this.textCyNetworkName.TabIndex = 23;
			this.textCyNetworkName.Text = "STRING Interaction search";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 68);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(134, 13);
			this.label4.TabIndex = 22;
			this.label4.Text = "Cytoscape Network Name:";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(6, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(447, 18);
			this.label1.TabIndex = 21;
			this.label1.Text = "To make this work, make sure you have the CytoscapeRPC installed and running. ";
			// 
			// WizardExport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "WizardExport";
			this.Size = new System.Drawing.Size(465, 185);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox textCytoscapeServiceURL;
		private System.Windows.Forms.Button buttonExportCytoscape;
		private System.Windows.Forms.Button buttonExportToCSV;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textCyNetworkName;
		private System.Windows.Forms.Label label4;
	}
}
