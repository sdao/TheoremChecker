using System;
using System.Collections.Generic;

namespace TheoremChecker
{
	public static class Checker
	{
		public static bool Check(List<ProofLine> proof) {
			for (int i = 0; i < proof.Count; ++i) {
				ProofLine line = proof [i];
				Console.Write ("[{0}] ", i);
				Console.WriteLine (line);

				if (!line.Justification.Validate (line.Statement)) {
					Console.WriteLine ("\t-> INVALID");
					return false;
				} else {
					Console.WriteLine ("\t-> VALID");
				}
			}

			return true;
		}
	}
}

