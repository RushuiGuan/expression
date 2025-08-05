using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Nodes;
using System.Xml;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class NotEqual : ComparisonInfixOperation {
		public NotEqual() : base("<>", 100) { }

		public override bool interpret(int comparisonResult) {
			return comparisonResult != 0;
		}
	}
}
