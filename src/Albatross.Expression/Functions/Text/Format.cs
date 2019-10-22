using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Exceptions;

using System.Globalization;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Prefix operation that will take an input and C# format string and produced a formatted string</para>
	/// 
	/// </summary>
	[ParserOperation]
	public class Format : PrefixOperationToken {

		public override string Name { get { return "Format"; } }
		public override int MinOperandCount { get { return 2; } }
		public override int MaxOperandCount { get { return 2; } }
		public override bool Symbolic { get { return false; } }


		public override object EvalValue(Func<string, object> context) {
			List<object> list = GetOperands(context);
			string format = "{0:" + list.Last() + "}";
			return string.Format(format, list.First());
		}
	}
}
