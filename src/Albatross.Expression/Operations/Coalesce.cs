using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Prefix operation that return the first non null operand</para>
	/// <para>Operand Count: 1 to infinite</para>
	/// <para>Operand Type: any</para>
	/// <para>Example: Coalesce(null, 1, 2, 3) will return 1</para>
	/// </summary>
	[ParserOperation]
	public class Coalesce : PrefixExpression {
		public Coalesce() : base("Coalesce", 1, int.MaxValue) { }

		public override object? Eval(Func<string, object> context) {
			var list = this.GetOperandValues(context);
			foreach (var obj in list) {
				if (obj != null) {
					return obj;
				}
			}
			return null;
		}
	}
}
