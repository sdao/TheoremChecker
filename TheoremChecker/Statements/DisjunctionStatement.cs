using System;

namespace TheoremChecker
{
	public class DisjunctionStatement : ConnectiveStatement
	{
		public DisjunctionStatement (IStatement leftHand, IStatement rightHand): base(leftHand, rightHand) {}

		public override string ToString ()
		{
			return string.Format ("({0} \x2228 {1})", LeftHand, RightHand);
		}

		public override bool Equals (object obj)
		{
			var castObj = obj as DisjunctionStatement;

			if (castObj == null)
				return false;
			else
				return Object.Equals (castObj.LeftHand, LeftHand) && Object.Equals (castObj.RightHand, RightHand);
		}

		public override ConnectiveStatement Derive (Func<IStatement, IStatement> leftDerivation, Func<IStatement, IStatement> rightDerivation)
		{
			return new DisjunctionStatement (leftDerivation (LeftHand), rightDerivation (RightHand));
		}
	}
}

