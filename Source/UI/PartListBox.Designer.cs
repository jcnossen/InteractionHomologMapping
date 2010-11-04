namespace InteractionMapping.UI
{
	partial class PartListBox
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
			this.SuspendLayout();
			// 
			// PartListBox
			// 
			this.CheckBoxes = true;
			this.FullRowSelect = true;
			this.View = System.Windows.Forms.View.List;
			this.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.PartListBox_ItemChecked);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBB_MouseDown);
			this.ResumeLayout(false);

		}

		#endregion
	}
}
