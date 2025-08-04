using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Infix operation that perform an power operation</para>
	/// <para>Operand Count: 2</para>
	/// <list type="number">
	///		<listheader>
	///		<description>Operands</description>
	///		</listheader>
	///		<item><description>base : double</description></item>
	///		<item><description>operand : double</description></item>
	/// </list>
	/// <para>Output Type: double</para>
	/// </summary>
	[ParserOperation]
	public class Power : InfixOperationToken {

		public override string Name { get { return "^"; } }
		public override bool Symbolic { get { return true; } }
		public override int Precedence { get { return 300; } }

		public override object? Eval(Func<string, object> context) {
			var a = Operand1.Eval(context);
			var b = Operand2.Eval(context);

			if (a == null || b == null) { return null; }

			if(a is double && b is double){
				return Math.Pow((double)a, (double)b);
			} else {
				throw new Exceptions.UnexpectedTypeException(a.GetType());
			}
		}
	}
}
