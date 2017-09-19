using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Albatross.Expression {
	public class ExecutionContextFactory {
		IParser _parser;

		public ExecutionContextFactory(IParser parser) {
			_parser = parser;
		}

		public IExecutionContext Create(bool caseSensitive) {
			return new ExecutionContext(_parser, caseSensitive);
		}
	}
}
