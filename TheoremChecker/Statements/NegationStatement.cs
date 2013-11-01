using System;

namespace TheoremChecker
{
	public class NegationStatement : IStatement
	{
		public NegationStatement (IStatement statementToNegate)
		{
			if (statementToNegate == null)
				throw new ArgumentNullException("statementToNegate");

			_NegatedStatement = statementToNegate;
		}

		private readonly IStatement _NegatedStatement;
		public IStatement NegatedStatement {
			get { return _NegatedStatement; }
		}

		public bool IsNegationOf(IStatement statement) {
			return Object.Equals(NegatedStatement, statement);
		}

		public override bool Equals (object obj)
		{
			var castObj = obj as NegationStatement;

			if (castObj == null)
				return false;
			else
				return Object.Equals(NegatedStatement, castObj.NegatedStatement);
		}

		public override string ToString ()
		{
			return string.Format ("~{0}", NegatedStatement);
		}

		public NegationStatement Derive(Func<IStatement, IStatement> derivation) {
			return new NegationStatement (derivation(NegatedStatement));
		}
	}
}

