using Albatross.Expression.Exceptions;
using Albatross.Expression.Tokens;
using System;
using System.Collections.Generic;

namespace Albatross.Expression {
	public enum ContextType {
		Value = 0, Expression = 1, 
	}
	public class ContextValue {
		public string Name { get; set; }
		public object Value { get; set; }
		public ContextType ContextType { get; set; }

		public Type DataType { get; set; }
		public IToken Tree { get; set; }
		public ISet<string> Dependees { get; set; }

		public void Build(IParser parser, ExecutionContext context, ISet<string> chain) {
			Tree = null;
			Queue<IToken> queue = parser.Tokenize(Convert.ToString(Value));
			Dependees = context.NewSet();
			foreach (IToken token in queue) { if (token.IsVariable) { Dependees.Add(token.Name); } }
			Stack<IToken> stack = parser.BuildStack(queue);
			Tree = parser.CreateTree(stack);
		}
		public void CheckCircularReference(IParser parser, ExecutionContext context, ISet<string> chain, object input) {
			foreach (string dependee in Dependees) {
				if (chain.Contains(dependee)) {
					throw new CircularReferenceException(dependee, string.IsNullOrEmpty(Name) ? Convert.ToString(Value) : Name);
				}
				ContextValue value;
				if (context.TryGetContext(dependee, input, out value) && value.ContextType == Albatross.Expression.ContextType.Expression) {
					ISet<string> newChain = context.NewSet();
					newChain.AddRange(chain).Add(dependee);
					if (value.Tree == null) {
						value.Build(parser, context, newChain);
					}
					value.CheckCircularReference(parser, context, newChain, input);
				}
			}
		}

		public object GetValue(IParser parser, ExecutionContext context, object input) {
			if (ContextType == Albatross.Expression.ContextType.Expression) {
				ISet<string> chain = context.NewSet();
				if (!string.IsNullOrEmpty(Name)) { chain.Add(Name); }

				if (Tree == null) {
					Build(parser, context, chain);
				}
				CheckCircularReference(parser, context, chain, input);
				object value = parser.Eval(Tree, new Func<string, object>(name => context.GetValue(name, input)));
				if (value != null && DataType != null && DataType != value.GetType()) {
					value = Convert.ChangeType(value, DataType);
				}
				return value;
			} else {
				return Value;
			}
		}
	}
}
