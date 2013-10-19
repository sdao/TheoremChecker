using System;

namespace TheoremChecker
{
	public class ImplicationStatement : IStatement
	{
		public ImplicationStatement (IStatement antecedent, IStatement consequent)
		{
			if (antecedent == null)
				throw new ArgumentNullException ("antecedent");

			if (consequent == null)
				throw new ArgumentNullException ("consequent");

			_Antecedent = antecedent;
			_Consequent = consequent;
		}

		private readonly IStatement _Antecedent;
		public IStatement Antecedent {
			get {
				return _Antecedent;
			}
		}

		private readonly IStatement _Consequent;
		public IStatement Consequent {
		get {
				return _Consequent;
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
	}
}

