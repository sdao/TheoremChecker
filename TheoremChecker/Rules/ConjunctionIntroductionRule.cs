using System;

namespace TheoremChecker
{
	public class ConjunctionIntroductionRule : IRule
	{
		public ConjunctionIntroductionRule (ProofLine line1, ProofLine line2)
		{
			if (line1 == null)
				throw new ArgumentNullException ("line1");
			if (line2 == null)
				throw new ArgumentNullException ("line2");

			_Original1 = line1;
			_Original2 = line2;
		}

		private readonly ProofLine _Original1;
		public ProofLine Original1 {
			get {
				return _Original1;
			}
		}

		private readonly ProofLine _Original2;
		public ProofLine Original2 {
			get {
				return _Original2;
			}
		}

		public bool Validate(IStatement statement) {
			var castStatement = statement as ConjunctionStatement;

			if (castStatement == null) {
				return false;
			} else {
				return (castStatement.LeftHand.Equals (_Original1.Statement) && castStatement.RightHand.Equals (_Original2.Statement)) ||
					(castStatement.LeftHand.Equals (_Original2.Statement) && castStatement.RightHand.Equals (_Original1.Statement));
			}
		}

		public override string ToString ()
		{
			return "Conj. Intr.";
		}
	}
}

