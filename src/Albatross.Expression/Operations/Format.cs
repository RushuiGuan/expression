using System;
using System.Collections.Generic;
using System.Linq;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Prefix operation that will take an input and C# format string and produced a formatted string</para>
	/// 
	/// </summary>
	[ParserOperation]
	public class Format : PrefixExpression {
		public Format() : base("Format", 2, 2) { }
		
		public override object? Eval(Func<string, object> context) {
			List<object> list = GetOperands(context);
			string format = "{0:" + list.Last() + "}";
			return string.Format(format, list.First());
		}
	}
}