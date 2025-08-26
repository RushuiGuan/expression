using System.Collections.Generic;
using System.Text;


namespace Albatross.Expression.Prefix {
	public class Concat : PrefixExpression {
		public Concat() : base("Concat", 1, int.MaxValue) { }


		protected override object Run(List<object> operands) {
			var sb = new StringBuilder();
			foreach(var operand in operands) {
				sb.Append(operand.ConvertToString());
			}
			return sb.ToString();
		}
	}
}