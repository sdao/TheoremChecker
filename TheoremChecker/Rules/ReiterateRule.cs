using System;

namespace TheoremChecker
{
	public class ReiterateRule : IRule
	{
		public ReiterateRule (ProofLine lineToReiterate)
		{
			if (lineToReiterate == null)
				throw new ArgumentNullException ("lineToReiterate");

			_LineReiterated = lineToReiterate;
		}
		
		private readonly ProofLine _LineReiterated;
		public ProofLine LineReiterated {
			get {
				return _LineReiterated;
			}
		}

		public bool Validate(IStatement statement) {
			return _LineReiterated.Statement.Equals (statement);
		}

		public override string ToString ()
		{
			return "Reit.";
		}
	}
}

