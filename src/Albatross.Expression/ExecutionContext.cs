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

		public bool Compiled { get; private set; }
		public TryGetValueDelegate<T> TryGetExternalData { get; private set; }
		public IParser Parser { get; private set; }
		#endregion

		public ExecutionContext(IParser parser, bool caseSensitive, TryGetValueDelegate<T> tryGetValueDelegate) {
			this.Parser = parser;
			this.TryGetExternalData = tryGetValueDelegate;
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
		public object GetValue(string name, T input) {
			if (TryGetValue(name, input, out var value)) {
				return value;
			} else {
				throw new MissingVariableException(name);
			}
		}
		public bool TryGetValue(string name, T input, [NotNullWhen(true)]out object? data) {
			if (TryGetContext(name, input, out var value)) {
				data = GetContextValue(value, input);
				return true;
			} else {
				data = null;
				return false;
			}
		}
		object GetContextValue(ContextValue contextValue, T input) {
			if (contextValue.ContextType == ContextType.Expression) {
				ISet<string> chain = NewSet();
				if (!string.IsNullOrEmpty(contextValue.Name)) { chain.Add(contextValue.Name); }

				if (contextValue.Tree == null) {
					Build(contextValue, chain);
				}
				CheckCircularReference(contextValue, chain, input);
				return contextValue.Tree.Eval(name => GetValue(name, input));
			} else {
				return contextValue.Value;
			}
		}
		bool TryGetExternal(string name, T input, [NotNullWhen(true)] out ContextValue? value) {
			if (TryGetExternalData(name, input, out var data)) {
				if (data is ContextValue contextValue) {
					value = contextValue;
				} else {
					value = new ContextValue(name, data) { 
						ContextType = ContextType.Value, 
					};
				}
				value.External = true;
				if (value.ContextType == ContextType.Expression) { 
					Store.Add(name, value); 
				}
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
		#endregion

		void Build(ContextValue contextValue, ISet<string> chain) {
			contextValue.Tree = null;
			string text = Convert.ToString(contextValue.Value);
			if (string.IsNullOrEmpty(text)) {
				throw new ArgumentException($"ContextValue {contextValue.Name} has no expression value");
			}
			Queue<IToken> queue = Parser.Tokenize(text);
			contextValue.Dependees = NewSet();
			foreach (IToken token in queue) { if (token.IsVariable()) { contextValue.Dependees.Add(token.Name); } }
			Stack<IToken> stack = Parser.BuildPostfixStack(queue);
			contextValue.Tree = Parser.CreateTree(stack);
		}
		public void Build() {
			foreach (ContextValue value in Store.Values) {
				if (value.ContextType == ContextType.Expression) {
					Build(value, null);
				}
			}
		}
	}
}
