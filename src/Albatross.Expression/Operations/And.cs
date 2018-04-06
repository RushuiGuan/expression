using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// Infix AND operation.
	/// Operand Count: 2
	/// Operand Type: Any, see the <see cref="Albatross.Expression.Extensions.ConvertToBoolean(object)"/> method for the conversion logic
	/// Output Type: Boolean
	/// Usage: 3 > 2 and 2 > 1
	/// Precedance: 30
	/// </summary>
	[ParserOperation(Group = "Logical")]
	public class And : InfixOperationToken {

		public override string Name { get { return "and"; } }
		public override bool Symbolic { get { return true; } }
		public override int Precedence { get { return 30; } }


		public override object EvalValue(Func<string, object> context) {
			base.EvalValue(context);

			object value = Operand1.EvalValue(context);
			
			if (!value.ConvertToBoolean()) {
				return false;
			} else {
				value = Operand2.EvalValue(context);
				return value.ConvertToBoolean();
			}
		}
	}
}
