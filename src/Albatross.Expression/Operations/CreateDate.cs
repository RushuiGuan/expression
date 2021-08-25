using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Prefix operation that create an date</para>
	/// <para>Operand Count: 3</para>
	/// <list type="number">
	///		<listheader>
	///		<description>Operands</description>
	///		</listheader>
	///		<item><description>year : double</description></item>
	///		<item><description>month : double</description></item>
	///		<item><description>day : double</description></item>
	/// </list>
	/// <para>Operand Type: int</para>
	/// <para>Output Type: System.DateTime</para>
	/// <para>Usage: CreateDate(2018, 1, 31)</para>
	/// </summary>
	[ParserOperation]
	public class CreateDate : PrefixOperationToken {
		public override string Name { get { return "createDate"; } }
		public override int MinOperandCount { get { return 3; } }
		public override int MaxOperandCount { get { return 3; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
			var list = GetOperands(context);
			int[] input = (from item in list 
						   select (int)System.Convert.ChangeType(item, typeof(int))).ToArray();
			return new DateTime(input[0], input[1], input[2]);
		}
	}
}
