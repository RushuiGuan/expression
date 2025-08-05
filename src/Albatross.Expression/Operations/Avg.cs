using System;
using Albatross.Expression.Nodes;
using Albatross.Expression.Exceptions;
using System.Collections;


namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Prefix operation that return the average of a set of numbers</para>
	/// <para>Operand Count: 0 to infinite</para>
	/// <para>Operand Type: number, if the operand count is 1, it can be an array</para>
	/// <para>Output Type: double</para>
	/// 
	/// <para>Usage: avg(1, 2, 3, 4, 5) or avg(@(1, 2, 3, 4, 5))</para>
	/// <para>Note: null value will not be counted, therefore avg(null, 2, 2, 2) should be 6/3 = 2 not 6/4 = 1.5;  It will return null if the count is 0.</para>
	/// </summary>
	[ParserOperation]
	public class Avg : PrefixExpression {
		public Avg() : base("avg", 0, int.MaxValue) { }
		public override object? Eval(Func<string, object> context) {
			if (Operands.Count == 0) { return null; }
			IEnumerable items = GetParamsOperands(context, out _);
			
			double sum = 0;
			int count = 0;

			try {
				foreach (double? item in items) {
					if (item != null) {
						sum += (double)item;
						count++;
					}
				}
			} catch (InvalidCastException) {
				throw new UnexpectedTypeException();
			}
			if (count != 0) {
				return sum / count;
			} else {
				return null;
			}
		}
	}
}
