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
using System.IO;
using System.Data;

namespace InteractionMapping
{
	public class PartList
	{
		public class Part : ISequence {
			public string stringID;

			[XmlIgnore]
			public PartsRegistry.Part data;
			public string name;
			public bool enabled;
			public string customSequence;

			public override string ToString()
			{
				return name + (data != null ? " - " + data.ShortDesc : "");
			}

			#region ISequence Members

			public string DNASequence
			{
				get { return data.Sequence; }
			}

			#endregion
		}

		public List<Part> parts = new List<Part>();

		static XmlSerializer serializer;

		public XmlSerializer Serializer
		{
			get
			{
				if (serializer != null)
					serializer = new XmlSerializer(typeof(PartList));
				return serializer;
			}
		}

		public static PartList LoadXML(string file)
		{
			XmlSerializer s = new XmlSerializer(typeof(PartList));
			using (FileStream stream = File.Open(file, FileMode.Open)) {
				return (PartList)s.Deserialize(stream);
			}
		}

		public void SaveXML(string file)
		{
			using (FileStream stream = File.Open(file, FileMode.Create)) {
				XmlSerializer s = new XmlSerializer(typeof(PartList));
				s.Serialize(stream, this);
			}
		}

		public void LoadParts(Action<string> cb) 
		{
			int count = 0;
			List<string> errs = new List<string>();

			foreach (Part part_ in parts) {
				Part part = part_;

				BiobrickCache.Instance.GetPart(part.name, (p, e) => {
					part.data = p;
					if (p == null)
						errs.Add(e.Message);
					count++;
					if (count == parts.Count)
						cb(string.Join("\n", errs.ToArray()));
				});
			}
		}

		public InteractionSet BuildInteractionSet()
		{
			return BuildInteractionSet(parts);
		}

		public static InteractionSet BuildInteractionSet(IEnumerable<Part> parts)
		{
			InteractionSet set = new InteractionSet();

			foreach (PartList.Part part in parts)
			{
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
			return set;
		}
	}
}
