using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Nodes;
using System.Xml;

namespace Albatross.Expression.Infix {
	public class NotEqual : ComparisonInfixOperation {
		public NotEqual() : base("<>", 50) { }

		public override bool Interpret(int comparisonResult) {
			return comparisonResult != 0;
		}
	}
}
