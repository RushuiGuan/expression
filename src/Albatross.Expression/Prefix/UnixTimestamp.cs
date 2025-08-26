using System;
using Albatross.Expression.Nodes;
using System.Collections.Generic;

namespace Albatross.Expression.Prefix {
	/// <summary>
	/// <para>Prefix operation that convert a DateTime to the number of seconds that have elapsed since 1970-01-01T00:00:00Z.
	/// It is also called unix timestamp.  
	/// If the input is not DateTime, the operand is converted to text first and parsed to a datetime object</para>
	/// <para>Operand Count: 1</para>
	/// <list type="number">
	///		<listheader>
	///		<description>Operands</description>
	///		</listheader>
	///		<item><description>input : any</description></item>
	/// </list>
	/// <para>Output Type: long</para>
	/// </summary>
	public class UnixTimestamp : PrefixExpression {
		public UnixTimestamp() : base("UnixTimestamp", 1, 1) { }

		public override object Run(List<object> operands){
			var value = operands[0].ConvertToDateTime();
			return Convert.ToDouble(new DateTimeOffset(value).ToUnixTimeSeconds());
		}
	}
}