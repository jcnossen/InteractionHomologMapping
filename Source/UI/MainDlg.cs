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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InteractionMapping
{
	public partial class MainDlg : Form
	{
		PartList partList = new PartList();

		public MainDlg(string[] args)
		{
			InitializeComponent();

			if (args.Length > 0)
				LoadFile(args[0]);
		}

		void LoadFile(string file)
		{
			PartList partList = PartList.LoadXML(file);

			partList.LoadParts(delegate
			{
				this.partList = partList;
				UpdateView();
			});
		}

		void UpdateView()
		{
			listBB.Items.Clear();
			foreach (PartList.Part p in partList.parts) {
				var lvi = new ListViewItem(p.ToString()) { Tag = p };
				lvi.Checked=true;
				listBB.Items.Add(lvi);
			}
		}

		private void MainDlg_Load(object sender, EventArgs e)
		{
			UpdateView();
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			partList = new PartList();

			UpdateView();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var ofd = new OpenFileDialog()
			{
				Filter = "Biobrick List XML (*.xml)|*.xml",
				Title = "Select assembly to load"
			};

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				LoadFile(ofd.FileName);
			}
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var sfd = new SaveFileDialog()
			{
				Filter = "Biobrick List XML (*.xml)|*.xml",
				Title = "Enter filename to save"
			};

			if (sfd.ShowDialog() == DialogResult.OK) {
				partList.SaveXML(sfd.FileName);
			}
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void textBB_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBB_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && textBB.Text.Length > 4) {
				string bb = textBB.Text;
				BiobrickCache.Instance.GetPart(bb, (part, exc) => {
					if (part == null)
						MessageBox.Show(exc.Message);
					else {
						partList.parts.Add(new PartList.Part() {
							data = part,
							name = part.Name
						});
						UpdateView();
					}
				});
				textBB.Text = "";
			}
		}

		private void listBB_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listBB.Items.Count > 0 && listBB.SelectedIndices.Count > 0) {
				PartList.Part part = (PartList.Part)listBB.SelectedItems[0].Tag;

				if (splitContainer.Panel2.Controls.Count == 0)
				{
					var panel = new PartInfoPanel();
					panel.Dock = DockStyle.Fill;
					splitContainer.Panel2.Controls.Add(panel);
				}

				((PartInfoPanel)splitContainer.Panel2.Controls[0]).SetPart(part);
			}
		}

		private void wikiTableToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("{|");
			sb.AppendLine("|'''Biobrick'''");
			sb.AppendLine("|'''STRING Database ID'''");
			foreach (PartList.Part p in partList.parts)
			{
				string stringURL = string.Format("http://string-db.org/version_8_3/newstring_cgi/show_network_section.pl?identifier={0}&all_channels_on=1&interactive=yes&network_flavor=evidence&targetmode=proteins",
					p.stringID);

				sb.AppendLine("|-");
				sb.AppendLine(string.Format("|[{0} {1}]", BiobrickCache.PartRegistryLink(p.name), p.name));
				sb.AppendLine(string.Format("|[{0} {1}]", stringURL, p.stringID));
			}
			sb.AppendLine("|}");

			new TextBoxDlg(sb.ToString(), "Wiki table markup").ShowDialog();
		}

		private void queryInteractionsForSelectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			InteractionSet set = new InteractionSet();

			foreach (ListViewItem i in listBB.CheckedItems) {
//				if (!i.Checked) continue;
				PartList.Part part = (PartList.Part)i.Tag;
				Protein protein = new Protein();
				protein.stringExternalID = part.stringID;
				protein.sequence = part;
				protein.name = part.data.ShortDesc;

				protein.attributes["length"] = part.data.Sequence.Length.ToString();
				protein.attributes["biobrick"] = part.data.Name;
				protein.attributes["url"] = BiobrickCache.PartRegistryLink(part.data.Name);

				set.startProteins.Add(protein);
				set.proteins[part.stringID] = protein;
			}

			new InteractionQueryDlg(set).ShowDialog();
		}

		private void listBB_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
				new ContextMenu(new MenuItem[] {
					new MenuItem("Remove", new EventHandler((o,ea)=>{
						var partset = new HashSet<PartList.Part>(from ListViewItem l in listBB.SelectedItems select (PartList.Part)l.Tag);
						partList.parts.RemoveAll(p => partset.Contains(p));

						UpdateView();
					}))
				}).Show(listBB, e.Location);
		}

		private void nCBIBlastToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listBB.SelectedItems.Count == 0)
				return;

			var part = listBB.SelectedItems[0].Tag as PartList.Part;
			new BlastDlg(SeqUtil.DNAToProtein(part.DNASequence)).ShowDialog();
		}
	}
}
