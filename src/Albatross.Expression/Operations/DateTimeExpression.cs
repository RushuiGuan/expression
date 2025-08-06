using System;
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
	public class DateTimeExpression : PrefixExpression {
		public DateTimeExpression() : base("DateTime", 1, 1) { }

		public override object Eval(Func<string, object> context) {
			var value = this.GetValue(0, context);
			if (value is System.DateTime) {
				return value;
			}else if(value is DateOnly date){
				return date.ToDateTime(new TimeOnly(0, 0));
			} else if(value is string text){
				if (System.DateTime.TryParse(text, out var item)) {
					return item;
				}
			}
			throw new FormatException($"Cannot convert '{value}' to DateTime");
		}
	}
}
