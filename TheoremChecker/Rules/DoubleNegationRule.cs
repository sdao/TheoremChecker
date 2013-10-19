using System;

namespace TheoremChecker
{
	public class DoubleNegationRule : IReplacementRule
	{
		public DoubleNegationRule (ProofLine doubleNegationLine)
		{
		}

		private readonly IStatement _DoubleNegationLine;

		public bool Validate(IStatement statement) {
			return false;
		}
	}
}

