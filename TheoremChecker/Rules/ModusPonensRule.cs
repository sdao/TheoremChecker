using System;

namespace TheoremChecker
{
	public class ModusPonensRule : IRule
	{
		public ModusPonensRule (ProofLine implication, ProofLine enteredAntecedent)
		{
			if (implication == null)
				throw new ArgumentNullException ("implication");
			if (enteredAntecedent == null)
				throw new ArgumentNullException ("enteredAntecedent");

			_Implication = implication;
			_EnteredAntecedent = enteredAntecedent;
		}

		private readonly ProofLine _Implication;
		public ProofLine Implication {
			get { return _Implication; }
		}

		private readonly ProofLine _EnteredAntecedent;
		public ProofLine EnteredAntecedent {
			get { return _EnteredAntecedent; }
		}

		public bool Validate(IStatement consequent) {
			var castImplication = Implication.Statement as ImplicationStatement;

			if (castImplication == null) {
				return false;
			} else {
				return castImplication.Antecedent.Equals(EnteredAntecedent.Statement) && castImplication.Consequent.Equals(consequent);
			}
		}

		public override string ToString ()
		{
			return "M.P.";
		}
	}
}

