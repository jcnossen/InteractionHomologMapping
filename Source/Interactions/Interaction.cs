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

namespace InteractionMapping
{
	public interface ISequence
	{
		string DNASequence { get; }
	}

	public class Protein : IMappable<int>
	{
		/// <summary>
		/// External ID in string database format
		/// </summary>
		public string stringExternalID;

		/// <summary>
		/// ID in string db
		/// </summary>
		public int stringID;
		public int Key { get { return stringID; } }

		/// <summary>
		/// Sequence, if this was a search starting point
		/// </summary>
		public ISequence sequence;
		/// <summary>
		/// Name
		/// </summary>
		public string name;
		/// <summary>
		/// How well does this sequence correspond to the protein
		/// </summary>
		public float sequenceMatch;
		public List<Interaction> interactions = new List<Interaction>();

		public int speciesID;

		public bool fromHomolog = false;

		/// <summary>
		/// Optional attributes
		/// </summary>
		public Dictionary<string, string> attributes = new Dictionary<string, string>();

		public string PreferredName {
			get {
				string s;
				if (attributes.TryGetValue("preferredName", out s))
					return s;
				return "";
			}
		}

		public string Annotation
		{
			get
			{
				string s;
				if (attributes.TryGetValue("annotation", out s))
					return s;
				return "";
			}
		}
	}

	public class Interaction : IPair<Protein>
	{
		public Protein a, b;
		public float score;

		public Protein A { get { return a; } }
		public Protein B { get { return b; } }

		internal Protein GetOpposite(Protein s)
		{
			return (a == s) ? b : a;
		}
	}

	public class MappedInteraction : Interaction
	{
		public float homologyScore;
		public bool missing;
	}

	public class Homolog : IPair<Protein>
	{
		public Protein a, b;
		public float bitscore;
		public float evalue;

		public Protein A { get { return a; } }
		public Protein B { get { return b; } }

		public Protein GetOpposite(Protein interacting)
		{
			return (a == interacting) ? b : a;
		}
	}

	public class InteractionSet
	{
		public List<Interaction> interactions = new List<Interaction>();
		public List<Homolog> homologs = new List<Homolog>();
		public HashSet<Protein> startProteins = new HashSet<Protein>();
		public Dictionary<string, Protein> proteins = new Dictionary<string, Protein>();

		public Dictionary<int, Protein> IDsToProteinsMap()
		{
			Dictionary<int, Protein> map = new Dictionary<int, Protein>();

			foreach (Protein p in proteins.Values)
				map[p.stringID] = p;

			return map;
		}

		public AssociationMap<int, Interaction, Protein> InteractionMap()
		{
			return new AssociationMap<int, Interaction, Protein>(interactions);
		}

		public AssociationMap<int, Homolog, Protein> HomologMap()
		{
			return new AssociationMap<int, Homolog, Protein>(homologs);
		}

		public IEnumerable<MappedInteraction> GetMappedInteractions(bool includeMissing)
		{
			var interactionMap = InteractionMap();
			var homologMap = HomologMap();
			List<MappedInteraction> mappedInteractions = new List<MappedInteraction>();

			foreach (Protein s in startProteins) {
				foreach (Interaction i in interactionMap[s.stringID]) {
					Protein interacting = i.GetOpposite(s);
					if (startProteins.Contains(interacting))
						continue;

					bool missing = true;
					foreach (Homolog h in homologMap[interacting.stringID]) {
						Protein other = h.GetOpposite(interacting);

						mappedInteractions.Add(new MappedInteraction() {
							a = s,
							b = other, 
							score = i.score,
							homologyScore = h.bitscore
						});

						missing = false;
					}
					if (missing && includeMissing) {
						mappedInteractions.Add(new MappedInteraction() {
							a = s,
							b = interacting,
							score = i.score,
							homologyScore = 0,
							missing = true
						});
					}
				}
			}

			return mappedInteractions;
		}
	}
}
