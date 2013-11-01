using System;

namespace TheoremChecker
{
	public class DoubleNegationRule : ReplacementRule
	{
		public DoubleNegationRule (ProofLine doubleNegationLine) : base (doubleNegationLine) {}

		protected override IStatement Normalize (IStatement statement)
		{
			if (statement is NegationStatement) {
				NegationStatement ns = statement as NegationStatement;

				if (ns.NegatedStatement is NegationStatement) {
					NegationStatement innerNs = ns.NegatedStatement as NegationStatement;

					return innerNs.NegatedStatement;
				}
			}

			return statement;
		}

		public override string ToString ()
		{
			return "DN";
		}
	}
}

