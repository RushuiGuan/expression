using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Nodes;
using System.Xml;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Infix OR operation.</para>
	/// 
	/// <para>Operand Count: 2</para>
	/// <list type="number">
	///		<listheader>
	///		<description>Operands</description>
	///		</listheader>
	///		<item><description>Operand1 : any</description></item>
	///		<item><description>Operand2 : any</description></item>
	/// </list>
	/// 
	/// <para>Output Type: Boolean</para>
	/// <para>Usage: 3 > 2 or 2 > 1</para>
	/// <para>Precedance: 20</para>
	/// </summary>
	[ParserOperation]
	public class Or : InfixExpression {
		
		public override string Operator { get { return "Or"; } }
		public override int Precedence { get { return 20; } }

		public override object? Eval(Func<string, object> context) {
			object value = Operand1.Eval(context);
			if (value.ConvertToBoolean()) {
				return true;
			} else {
				value = Operand2.Eval(context);
				return value.ConvertToBoolean();
			}
		}
	}
}
