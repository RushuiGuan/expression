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
	/// <para>Output Type: System.DateOnly</para>
	/// </summary>
	[ParserOperation]
	public class DateOnlyExpression : PrefixExpression {
		public DateOnlyExpression() : base("Date", 1, 1) { }

		public override object? Eval(Func<string, object> context) {
			var value = this.GetRequiredValue(0, context);
			if (value is System.DateOnly) {
				return value;
			}else if(value is DateTime date){
				return DateOnly.FromDateTime(date);
			} else if(value is string text){
				if (System.DateOnly.TryParse(text, out var item)) {
					return item;
				}
			}
			throw new FormatException($"Cannot convert '{value}' to DateOnly");
		}
	}
}
