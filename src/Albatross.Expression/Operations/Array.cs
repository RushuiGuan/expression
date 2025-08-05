using System;
using Albatross.Expression.Nodes;


namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Prefix operation that create an object array</para>
	/// <para>Operand Count: 0 to infinite</para>
	/// <para>Operand Type: Any</para>
	/// <para>Output Type: <see cref="System.Collections.Generic.List{T}"/> where T is Object</para>
	/// <para>Usage: @(1, 2, 3, 4, 5)</para>
	/// </summary>
	[ParserOperation]
	public class Array : PrefixExpression {
		public Array() : base("@", 0, int.MaxValue) { }
		public override object? Eval(Func<string, object> context) {
			return GetOperands(context);
		}
	}
}
