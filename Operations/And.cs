using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;

namespace Albatross.Expression.Operations {
	public class And : InfixOperationToken {

		public override string Name { get { return "and"; } }
		public override bool Symbolic { get { return true; } }
		public override int Precedence { get { return 300; } }


		public override object EvalValue(Func<string, object> context) {
			base.EvalValue(context);

			object value = Operand1.EvalValue(context);
			
			if (!Utils.Operation.GetLogicalValue(value)) {
				return false;
			} else {
				value = Operand2.EvalValue(context);
				return Utils.Operation.GetLogicalValue(value);
			}
		}
	}
}
