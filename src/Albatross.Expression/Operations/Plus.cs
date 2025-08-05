using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Nodes;
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
	public class Plus : InfixExpression {
		public Plus() : base("+", 100) { }

		public override object? Eval(Func<string, object> context) {
			var a = Operand1.Eval(context);
			var b = Operand2.Eval(context);

			if (a == null || b == null) { return null; }
			
			if (a is double aa && b is double bb) {
				return aa + bb;
			}else if(a is DateTime dateTime && b is double days){
				return dateTime.AddDays(days);
			}else if(a is string || b is string){
				return $"{a}{b}";
			} else {
				throw new Exceptions.UnexpectedTypeException(a.GetType());
			}
		}
	}
}
