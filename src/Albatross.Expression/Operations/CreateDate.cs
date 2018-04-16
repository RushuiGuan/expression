using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// Prefix operation that create an date
	/// Operand Count: 3
	/// <list type="number">
	///		<listheader>
	///		<description>Operands</description>
	///		</listheader>
	///		<item><description>year : double</description></item>
	///		<item><description>month : double</description></item>
	///		<item><description>day : double</description></item>
	/// </list>
	/// Operand Type: int
	/// Output Type: System.DateTime
	/// Usage: CreateDate(2018, 1, 31)
	/// </summary>
	[ParserOperation]
	public class CreateDate : PrefixOperationToken {
		public override string Name { get { return "createDate"; } }
		public override int MinOperandCount { get { return 3; } }
		public override int MaxOperandCount { get { return 3; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
			int[] input = (from item in Operands select (int)System.Convert.ChangeType(item.EvalValue(context), typeof(int))).ToArray();
			return new DateTime(input[0], input[1], input[2]);
		}
	}
}
