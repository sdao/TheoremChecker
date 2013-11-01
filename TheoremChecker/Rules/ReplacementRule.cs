using System;

namespace TheoremChecker
{
	/**
	 * Abstract class for a replacement rule that replaces a statement
	 * or embedded statement with another statement.
	 */
	public abstract class ReplacementRule : IRule
	{
		public ReplacementRule(ProofLine templateLine) {
			if (templateLine == null)
				throw new ArgumentNullException ("templateLine");

			_Template = NormalizeRecursively(templateLine.Statement);
		}

		private readonly IStatement _Template;
		public IStatement Template { get { return _Template; } }

		/**
		 * Converts a statement to a "normalized" form; two statements
		 * with the same normalized form are considered logically
		 * identical under application of this replacement rule.
		 * 
		 * This function should not attempt to recursively normalize
		 * the statement; only the top-level statement should be
		 * normalized.
		 */
		protected abstract IStatement Normalize(IStatement statement);

		private IStatement NormalizeRecursively(IStatement statement)
		{
			if (statement is ConnectiveStatement) {
				ConnectiveStatement cs = statement as ConnectiveStatement;
				return Normalize (cs.Derive (l => NormalizeRecursively (l), r => NormalizeRecursively (r)));
			} else if (statement is NegationStatement) {
				NegationStatement ns = statement as NegationStatement;
				return Normalize (ns.Derive (s => NormalizeRecursively (s)));
			} else {
				return Normalize (statement);
			}
		}

		public bool Validate(IStatement statement) {
			return Template.Equals(NormalizeRecursively(statement));
		}
	}
}

