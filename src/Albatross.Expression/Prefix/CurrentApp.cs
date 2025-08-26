using System;
using Albatross.Expression.Nodes;
using System.Collections.Generic;

namespace Albatross.Expression.Prefix {
	/// <summary>
	/// <para>Prefix operation that returns the current app domain friendly name</para>
	/// <para>Operand Count: 0</para>
	/// <para>Output Type: string</para>
	/// </summary>
	public class CurrentApp : PrefixExpression {
		public CurrentApp() : base("CurrentApp", 0, 0) { }

		protected override object Run(List<object> operands) => AppDomain.CurrentDomain.FriendlyName;
	}
}