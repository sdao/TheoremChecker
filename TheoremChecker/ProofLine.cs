using System;

namespace TheoremChecker
{
	public class ProofLine
	{
		public ProofLine (IStatement statement, IRule justification)
		{
			if (statement == null)
				throw new ArgumentNullException ("statement");

			if (justification == null)
				throw new ArgumentNullException ("justification");

			_Statement = statement;
			_Justification = justification;
		}

		private readonly IStatement _Statement;
		public IStatement Statement {
			get {
				return _Statement;
			}
		}

		private readonly IRule _Justification;
		public IRule Justification {
			get {
				return _Justification;
			}
		}

		public override string ToString ()
		{
			return String.Format ("{0} ({1})", Statement.ToString (), Justification.ToString ());
		}
	}
}

