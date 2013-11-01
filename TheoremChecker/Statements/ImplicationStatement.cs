using System;

namespace TheoremChecker
{
	public class ImplicationStatement : ConnectiveStatement
	{
		public ImplicationStatement(IStatement antecedent, IStatement consequent) : base(antecedent, consequent) {}

		public IStatement Antecedent {
			get {
				return LeftHand;
			}
		}

		public IStatement Consequent {
		get {
				return RightHand;
			}
		}

		public override bool Equals (object obj)
		{
			var castObj = obj as ImplicationStatement;

			if (castObj == null)
				return false;
			else
				return Object.Equals (castObj.Antecedent, Antecedent) && Object.Equals (castObj.Consequent, Consequent);
		}

		public override string ToString ()
		{
			return string.Format ("({0} \x2192 {1})", Antecedent, Consequent);
		}

		public override ConnectiveStatement Derive (Func<IStatement, IStatement> leftDerivation, Func<IStatement, IStatement> rightDerivation)
		{
			return new ImplicationStatement (leftDerivation (LeftHand), rightDerivation (RightHand));
		}
	}
}

