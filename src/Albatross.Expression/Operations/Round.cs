using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Nodes;
using System.Xml;
using Albatross.Expression.Exceptions;

using System.Globalization;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// Perform a mid point rounding away from zero.  First operand is the input, second operand is the number of digits.
	/// </summary>
	[ParserOperation]
	public class Round : PrefixExpression {
		public Round() : base("Round", 2, 2) { }

		public override object Eval(Func<string, object> context) {
			var value = this.GetValue(0, context).ConvertToDouble();
			var digit = this.GetValue(1, context).ConvertToInt();
			return Math.Round(value, digit, MidpointRounding.AwayFromZero);
		}
	}
}
