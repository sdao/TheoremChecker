using System;

namespace TheoremChecker
{
	public class PremissRule : IRule
	{
		public PremissRule ()
		{
		}

		public bool Validate (IStatement statement) {
			return true;
		}

		public override string ToString ()
		{
			return string.Format ("Given");
		}
	}
}

