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
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace InteractionSearch.PartsRegistry
{
	[XmlRoot("rsbpml")]
	public class Root
	{
		[XmlArray("part_list")]
		public Part[] PartList;
	}

	[XmlType("part")]
	public class Part
	{
		// Fields
		[XmlElement("part_id")]
		public string ID;
		[XmlElement("part_name")]
		public string Name;
		[XmlElement("part_short_name")]
		public string ShortName;
		[XmlElement("part_short_desc")]
		public string ShortDesc;
		[XmlElement("part_type")]
		public string Type;
		[XmlElement("part_status")]
		public string Status;
		[XmlElement("part_results")]
		public string Results;
		[XmlElement("part_nickname")]
		public string Nickname;
		[XmlElement("part_rating")]
		public string Rating;
		[XmlElement("part_url")]
		public string URL;
		[XmlElement("part_entered")]
		public string Entered;
		[XmlElement("part_author")]
		public string Author;
		[XmlElement("part_quality")]
		public string Quality;

		// Lists
		[XmlArray("deep_subparts")]
		public SubPart[] DeepSubparts;
		[XmlArray("specified_subparts")]
		public SubPart[] SpecifiedSubparts;
		[XmlArray("specified_subscars")]
		public SubPart[] SpecifiedSubscars;

		[XmlArray("sequences")]
		[XmlArrayItem(typeof(string), ElementName = "seq_data")]
		public string[] Sequences;

		[XmlArray("categories")]
		[XmlArrayItem(typeof(string), ElementName = "category")]
		public string[] Categories;

		public override string ToString()
		{
			return Name;
		}

		public string Sequence
		{
			get {
				StringBuilder sb = new StringBuilder();
				foreach (string s in Sequences)
					sb.Append(s.Replace("\n",""));
				return sb.ToString();
			}
		}
	}

	[XmlType("subpart")]
	public class SubPart
	{
		[XmlElement("part_id")]
		public string ID;
		[XmlElement("part_name")]
		public string Name;
		[XmlElement("part_short_desc")]
		public string ShortDesc;
		[XmlElement("part_type")]
		public string Type;
		[XmlElement("part_nickname")]
		public string Nickname;

		public override string ToString()
		{
			return Name;
		}
	}

	[XmlType("feature")]
	public class Feature
	{
		[XmlElement("id")]
		public int ID;
		[XmlElement("title")]
		public string Title;
		[XmlElement("type")]
		public string Type;
		[XmlElement("direction")]
		public string Direction;
		[XmlElement("startpos")]
		public int StartPos;
		[XmlElement("endpos")]
		public int endpos;
	}
}
