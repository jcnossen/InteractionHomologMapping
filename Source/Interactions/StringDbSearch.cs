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
using System.Data;
using System.Xml.Serialization;
using System.IO;
using Npgsql;

namespace InteractionMapping
{
	[XmlRoot("dbconn")]
	public class StringConnectionSettings
	{
		public string host, user, password;
		public int port;
		public string database;
	}

	public class StringDatabaseSearch : IDisposable
	{
		NpgsqlConnection connection;

		public StringDatabaseSearch()
		{
			ConnectFromXml("StringDbSettings.xml");
		}

		public void ConnectFromXml(string file)
		{
			XmlSerializer s = new XmlSerializer(typeof(StringConnectionSettings));

			using (FileStream fs = File.OpenRead(file)) {
				var settings = (StringConnectionSettings)  s.Deserialize(fs);
				Connect(settings.host, settings.user, settings.password, settings.port);
			}
		}

		public void Connect(string addr, string user, string pass, int port)
		{
			string cstr = string.Format("User ID={0};Password={1};Host={2};Port={3};Database=string;",
				user, pass, addr, port);
			//		User ID=root;Password=myPassword;Host=localhost;Port=5432;Database=myDataBase; Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0;

			Connect(cstr);
		}

		void Connect(string connectionString) {
			connection = new NpgsqlConnection();
			connection.ConnectionString = connectionString;
			connection.Open();
		}

		public void Close() {
			connection.Close();
		}

		public IDataReader Query(string sql) 
		{
			using(var cmd = connection.CreateCommand()) {
			//	Console.WriteLine("SQL: " + sql);
				cmd.CommandText = sql;
				return cmd.ExecuteReader();
			}
		}

		public object QueryScalar(string sql)
		{
			using (var cmd = connection.CreateCommand()) {
			//	Console.WriteLine("SQL: " + sql);
				cmd.CommandText = sql;
				return cmd.ExecuteScalar();
			}
		}

		public int Execute(string sql)
		{
			using (var cmd = connection.CreateCommand())
			{
				cmd.CommandText = sql;
				return cmd.ExecuteNonQuery();
			}
		}

		public T[] QueryObjects<T>(string sql) where T:new()
		{
			List<T> rows = new List<T>();

			using (var r = Query(sql)) {
				while (r.Read()) {
					T row = new T();
					ReadRow(row, r);
					rows.Add(row);
				}
			}
			return rows.ToArray();
		}

		string ToDbField(string name)
		{
			string r = "";
			for(int i=0;i<name.Length;i++) {
				if (Char.IsUpper(name[i])) {
					r += "_" + Char.ToLower(name[i]);
				} else r += name[i];
			}
			return r;
		}

		void ReadRow<T>(T row, IDataReader r)
		{
			var fields = typeof(T).GetFields();
			for (int i = 0; i < fields.Length; i++) {
				string colname = ToDbField(fields[i].Name);
				fields[i].SetValue(row, r.GetValue(r.GetOrdinal(colname)));
			}
		}

		public dbSpecies[] LoadSpecies()
		{
			return QueryObjects<dbSpecies>("select * from items.species order by compact_name");
		}

		public class dbPPI 
		{
			public int proteinIdA;
			public int proteinIdB;
			public int speciesId;
			public int equivNscore;
			public int equivNscoreTransferred;
			public int equivFscore;
			public int equivPscore;
			public int equivHscore;
			public int arrayScore;
			public int arrayScoreTransferred;
			public int experimentalScore;
			public int experimentalScoreTransferred;
			public int databaseScore;
			public int databaseScoreTransferred;
			public int textminingScore;
			public int textminingScoreTransferred;
			public int combinedScore;
		}

		public class dbProtein
		{
			public int proteinId;
			public string proteinExternalId;
			public int speciesId;
			public int proteinSize;
			public string annotation;
			public string preferredName;
		}

		public class dbSpecies
		{
			public int speciesId;
			public string officialName;
			public string compactName;
			public string kingdom;
			public string type;

			public override string ToString()
			{
				return compactName;
			}
		}

		#region IDisposable Members

		public void Dispose()
		{
			if (connection != null) {
				connection.Dispose();
				connection = null;
			}
		}

		#endregion

		public int GetStringIDFromExternal(string externalID)
		{
			string sql = string.Format("select protein_id from items.proteins where protein_external_id = '{0}'", externalID);
			return (int)QueryScalar(sql);
		}

		void UpdateProtein(Protein prot, dbProtein dbp)
		{
			prot.stringExternalID = dbp.proteinExternalId;
			prot.stringID = dbp.proteinId;
			prot.speciesID = dbp.speciesId;

			if (prot.name == null)
				prot.name = dbp.preferredName;

			prot.attributes["proteinSize"] = dbp.proteinSize.ToString();
			prot.attributes["preferredName"] = dbp.preferredName;
			prot.attributes["annotation"] = dbp.annotation;
			prot.attributes["species"] = dbp.speciesId.ToString();
		}

