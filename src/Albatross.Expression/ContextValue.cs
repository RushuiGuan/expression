using Albatross.Expression.Nodes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Albatross.Expression {
	public interface IContextValue {
		string Name { get; }
		object GetValue<T>(T input);
		Task<object> GetValueAsync<T>(T input);
	}

	public class ContextValue {
		public ContextValue(string name, object value) {
			Name = name;
			Value = value;
		}

		public string Name { get; }
		public object Value { get; }
		public ContextType ContextType { get; set; } = ContextType.Expression;
		public bool External { get; set; }

		public Type? DataType { get; set; }
		public IExpression? Tree { get; set; }

		/// <summary>
		/// If this context value is a variable, Dependees will contain the set of variables that it depends on
		/// </summary>
		public ISet<string> Dependees { get; set; }
	}

	public class ExpressionContextValue : IContextValue {
		public ExpressionContextValue(string name, string expression, bool caseSensitive, IParser parser) {
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

		public object GetValue<T>(T input) {
			throw new NotImplementedException();
		}

		public Task<object> GetValueAsync<T>(T input) {
			throw new NotImplementedException();
		}

		public string Name { get; }
		public string Expression { get; }
		public IExpression Tree { get; }
		public ISet<string> Dependees { get; }
	}
}