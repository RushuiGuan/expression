using Albatross.Expression.Exceptions;
using Albatross.Expression.Nodes;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Albatross.Expression {
	public class ExecutionContext<T> : IExecutionContext<T> {
		#region fields
		public Dictionary<string, ContextValue> Store { get; private set; }
		Dictionary<string, ContextValue> _expressions = new Dictionary<string, ContextValue>();

		public bool Compiled { get; private set; }
		public bool CaseSensitive { get; private set; }
		public bool CacheExternalValue { get; private set; }
		public bool FailWhenMissingVariable { get; private set; }
		public TryGetValueDelegate<T> TryGetExternalData { get; private set; }
		public IParser Parser { get; private set; }
		#endregion

		public ExecutionContext(IParser parser, bool caseSensitive, bool cacheExternalValue, bool failWhenMissingVariable, TryGetValueDelegate<T> tryGetValueDelegate) {
			this.Parser = parser;
			this.CaseSensitive = caseSensitive;
			this.CacheExternalValue = cacheExternalValue;
			this.TryGetExternalData = tryGetValueDelegate;
			this.FailWhenMissingVariable = failWhenMissingVariable;

			Store = caseSensitive ? new Dictionary<string, ContextValue>() : new Dictionary<string, ContextValue>(StringComparer.InvariantCultureIgnoreCase);
		}

		#region state management
		public void Clear() {
			Store.Clear();
			Compiled = false;
		}
		public void Set(ContextValue value) {
			Store[value.Name] = value;
			if (value.ContextType == ContextType.Expression) {
				Compiled = false;
			}
		}
		#endregion

		#region data retrieval
		public object? GetValue(string name, T input) {
			object? value;
			if (TryGetValue(name, input, out value)) {
				return value;
			} else {
				if (FailWhenMissingVariable) {
					throw new MissingVariableException(name);
				} else {
					return null;
				}
			}
		}
		public bool TryGetValue(string name, T input, out object? data) {
			ContextValue value;
			if (TryGetContext(name, input, out value)) {
				data = GetContextValue(value, input);
				return true;
			} else {
				data = null;
				return false;
			}
		}
		object? GetContextValue(ContextValue contextValue, T input) {
			if (contextValue.ContextType == Albatross.Expression.ContextType.Expression) {
				ISet<string> chain = NewSet();
				if (!string.IsNullOrEmpty(contextValue.Name)) { chain.Add(contextValue.Name); }

				if (contextValue.Tree == null) {
					Build(contextValue, chain);
				}
				CheckCircularReference(contextValue, chain, input);
				var data = Parser.Eval(contextValue.Tree, new Func<string, object>(name => GetValue(name, input)));
				if (data != null && contextValue.DataType != null && contextValue.DataType != data.GetType()) {
					data = Convert.ChangeType(data, contextValue.DataType);
				}
				return data;
			} else {
				return contextValue.Value;
			}
		}
		bool TryGetExternal(string name, T input, [NotNullWhen(true)] out ContextValue? value) {
			object? data;
			if (TryGetExternalData != null && TryGetExternalData(name, input, out data)) {
				if (data is ContextValue) {
					value = (ContextValue)data;
				} else {
					value = new ContextValue(name, data) { ContextType = ContextType.Value, };
				}
				value.External = true;
				if (value.ContextType == ContextType.Expression || CacheExternalValue) { Store.Add(name, value); }
				return true;
			} else {
				value = null;
				return false;
			}
		}
		bool TryGetContext(string name, T input, [NotNullWhen(true)] out ContextValue? value) {
			return Store.TryGetValue(name, out value) || TryGetExternal(name, input, out value);
		}
		#endregion

		#region dependency check
		void CheckCircularReference(ContextValue contextValue, ISet<string> chain, T input) {
			foreach (string dependee in contextValue.Dependees) {
				if (chain.Contains(dependee)) {
					throw new CircularReferenceException(dependee, string.IsNullOrEmpty(contextValue.Name) ? Convert.ToString(contextValue.Value) : contextValue.Name);
				}
				ContextValue value;
				if (TryGetContext(dependee, input, out value) && value.ContextType == Albatross.Expression.ContextType.Expression) {
					ISet<string> newChain = NewSet();
					foreach (var item in chain) {
						newChain.Add(item);
					}
					newChain.Add(dependee);

					if (value.Tree == null) {
						Build(value, newChain);
					}
					CheckCircularReference(value, newChain, input);
				}
			}
		}
		//void AddDependency(IDictionary<string, HashSet<string>> dict, string depender, IEnumerable<string> dependees) {
		//	if (dependees != null) {
		//		HashSet<string> set;
		//		foreach (string f in dependees) {
		//			if (dict.TryGetValue(f, out set)) {
		//				set.Add(depender);
		//			} else {
		//				set = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);
		//				set.Add(depender);
		//				dict.Add(f, set);
		//			}
		//		}
		//	}
		//}
		//public void GetDependants(string name, ISet<string> dependents) {
		//	HashSet<string> list;
		//	if (Dependencies.TryGetValue(name, out list)) {
		//		foreach (string dependent in list) {
		//			dependents.Add(dependent);
		//			GetDependants(dependent, dependents);
		//		}
		//	}
		//}
		ISet<string> NewSet() {
			return CaseSensitive ? new HashSet<string>() : new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);
		}
		#endregion

		public object? Eval(string expression, T input, Type? outputDataType = null) {
			ContextValue value;
			if (!_expressions.TryGetValue(expression, out value)) {
				value = new ContextValue(string.Empty, expression) {
					DataType = outputDataType,
					ContextType = ContextType.Expression,
				};
				_expressions.Add(expression, value);
			}
			return GetContextValue(value, input);
		}
		void Build(ContextValue contextValue, ISet<string> chain) {
			contextValue.Tree = null;
			string text = Convert.ToString(contextValue.Value);
			if (string.IsNullOrEmpty(text)) {
				throw new ArgumentException($"ContextValue {contextValue.Name} has no expression value");
			}
			Queue<INode> queue = Parser.Tokenize(text);
			contextValue.Dependees = NewSet();
			foreach (INode token in queue) { if (token.IsVariable()) { contextValue.Dependees.Add(token.Name); } }
			Stack<INode> stack = Parser.BuildStack(queue);
			contextValue.Tree = Parser.CreateTree(stack);
		}
		public void Build() {
			foreach (ContextValue value in Store.Values) {
				if (value.ContextType == ContextType.Expression) {
					Build(value, null);
				}
			}
		}

		#region IEnumerator
		public IEnumerator<ContextValue> GetEnumerator() => Store.Values.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => Store.Values.GetEnumerator();
		#endregion
	}
}
