using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InteractionMapping
{
	public partial class PartListControl : UserControl
	{
		PartInfoPanel partInfoPanel;

		public PartList PartList{
			get { return partListBox.PartList; }
			set { partListBox.PartList=value; }
		}

		public PartListControl()
		{
			InitializeComponent();
		}


		private void listBB_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (partListBox.Items.Count > 0 && partListBox.SelectedIndices.Count > 0)
			{
				PartList.Part part = partListBox.SelectedParts[0];

				if (partInfoPanel == null)
				{
					var panel = new PartInfoPanel();
					panel.Dock = DockStyle.Fill;
					splitContainer.Panel2.Controls.Clear();
					splitContainer.Panel2.Controls.Add(panel);
					partInfoPanel = panel;
				}

				partInfoPanel.SetPart(part);
			}
		}
	}
}
