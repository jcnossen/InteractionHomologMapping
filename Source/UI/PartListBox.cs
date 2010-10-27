using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InteractionMapping.UI
{
	public partial class PartListBox : ListView
	{
		[Browsable(false)]
		PartList partList;

		public PartList.Part[] Parts
		{
			get {
				return Items.Cast<ListViewItem>().Select(lvi => (PartList.Part)lvi.Tag).ToArray();
			}
		}

		public PartList.Part[] SelectedParts
		{
			get	{
				return SelectedItems.Cast<ListViewItem>().Select(lvi => (PartList.Part)lvi.Tag).ToArray();
			}
		}

		public PartListBox()
		{
			InitializeComponent();
		}

		public new void Update()
		{
			Items.Clear();
			if (partList == null)
				return;
			foreach (PartList.Part p in partList.parts)
				Items.Add(new ListViewItem(p.ToString()) { Tag = p, Checked = p.enabled });
		}

		public PartList PartList
		{
			get { return partList; }
			set { partList = value; Update();  }
		}
		
		private void listBB_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right) {
				var selParts = new HashSet<PartList.Part>(SelectedParts);

				new ContextMenu(new MenuItem[] {
					new MenuItem("Remove", new EventHandler((o,ea)=>{
						partList.parts.RemoveAll(p => selParts.Contains(p));
						Update();
					}))
				}).Show(this, e.Location);
			}
		}

		private void PartListBox_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			PartList.Part part = (PartList.Part)e.Item.Tag;
			part.enabled = e.Item.Checked;
		}

	}
}
