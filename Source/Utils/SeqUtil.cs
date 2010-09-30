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
	public static class SeqUtil
	{
		public static string DNAToRNA(string dna) 
		{
			return dna.Replace('t', 'u');
		}

		public static string DNAToProtein(string dna)
		{
			return RNAToProtein(DNAToRNA(dna));
		}
		
		public static string RNAToProtein(string rna)
		{
			int pos = 0;
			char[] seq = new char[rna.Length/3];
			int x=0;

			rna = rna.ToUpper();

			while (pos < rna.Length-2) {
				seq[x++] = TranslateCodon(rna.Substring(pos, 3));
				pos += 3;
			}
			return new string(seq);
		}

		public static string CodonTable = @"
uuufuucfuualuuglucusuccsucasucgs
uauyuacyuaa.uag.ugucugccuga.uggw
cuulcuclcualcuglccupcccpccapccgp
cauhcachcaaqcagqcgurcgcrcgarcggr
auuiauciauaiaugmacutacctacatacgt
aaunaacnaaakaagkagusagcsagaraggr
guuvgucvguavgugvgcuagccagcaagcga
gaudgacdgaaegageggugggcgggaggggg
";

		static Dictionary<string, char> CodonToAA;

		public static char TranslateCodon(string c)
		{
			if (CodonToAA == null) {
				string ctbl = new string(CodonTable.ToCharArray().Where(x => !Char.IsWhiteSpace(x)).ToArray());
				CodonToAA = new Dictionary<string, char>();
				for(int i=0;i<64;i++) {
					string codon = ctbl.Substring(i * 4, 4).ToUpper();
					CodonToAA[codon.Substring(0, 3)] = codon[3];
				}
			}

			return CodonToAA[c];
		}
	}
}
