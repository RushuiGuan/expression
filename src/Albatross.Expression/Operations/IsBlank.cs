using System;
using System.Linq;
using Albatross.Expression.Nodes;


namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Prefix operation to check if the input IsBlank</para>
	/// <para>Operand Type: any</para>
	/// <para>Null, empty string and string with only white space are considered as blank</para>
	/// </summary>
	[ParserOperation]
	public class IsBlank : PrefixExpression {
		public IsBlank() : base("IsBlank", 1, 1) { }

		public override object? Eval(Func<string, object> context) {
			var value = this.GetValue(0, context);
			
			if (value == null) {
				return true;
			} else if (value is string text) {
				return string.IsNullOrWhiteSpace(text);
			} else {
				return false;
			}
		}
	}
}
