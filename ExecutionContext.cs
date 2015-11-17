using Albatross.Expression.Exceptions;
using Albatross.Expression.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Albatross.Expression {
	/// <summary>
	/// this is a case sensitive execution context engine
	/// </summary>
	public class ExecutionContext {
		IParser _parser;
		public Dictionary<string, ContextValue> Store { get; private set; }
		public Dictionary<string, HashSet<string>> Dependencies { get; private set; }
		public bool CaseSensitive { get; private set; }
		public bool Compiled { get; private set; }
		public delegate bool TryGetValueDelegate(string name, object input, out object value);
		public TryGetValueDelegate TryGetExternalData { get; set; }

		public ExecutionContext(IParser parser, bool caseSensitive) {
			_parser = parser;
			CaseSensitive = caseSensitive;
			Store = CaseSensitive ? new Dictionary<string, ContextValue>() : new Dictionary<string, ContextValue>(StringComparer.InvariantCultureIgnoreCase);
			Dependencies = CaseSensitive ? new Dictionary<string, HashSet<string>>() : new Dictionary<string, HashSet<string>>(StringComparer.InvariantCultureIgnoreCase);
		}
		public ExecutionContext() : this(Parser.GetParser(), true) { }
		public void Clear() {
			Store.Clear();
			Dependencies.Clear();
		}

		public object Eval(string expression, object input) {
			Queue<IToken> queue = _parser.Tokenize(expression);
			Stack<IToken> stack = _parser.BuildStack(queue);
			IToken tree = _parser.CreateTree(stack);
			return _parser.Eval(tree, new Func<string, object>(name => GetValue(name, input)));
		}

		public object GetValue(string name, object input) {
			ContextValue value;
			object data;
			if (Store.TryGetValue(name, out value)) {
				if (value.ContextType == ContextType.Value) {
					return value.Value;
				} else if (value.ContextType == ContextType.Expression) {
					return value.GetValue(_parser, this, input);
				} else {
					throw new NotSupportedException();
				}
			}else if(TryGetExternalData != null && TryGetExternalData(name, input, out data)){
				return data;
			} else {
				return null;
			}
		}
		public bool TryGetValue(string name, object input, out object data) {
			ContextValue value;
			if (Store.TryGetValue(name, out value)) {
				if (value.ContextType == ContextType.Value) {
					data = value.Value;
				} else {
					data = value.GetValue(_parser, this, input);
				}
				return true;
			} else if (TryGetExternalData != null && TryGetExternalData(name, input, out data)) {
				return true;
			} else {
				data = null;
				return false;
			}
		}
		public bool TryGetContext(string name, out ContextValue value) {
			return Store.TryGetValue(name, out value);
		}

		public void SetValue(string name, object value) { Set(new ContextValue() { Name = name, Value = value, ContextType = ContextType.Value, }); }
		public void SetExpression(string name, string expression) { 
			Set(new ContextValue() { Name = name, Value = expression, ContextType = ContextType.Expression, });
			Compiled = false;
		}
		public void SetExpression(string name, string expression, Type dataType) {
			Set(new ContextValue() { Name = name, Value = expression, ContextType = ContextType.Expression, DataType = dataType });
			Compiled = false;
		}
		public void Set(ContextValue value) { Store[value.Name] = value; }
		public HashSet<string> NewSet() {
			return CaseSensitive ? new HashSet<string>() : new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);
		}
		public void Compile() {
			Dependencies.Clear();
			foreach (ContextValue value in Store.Values) {
				if (value.ContextType == ContextType.Expression) {
					value.Build(_parser, this, null, false);
				}
			}
			foreach (ContextValue value in Store.Values) {
				if (value.ContextType == ContextType.Expression) {
					AddDependency(Dependencies, value.Name, value.Dependees);
				}
			}
			HashSet<string> chain = NewSet();
			foreach (ContextValue value in Store.Values) {
				if (value.ContextType == ContextType.Expression) {
					value.CheckCircularReference(_parser, this, chain);
				}
			}
		}
		void AddDependency(Dictionary<string, HashSet<string>> dict, string depender, IEnumerable<string> dependees) {
			if (dependees != null) {
				HashSet<string> set;
				foreach (string f in dependees) {
					if (dict.TryGetValue(f, out set)) {
						set.Add(depender);
					} else {
						set = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);
						set.Add(depender);
						dict.Add(f, set);
					}
				}
			}
		}
	}
}
