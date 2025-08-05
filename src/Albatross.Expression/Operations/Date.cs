using System;
using System.Linq;
using Albatross.Expression.Nodes;

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
	public class Date : PrefixExpression {
		public Date() : base("Date", 1, 1) { }

		public override object? Eval(Func<string, object> context) {
			 var value = GetOperands(context).First();
			if (value is DateTime) {
				return value;
			} else {
				var item = DateTime.Parse(Convert.ToString(value));
				return item;
			}
		}
	}
}
