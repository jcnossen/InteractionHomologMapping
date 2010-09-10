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
using System.IO;
using System.Net;

using System.Xml.Serialization;

namespace InteractionMapping
{
	using Root = PartsRegistry.Root;
	using Part = PartsRegistry.Part;

	class BiobrickCache
	{
		static BiobrickCache instance = new BiobrickCache();
		XmlSerializer xmlSerializer;
		Dictionary<string, Part> parts = new Dictionary<string, Part>();

		public static BiobrickCache Instance
		{
			get {	return instance; }
		}

		const string cacheDir = "PartsCache\\";

		BiobrickCache()
		{
			xmlSerializer = new XmlSerializer(typeof(PartsRegistry.Root));

			if (!Directory.Exists(cacheDir))
				Directory.CreateDirectory(cacheDir);
		}

		public void GetPart(string name, Action<Part, Exception> onFound)
		{
			Part part;

			if (parts.TryGetValue(name, out part)) {
				onFound(part, null);
				return;
			}

			// check disk
			string filename = cacheDir + name + ".xml";
			if (File.Exists(filename)) {
				using (FileStream s = File.OpenRead(filename)) {
					part = ((Root)xmlSerializer.Deserialize(s)).PartList[0];
					parts[name] = part;
					onFound(part, null);
					return;
				}
			}

			// download
			WebClient wc = new WebClient();
			wc.DownloadStringCompleted += (sender, e) => {
				if (e.Error != null) {
					onFound(null, e.Error);
					return;
				}

				using (StringReader r = new StringReader(e.Result)) {
					var root = (Root)xmlSerializer.Deserialize(r);
					if (root == null || root.PartList == null || root.PartList.Length == 0) {
						onFound(null, new InvalidDataException("Invalid biobrick data for " + name));
						return;
					}
					if (Directory.Exists(cacheDir))
						File.WriteAllText(filename, e.Result);
			
					part = root.PartList[0];
				}
				parts[name] = part;
				onFound(part, null);
			};
			wc.DownloadStringAsync(new Uri(PartXmlLink(name)));
		}

		#region utils

		public static string BBCheck(string name)
		{
			if (name.Substring(0, 4) != "BBa_" && name.Substring(0, 3) != "pSB")
				name += "BBa_";
			return name;
		}

		public static string PartXmlLink(string name)
		{
			name = BBCheck(name);
			return "http://partsregistry.org/xml/part." + name;
		}

		public static string PartWikiLink(string name)
		{
			name = BBCheck(name);
			return "http://partsregistry.org/wiki/index.php?title=Part:" + name;
		}

		public static string PartRegistryLink(string name)
		{
			name = BBCheck(name);
			return "http://partsregistry.org/Part:" + name;
		}
		#endregion
	}
}
