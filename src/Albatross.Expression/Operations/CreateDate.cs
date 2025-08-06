using System;
using Albatross.Expression.Nodes;

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
	public class CreateDate : PrefixExpression {
		public CreateDate() : base("CreateDate", 3, 3) { }
		
		public override object Eval(Func<string, object> context) {
			var year = this.GetValue(0, context);
			var month = this.GetValue(1, context);
			var day = this.GetValue(2, context);
			return new System.DateTime(year.ConvertToInt(), month.ConvertToInt(), day.ConvertToInt());
		}
	}
}
