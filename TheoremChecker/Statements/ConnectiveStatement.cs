using System;

namespace TheoremChecker
{
	public abstract class ConnectiveStatement : IStatement
	{
		public ConnectiveStatement (IStatement leftHand, IStatement rightHand)
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

		public abstract ConnectiveStatement Derive(Func<IStatement, IStatement> leftDerivation, Func<IStatement, IStatement> rightDerivation);
	}
}

