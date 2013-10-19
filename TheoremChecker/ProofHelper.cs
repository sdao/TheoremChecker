using System;

namespace TheoremChecker
{
	public static class ProofHelper
	{
		/**
		 * Creates a new proof line.
		 */
		public static ProofLine Line(IStatement s, IRule j) {
			return new ProofLine (s, j);
		}

		private static PremissRule _Premiss = new PremissRule();

		/**
		 * Signifies that the statement is given as a premiss, and should not be validated.
		 */
		public static PremissRule Premiss() {
			return _Premiss;
		}

		/**
		 * Justifies the statement on the basis that it reiterates a previous statement.
		 */
		public static ReiterateRule Reit(ProofLine line) {
			return new ReiterateRule(line);
		}

		/**
		 * Justifies the statement on the basis that it was one of the sides of a previous conjunction.
		 */
		public static ConjunctionEliminationRule ConjElim(ProofLine line) {
			return new ConjunctionEliminationRule(line);
		}

		/**
		 * Justifies the statement on the basis that it is the conjunction of two previously-entered statements.
		 */
		public static ConjunctionIntroductionRule ConjIntr(ProofLine line1, ProofLine line2) {
			return new ConjunctionIntroductionRule(line1, line2);
		}

		/**
		 * Justifies the statement on the basis of Modus Ponens.
		 */
		public static ModusPonensRule MP(ProofLine implication, ProofLine enteredAntecedent) {
			return new ModusPonensRule (implication, enteredAntecedent);
		}

		/**
		 * Justifies the statement on the basis of Modus Tollens.
		 */
		public static ModusTollensRule MT(ProofLine implication, ProofLine enteredNegatedConsequent) {
			return new ModusTollensRule (implication, enteredNegatedConsequent);
		}

		/**
		 * Creates a new statement with only a statement letter.
		 */
		public static StatementLetter Letter(String name) {
			return new StatementLetter(name);
		}

		public class IfThenContinuation {
			public IfThenContinuation(IStatement antecedent) {
				if (antecedent == null)
					throw new ArgumentNullException("antecedent");

				_Antecedent = antecedent;
			}

			private readonly IStatement _Antecedent;
			public IStatement Antecedent {
				get {
					return _Antecedent;
				}
			}

			/**
			 * Completes the consequent of an implication.
			 */
			public ImplicationStatement Then(IStatement consequent) {
				return new ImplicationStatement (Antecedent, consequent);
			}

			/**
			 * Completes the consequent of an implication.
			 */
			public ImplicationStatement Then(string consequent) {
				return new ImplicationStatement (Antecedent, Letter (consequent));
			}
		}

		/**
		 * Forms the antecedent of an implication.
		 */
		public static IfThenContinuation If(IStatement antecedent) {
			return new IfThenContinuation (antecedent);
		}

		/**
		 * Forms the antecedent of an implication.
		 */
		public static IfThenContinuation If(string antecedent) {
			return new IfThenContinuation (Letter (antecedent));
		}

		public static NegationStatement Not(IStatement statement) {
			return new NegationStatement (statement);
		}

		public static NegationStatement Not(string letter) {
			return new NegationStatement (Letter (letter));
		}

		/**
		 * Conjoins two statements.
		 */
		public static ConjunctionStatement And(this IStatement left, IStatement right) {
			return new ConjunctionStatement (left, right);
		}

		/**
		 * Conjoins two statement letters.
		 */
		public static ConjunctionStatement And(this string left, string right) {
			return new ConjunctionStatement (Letter (left), Letter (right));
		}

		/**
		 * Conjoins a statement with a statement letter.
		 */
		public static ConjunctionStatement And(this IStatement left, string right) {
			return new ConjunctionStatement (left, Letter (right));
		}
	}
}