		public void UpdateProtein(Protein prot)
		{
			UpdateProtein(prot, GetProteinByExternalID(prot.stringExternalID));
		}

		dbProtein GetProteinByExternalID(string externalID)
		{
			return QueryObjects<dbProtein>("select * from items.proteins where protein_external_id = '" + externalID + "'").FirstOrDefault();
		}

		/// <summary>
		/// Extend interactions
		/// </summary>
		/// <param name="set">The interaction set</param>
		/// <param name="queryset">Subset of the proteins in the interactions set</param>
		public void ExtendInteractions(InteractionSet set, IEnumerable<Protein> queryset, float minScore, 
																		Action<Protein, Protein, string> logcb) {
			//Dictionary<int, Protein> idents = set.IDsToProteinsMap();
			var interactionMap = set.InteractionMap();
			
			foreach (Protein p in queryset) {
				Console.WriteLine("Finding interactions with " + p.stringExternalID);

				StringDatabaseSearch.dbPPI[] ppi = QueryObjects<StringDatabaseSearch.dbPPI>(
					string.Format("select * from network.protein_protein_links " +
					"where protein_id_a = {0} order by combined_score desc", p.stringID));

				// See if this interaction already exists in the set
				foreach (var i in ppi) {
					Interaction ia = interactionMap.Get(p.stringID, i.proteinIdB);
					float score = i.combinedScore * 0.001f;

					if (ia != null || score < minScore)
						continue;

					ia = new Interaction();
					ia.score = score;
					ia.a = p;

					dbProtein protB = QueryObjects<dbProtein>("select * from items.proteins where protein_id = '" + i.proteinIdB + "'").FirstOrDefault();
					ia.b = new Protein();
					UpdateProtein(ia.b, protB);

					if (!set.proteins.ContainsKey(ia.b.stringExternalID)) {
						set.proteins[ia.b.stringExternalID] = ia.b;
					}
					else {
						// already exists
						ia.b = set.proteins[ia.b.stringExternalID];
					}
					Console.WriteLine("Interaction between: " + ia.a.name + " and " + ia.b.name);

					set.interactions.Add(ia);
					interactionMap.Add(ia);

					logcb(ia.a, ia.b, "Interaction between: " + ia.a.name + " and " + ia.b.name);
				}
			}
		}

		class HomologQuery {
			public string protein_annotation;
			public int protein_size;
			public int protein_id;
			public float norm_score;
			public int alignment_length;
		}

		public void ExtendBestHomologs(InteractionSet set, IEnumerable<Protein> queryList, 
															int speciesID, float minscore, Action<Protein, Protein, string> logcb)
		{
			var homologMap = set.HomologMap();

			foreach (Protein prot in queryList) {
				if (prot.speciesID == speciesID) {
					Console.WriteLine("Skipping " + prot.name + " as it is already in the same species: " + speciesID);
					continue;
				}

				string sql = string.Format(@"SELECT 
					proteins.annotation as protein_annotation, 
					proteins.protein_size as protein_size,
					best_hit_protein_id as protein_id, 
					best_hit_normscore as norm_score, 
					best_hit_alignment_length as alignment_length
					FROM homology.best_hit_per_species, items.proteins 
					WHERE best_hit_per_species.best_hit_protein_id = proteins.protein_id 
					AND best_hit_per_species.protein_id = {0} 
					AND best_hit_per_species.species_id = {1}
					ORDER BY best_hit_normscore DESC", prot.stringID, speciesID);

				HomologQuery[] hits = QueryObjects<HomologQuery>(sql);

				foreach (var hq in hits) {
					Homolog cmp = homologMap.Get(prot.stringID, hq.protein_id);

					if (cmp != null)
						continue; // already known

					if (hq.norm_score < minscore)
						continue;

					Homolog h = new Homolog()
					{
						a = prot,
						bitscore = hq.norm_score,
						evalue = 0
					};

					dbProtein protB = QueryObjects<dbProtein>("select * from items.proteins where protein_id = '" + hq.protein_id + "'").FirstOrDefault();
					h.b = new Protein() { fromHomolog = true };
					UpdateProtein(h.b, protB);

					if (!set.proteins.ContainsKey(h.b.stringExternalID))
					{
						set.proteins[h.b.stringExternalID] = h.b;
						set.homologs.Add(h);
						homologMap.Add(h);

						logcb(h.a, h.b, "Homolog Mapping: " + h.a.name + " to " + h.b.name + 
							"; Bitscore: " + hq.norm_score + "; AlignLen: " + hq.alignment_length);
					}
				}
			}
		}

	}
}
