using Albatross.Expression.Exceptions;
using Albatross.Expression.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Albatross.Expression {
	public enum ContextType {
		Value = 0, Expression = 1, 
	}
	[DataContract]
	public class ContextValue {
		[DataMember]
		public string Name { get; set; }
		[DataMember]
		public object Value { get; set; }
		[DataMember]
		public ContextType ContextType { get; set; }
		[DataMember]
		public string TypeName { get; private set; }

		Type _dataType;
		public Type DataType { 
			get { return _dataType; } 
			set { 
				_dataType = value;
				TypeName = value == null ? null : value.AssemblyQualifiedName;
			} 
		}
		public IToken Tree { get; set; }
		public HashSet<string> Dependees { get; set; }

		public void Build(IParser parser, ExecutionContext context, HashSet<string> chain) {
			Tree = null;
			Queue<IToken> queue = parser.Tokenize(Convert.ToString(Value));
			Dependees = context.NewSet();
			foreach (IToken token in queue) { if (token.IsVariable) { Dependees.Add(token.Name); } }
			Stack<IToken> stack = parser.BuildStack(queue);
			Tree = parser.CreateTree(stack);
		}
		public void CheckCircularReference(IParser parser, ExecutionContext context, HashSet<string> chain, object input) {
			foreach (string dependee in Dependees) {
				if (chain.Contains(dependee)) {
					throw new CircularReferenceException(dependee, Name);
				}
				ContextValue value;
				if (context.TryGetContext(dependee, input, out value) && value.ContextType == Expression.ContextType.Expression) {
					HashSet<string> newChain = context.NewSet();
					newChain.AddRange(chain).Add(dependee);
					if (value.Tree == null) {
						value.Build(parser, context, newChain);
					}
					value.CheckCircularReference(parser, context, newChain, input);
				}
			}
		}

		public object GetValue(IParser parser, ExecutionContext context, object input) {
			if (ContextType == Expression.ContextType.Expression) {
				HashSet<string> chain = context.NewSet();
				chain.Add(Name);
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
