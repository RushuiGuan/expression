using Albatross.Expression.Nodes;
using System.Collections.Generic;

namespace Albatross.Expression.Prefix {
	/// <summary>
	/// <para>Prefix operation that returns the current machine host name</para>
	/// <para>Operand Count: 0</para>
	/// <para>Output Type: string</para>
	/// </summary>
	public class CurrentMachine : PrefixExpression {
		public CurrentMachine() : base("CurrentMachine", 0, 0) { }

		public override object Run(List<object> operands) => System.Net.Dns.GetHostName();
	}
}