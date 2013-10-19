using System;

namespace TheoremChecker
{
	public interface IRule
	{
		bool Validate (IStatement statement);
	}
}

