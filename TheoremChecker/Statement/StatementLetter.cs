using System;

namespace TheoremChecker
{
	public class StatementLetter : IStatement
	{
		public StatementLetter (string name)
		{
			if (name == null)
				throw new ArgumentNullException ("variable");

			_LetterName = name;
		}

		private readonly string _LetterName;
		public string LetterName {
			get { return _LetterName; }
		}

		public override bool Equals (object obj)
		{
			var castObj = obj as StatementLetter;
			if (castObj == null)
				return false;
			else
				return Object.Equals (_LetterName, castObj.LetterName);
		}

		public override string ToString ()
		{
			return LetterName;
		}
	}
}

