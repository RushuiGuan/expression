using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Infix operation that perform an plus operation</para>
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
	public class Plus : InfixOperationToken {

		public override string Name { get { return "+"; } }
		public override bool Symbolic { get { return true; } }
		public override int Precedence { get { return 100; } }

		public override object EvalValue(Func<string, object> context) {
			object a = Operand1.EvalValue(context);
			object b = Operand2.EvalValue(context);

			if (a == null || b == null) { return null; }
			
			if (a is double && b is double) {
				return (double)a + (double)b;
			}else if(a is DateTime && b is double){
				return ((DateTime)a).AddDays((double)b);
			}else if(a is string || b is string){
				return string.Format("{0}{1}", a, b);
			} else {
				throw new Exceptions.UnexpectedTypeException(a.GetType());
			}
		}
	}
}
