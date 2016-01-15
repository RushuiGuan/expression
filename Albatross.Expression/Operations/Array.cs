using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Exceptions;


namespace Albatross.Expression.Operations {
	public class Array : PrefixOperationToken {

		public override string Name { get { return "@"; } }
		public override int MinOperandCount { get { return 0; } }
		public override int MaxOperandCount { get { return int.MaxValue; } }
		public override bool Symbolic { get { return true; } }

		public override object EvalValue(Func<string, object> context) {
			return GetOperands(context);
		}
	}
}
