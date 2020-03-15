using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Numeric;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Infix operation that perform divide</para>
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
	public class Divide : InfixOperationToken {
		private readonly IDivideNumber divideNumber;

		public Divide(IDivideNumber divideNumber) {
			this.divideNumber = divideNumber;
		}

		public override string Name { get { return "/"; } }
		public override bool Symbolic { get { return true; } }
		public override int Precedence { get { return 200; } }

		public override object EvalValue(Func<string, object> context) {
			object a = Operand1.EvalValue(context);
			object b = Operand2.EvalValue(context);

			return divideNumber.Run(a, b);
		}
	}
}
