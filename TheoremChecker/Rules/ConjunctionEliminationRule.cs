using System;

namespace TheoremChecker
{
	public class ConjunctionEliminationRule : IRule
	{
		public ConjunctionEliminationRule (ProofLine originalConjunction)
		{
			if (originalConjunction == null)
				throw new ArgumentNullException ("originalConjunction");

			_OriginalConjunction = originalConjunction;
		}

		private readonly ProofLine _OriginalConjunction;
		public ProofLine OriginalConjunction {
			get {
				return _OriginalConjunction;
			}
		}

		public bool Validate(IStatement statement) {
			var castStatement = _OriginalConjunction.Statement as ConjunctionStatement;

			if (castStatement == null) {
				return false;
			} else {
				return castStatement.LeftHand.Equals (statement) || castStatement.RightHand.Equals (statement);
			}
		}

		public override string ToString ()
		{
			return "Conj. Elim.";
		}
	}
}

