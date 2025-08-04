using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Prefix operation that convert input to date.  The operand is converted to text first and parsed to a datetime object</para>
	/// <para>Operand Count: 1</para>
	/// <list type="number">
	///		<listheader>
	///		<description>Operands</description>
	///		</listheader>
	///		<item><description>input : any</description></item>
	/// </list>
	/// <para>Output Type: System.DateTime</para>
	/// </summary>
	[ParserOperation]
	public class Date : PrefixOperationToken {
		public override string Name { get { return "date"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return false; } }

		public override object? Eval(Func<string, object> context) {
			object value = GetOperands(context).First();
			if (value is DateTime) {
				return value;
			} else {
				var item = DateTime.Parse(Convert.ToString(value));
				return item;
			}
		}
	}
}
