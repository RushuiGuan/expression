using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Prefix operation that will take an input and C# format string and produced a formatted string</para>
	/// 
	/// </summary>
	[ParserOperation]
	public class Format : PrefixExpression {
		public Format() : base("Format", 2, 2) { }
		
		public override object Eval(Func<string, object> context) {
			var formatText = this.GetRequiredStringValue(1, context);
			var value= this.GetValue(0, context);
			string format = $"{{0:{formatText}}}";
			return string.Format(format, value);
		}
	}
}