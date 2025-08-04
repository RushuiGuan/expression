using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Infix operation that perform an mod operation</para>
	/// <para>Operand Count: 2</para>
	/// <list type="number">
	///		<listheader>
	///		<description>Operands</description>
	///		</listheader>
	///		<item><description>Operrand1 : double</description></item>
	///		<item><description>Operrand2 : double</description></item>
	/// </list>
	/// <para>Output Type: double</para>
	/// </summary>
	[ParserOperation]
	public class Mod : InfixExpression {

		public override string Operator { get { return "%"; } }
		public override bool Symbolic { get { return true; } }
		public override int Precedence { get { return 200; } }

		public override object? Eval(Func<string, object> context) {
			object a = Operand1.Eval(context);
			object b = Operand2.Eval(context);

			if (a == null || b == null) { return null; }

			if (a is double && b is double){
				return (double)a % (double)b;
			} else {
				throw new Exceptions.UnexpectedTypeException(a.GetType());
			}
		}
	}
}
