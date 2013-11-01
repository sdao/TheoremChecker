using System;

namespace TheoremChecker
{
	public class MaterialImplicationRule : ReplacementRule
	{
		public MaterialImplicationRule (ProofLine templateLine) : base (templateLine) {}

		protected override IStatement Normalize (IStatement statement)
		{
			if (statement is ImplicationStatement) {
				ImplicationStatement impl = statement as ImplicationStatement;

				return new DisjunctionStatement (new NegationStatement (impl.Antecedent), impl.Consequent);
			}

			return statement;
		}

		public override string ToString ()
		{
			return "Impl.";
		}
	}
}

