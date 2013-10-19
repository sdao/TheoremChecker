using System;

namespace TheoremChecker
{
	public class ModusTollensRule : IRule
	{
		public ModusTollensRule (ProofLine implication, ProofLine enteredNegatedConsequent)
		{
			if (implication == null)
				throw new ArgumentNullException ("implication");
			if (enteredNegatedConsequent == null)
				throw new ArgumentNullException ("enteredNegatedConsequent");

			_Implication = implication;
			_EnteredNegatedConsequent = enteredNegatedConsequent;
		}

		private readonly ProofLine _Implication;
		public ProofLine Implication {
			get { return _Implication; }
		}

		private readonly ProofLine _EnteredNegatedConsequent;
		public ProofLine EnteredNegatedConsequent {
			get { return _EnteredNegatedConsequent; }
		}

		public bool Validate(IStatement enteredLine) {
			var castImplication = Implication.Statement as ImplicationStatement;
			var castNegatedConsequent = EnteredNegatedConsequent.Statement as NegationStatement;
			var castEnteredLine = enteredLine as NegationStatement;

			if (castImplication == null || castNegatedConsequent == null || castEnteredLine == null) {
				return false;
			} else {
				return castEnteredLine.IsNegationOf(castImplication.Antecedent) &&
					castNegatedConsequent.IsNegationOf(castImplication.Consequent);
			}
		}

		public override string ToString ()
		{
			return "M.T.";
		}
	}
}

