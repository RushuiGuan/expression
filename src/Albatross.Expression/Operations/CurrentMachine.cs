using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Prefix operation that returns the current machine host name</para>
	/// <para>Operand Count: 0</para>
	/// <para>Output Type: string</para>
	/// </summary>
	[ParserOperation]
	public class CurrentMachine : PrefixExpression {
		
		public override string Name { get { return "CurrentMachine"; } }
		public override int MinOperandCount { get { return 0; } }
		public override int MaxOperandCount { get { return 0; } }
		public override bool Symbolic { get { return false; } }

		public override object? Eval(Func<string, object> context) {
			return System.Net.Dns.GetHostName();
		}
	}
}
