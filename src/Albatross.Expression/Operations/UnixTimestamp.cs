using System;
using System.Linq;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
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
	[ParserOperation]
	public class UnixTimestamp : PrefixExpression {
		public override string Name { get { return "UnixTimestamp"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return false; } }

		public override object? Eval(Func<string, object> context) {
			object value = GetOperands(context).First();
			DateTime dateTime = (value as DateTime?) ?? DateTime.Parse(Convert.ToString(value));
			return new DateTimeOffset(dateTime).ToUnixTimeSeconds();
		}
	}
}