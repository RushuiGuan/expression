using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Albatross.Expression.Prefix {
	public class JoinPath : PrefixExpression {
		public JoinPath() : base("JoinPath", 1, int.MaxValue) { }
		
		protected override object Run(List<object> operands) {
			return Path.Join(operands.Select(x=>x.ConvertToString()).ToArray());
		}
	}
}