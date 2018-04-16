using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// Prefix operation that convert input to date.  The operand is converted to text first and parsed to a datetime object
	/// Operand Count: 1
	/// <list type="number">
	///		<listheader>
	///		<description>Operands</description>
	///		</listheader>
	///		<item><description>input : any</description></item>
	/// </list>
	/// Output Type: System.DateTime
	/// </summary>
	[ParserOperation]
	public class Date : PrefixOperationToken {
		public override string Name { get { return "date"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
			object value = Operands.First().EvalValue(context);
			if (value is DateTime) {
				return value;
			} else {
				return DateTime.Parse(Convert.ToString(value));
			}
		}
	}
}
