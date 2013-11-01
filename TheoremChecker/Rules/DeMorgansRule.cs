using System;

namespace TheoremChecker
{
	public class DeMorgansRule : ReplacementRule
	{
		public DeMorgansRule (ProofLine templateLine) : base (templateLine) {}

		protected override IStatement Normalize (IStatement statement)
		{
			if (statement is NegationStatement) {
				NegationStatement ns = statement as NegationStatement;

				if (ns.NegatedStatement is ConjunctionStatement) {
					ConjunctionStatement innerConj = ns.NegatedStatement as ConjunctionStatement;

					return new DisjunctionStatement(new NegationStatement(innerConj.LeftHand), new NegationStatement(innerConj.RightHand));
				} else if (ns.NegatedStatement is DisjunctionStatement) {
					DisjunctionStatement innerDisj = ns.NegatedStatement as DisjunctionStatement;

					return new ConjunctionStatement(new NegationStatement(innerDisj.LeftHand), new NegationStatement(innerDisj.RightHand));
				}
			}

			return statement;
		}

		public override string ToString ()
		{
			return "DeM";
		}
	}
}

