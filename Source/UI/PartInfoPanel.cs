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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InteractionMapping
{
	public partial class PartInfoPanel : UserControl
	{
		const int EColiK12 = 83333;
		PartList.Part part;

		public PartInfoPanel()
		{
			InitializeComponent();

			tabControl.SelectedIndex = 1;
		}

		public void SetPart(PartList.Part part) 
		{
			this.part = part;
			var d = part.data;
			labelName.Text = d.ShortName;
			labelDesc.Text = d.ShortDesc;
			textStringID.Text = part.stringID;

			textDNA.Text = d.Sequence;
			textAA.Text = SeqUtil.RNAToProtein(SeqUtil.DNAToRNA(d.Sequence)).ToUpper();
		}

		private void textStringID_TextChanged(object sender, EventArgs e)
		{
			part.stringID = textStringID.Text;
		}

		private void labelName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Util.OpenWebAddr(BiobrickCache.PartRegistryLink(part.name));
		}

		private void buttonOpenStringWeb_Click(object sender, EventArgs e)
		{
			string url = string.Format("http://string-db.org/version_8_3/newstring_cgi/show_network_section.pl?identifier={0}&all_channels_on=1&interactive=yes&network_flavor=evidence&targetmode=proteins", part.stringID);

			Util.OpenWebAddr(url);
		}
	}
}
