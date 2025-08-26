using Albatross.Expression.Nodes;
using System.Collections.Generic;

namespace Albatross.Expression.Prefix {
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
	public class CreateDate : PrefixExpression {
		public CreateDate() : base("CreateDate", 3, 3) { }
		
		protected override object Run(List<object> operands) {
			var year = operands[0].ConvertToInt();
			var month = operands[1].ConvertToInt();
			var day = operands[2].ConvertToInt();
			return new System.DateTime(year, month, day);
		}
	}
}
