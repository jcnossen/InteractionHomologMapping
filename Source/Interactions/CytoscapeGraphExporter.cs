using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InteractionMapping
{
	class CytoscapeGraphExporter
	{
		class GraphEdge
		{
			public Protein a, b;
			public string type;
			public float strength;
		}

		public string URL;
		public int destSpeciesID;
		public InteractionSet set;

		public CytoscapeGraphExporter() {
		}

		public void Export(InteractionSet set, bool showOriginal, bool showMissing)
		{
			this.set = set;

			using (CytoscapeRPC.cytoscape.CytoscapeService ct = new CytoscapeRPC.cytoscape.CytoscapeService()) {
				ct.Url = URL;

				List<GraphEdge> edges = new List<GraphEdge>();
				if (showOriginal)
					edges.AddRange(GetOriginalInteractions());
				else
					edges.AddRange(GetMappedInteractions(showMissing));

				HashSet<Protein> nodes = new HashSet<Protein>();

				foreach (GraphEdge ge in edges) {
					if (!nodes.Contains(ge.a))
						nodes.Add(ge.a);
					if (!nodes.Contains(ge.b))
						nodes.Add(ge.b);
				}

				// Also add all the start proteins even if they have no edges
				foreach (Protein p in set.startProteins)
					nodes.Add(p);

				string ctNetworkID = null;

				if (ctNetworkID == null)
					ctNetworkID = ct.createNetwork("STRING Interaction search");

				ct.setCurrentNetwork(ctNetworkID);

				foreach (Protein p in nodes) {
					string nodeID = p.stringExternalID;

					if (ct.nodeExists(ctNetworkID, nodeID))
						continue;

					ct.createNodeInCurrent(p.stringExternalID);
					if (!p.attributes.ContainsKey("label"))
						ct.addStringNodeAttribute("label", nodeID, p.name);

					ct.addStringNodeAttribute("string_id", nodeID, nodeID);
					foreach (var kv in p.attributes)
						ct.addStringNodeAttribute(kv.Key, nodeID, kv.Value);
				}
				ct.setNodeFillColor(ctNetworkID, set.startProteins.Select(p => p.stringExternalID).ToArray(), 0, 0, 255);

				string[] edgeIDs = ct.createEdges(ctNetworkID,
					(from e in edges select e.a.stringExternalID).ToArray(),
					(from e in edges select e.b.stringExternalID).ToArray(),
					Util.RepeatValue(edges.Count, "interaction"),
					Util.RepeatValue(edges.Count, true), true);
				ct.addStringEdgeAttributes("mappingType", edgeIDs,
					(from e in edges select e.type).ToArray());
				ct.addDoubleEdgeAttributes("strength", edgeIDs,
					(from e in edges select (double)e.strength).ToArray());

				ct.setNodeLabel(ctNetworkID, "label", "?", "default");

				//string[] modifiables = ct.getVisualStyleModifiables();
				//Array.ForEach(modifiables, m => Console.WriteLine(m));
				ct.discreteMapper(ctNetworkID, "default", "mappingType", "Edge Color", "0,0,0",
					new string[] { "MappedInteraction", "MissingHomolog", "NativeInteraction", "LocalInteraction" },
					new string[] { "0,255,0", "255,0,0", "100, 100, 100", "150, 150, 150" });

				if (showMissing) {
					ct.discreteMapper(ctNetworkID, "default", "missing", "Node Color", "0,255,0",
						new string[] { "yes" },
						new string[] { "255,100,100" });
				}
			}


		}
		private IEnumerable<GraphEdge> GetMappedInteractions(bool showMissing)
		{
			var interactionMap = set.InteractionMap();
			var homologMap = set.HomologMap();

			List<GraphEdge> edges = new List<GraphEdge>();
			Console.WriteLine("ProteinA; ProteinB; Bitscore; InteractionScore; Name");
			foreach (Protein prot in set.startProteins)
				foreach (Interaction interaction in interactionMap[prot.stringID]) {
					var homologs = homologMap[interaction.b.stringID];

					foreach (Homolog h in homologs) {
						edges.Add(new GraphEdge() {
							a = prot,
							b = h.B,
							strength = interaction.score * h.bitscore,
							type = "MappedInteraction"
						});
						Console.WriteLine(string.Format("{0}; {1}; {2}; {3}; {4}", 
							prot.stringExternalID, h.B.stringExternalID, h.bitscore, 
							interaction.score, h.b.name));
					}

					if (set.startProteins.Contains(interaction.b) && prot != interaction.b) {
						edges.Add(new GraphEdge() {
							a = prot,
							b = interaction.b,
							strength = interaction.score,
							type = "NativeInteraction"
						});
					}
					else if (showMissing && homologs.Count == 0) {
						var missing = new Protein() {
							name = "Missing: " + interaction.b.name,
							speciesID = destSpeciesID,
							stringID = 0,
							stringExternalID = interaction.b.stringExternalID
						};
						missing.attributes["label"] = interaction.b.name;
						missing.attributes["missing"] = "yes";
						edges.Add(new GraphEdge() {
							a = prot,
							b = missing,
							strength = 0,
							type = "MissingHomolog"
						});
					}
				}
			return edges;
		}

		private IEnumerable<GraphEdge> GetOriginalInteractions()
		{
			return set.interactions.Select(i => new GraphEdge() {
				a = i.a,
				b = i.b,
				strength = i.score,
				type = i.b.fromHomolog ? "LocalInteraction" : "NativeInteraction"
			}).Concat(
				set.homologs.Select(h => new GraphEdge() {
					a = h.a, b = h.b,
					strength = h.bitscore,
					type = "Homolog"
				})
			);
		}

	}
}
