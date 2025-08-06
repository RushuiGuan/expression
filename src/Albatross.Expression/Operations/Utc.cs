using System;
using System.Linq;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// Convert a dateTime object to utc.  If the input operand is a string, the function will attempt to parse it first.
	/// </summary>
	[ParserOperation]
	public class Utc : PrefixExpression {
		public Utc() : base("Utc", 1, 1) { }
		
		public override object? Eval(Func<string, object> context) {
			object value = GetRequiredOperandValues(context).First();
			System.DateTime dateTime = (value as System.DateTime?) ?? System.DateTime.Parse(Convert.ToString(value));
			return dateTime.ToUniversalTime();
		}
	}
}