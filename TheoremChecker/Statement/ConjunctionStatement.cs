using System;

namespace TheoremChecker
{
	public class ConjunctionStatement : IStatement
	{
		public ConjunctionStatement (IStatement leftHand, IStatement rightHand)
		{
			if (leftHand == null)
				throw new ArgumentNullException ("leftHand");
			if (rightHand == null)
				throw new ArgumentNullException ("rightHand");

			_LeftHand = leftHand;
			_RightHand = rightHand;
		}

		private readonly IStatement _LeftHand;
		public IStatement LeftHand {
			get { return _LeftHand; }
		}

		private readonly IStatement _RightHand;
		public IStatement RightHand {
			get { return _RightHand; }
		}

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
	}
}

