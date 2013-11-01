using System;
using System.Collections.Generic;
using P = TheoremChecker.ProofHelper;

namespace TheoremChecker
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			List<ProofLine> proof = new List<ProofLine> ();
			proof.Add (P.Line (P.Letter ("a"), P.Premiss())); 								//0
			proof.Add (P.Line (P.Letter ("a"), P.Reit (proof [0]))); 						//1
			proof.Add (P.Line ("b".And("c"), P.Premiss())); 								//2
			proof.Add (P.Line (P.Letter ("c"), P.ConjElim (proof [2]))); 					//3
			proof.Add (P.Line (P.Letter ("c"), P.Reit (proof [3]))); 						//4
			proof.Add (P.Line ("a".And("a"), P.ConjIntr (proof [0], proof [0]))); 			//5
			proof.Add (P.Line ("a".And("a").And("c"), P.ConjIntr (proof [5], proof [4])));	//6
			proof.Add (P.Line (P.If ("c").Then ("d"), P.Premiss()));						//7
			proof.Add (P.Line (P.Not ("d"), P.Premiss()));									//8
			proof.Add (P.Line (P.Not ("c"), P.MT (proof [7], proof [8])));					//9
			proof.Add (P.Line (P.Not ("q".And(P.Not(P.Not("r")))), P.Premiss ()));			//10
			proof.Add (P.Line (P.Not ("q".And("r")), P.DN (proof [10])));					//11
			proof.Add (P.Line (P.Not ("c").Or("d"), P.Impl (proof [7])));					//12
			proof.Add (P.Line (P.If ("c").Then ("d"), P.Impl (proof[12])));					//13
			proof.Add (P.Line (P.Not ("q").Or (P.Not ("r")), P.DeM (proof [11])));			//14
			proof.Add (P.Line (P.Not ("q".And("r")), P.DeM (proof [14])));					//15

			Checker.Check (proof);
		}
	}
}
