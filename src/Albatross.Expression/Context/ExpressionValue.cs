using Albatross.Expression.Nodes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Albatross.Expression.Context {
	public class ExpressionValue : IContextValue {
		public ExpressionValue(string name, string expression, bool caseSensitive, IParser parser) {
			Name = name;
			this.Expression = expression;
			Dependees = caseSensitive ? new HashSet<string>() : new HashSet<string>(StringComparer.OrdinalIgnoreCase);
			var queue = parser.Tokenize(expression);
			foreach (var token in queue) {
				if (token is Variable variable) {
					Dependees.Add(variable.Name);
				}
			}
			var stack = parser.BuildPostfixStack(queue);
			this.Tree = parser.CreateTree(stack);
		}

		public string Name { get; }
		public object GetValue<T>(T input, Func<string, T, object> func) 
			=>  this.Tree.Eval(name=> func(name, input));

		public Task<object> GetValueAsync<T>(T input, Func<string, T, Task<object>> func) {
			return this.Tree.EvalAsync(async name => await func(name, input));
		}

		public string Expression { get; }
		public IExpression Tree { get; }
		public ISet<string> Dependees { get; }
	}
}