using System;

namespace TheoremChecker
{
	public class ConjunctionStatement : ConnectiveStatement
	{
		public ConjunctionStatement(IStatement leftHand, IStatement rightHand) : base(leftHand, rightHand) {}

		public override string ToString ()
		{
			return string.Format ("({0} \x2227 {1})", LeftHand, RightHand);
		}

		public override bool Equals (object obj)
		{
			var castObj = obj as ConjunctionStatement;

			if (castObj == null)
				return false;
			else
				return Object.Equals (castObj.LeftHand, LeftHand) && Object.Equals (castObj.RightHand, RightHand);
		}

		public override ConnectiveStatement Derive (Func<IStatement, IStatement> leftDerivation, Func<IStatement, IStatement> rightDerivation)
		{
			return new ConjunctionStatement (leftDerivation (LeftHand), rightDerivation (RightHand));
		}
	}
}

