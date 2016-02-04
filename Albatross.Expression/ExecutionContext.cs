using Albatross.Expression.Exceptions;
using Albatross.Expression.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Albatross.Expression {
	public class ExecutionContext : IExecutionContext {
		public Dictionary<string, ContextValue> Store { get; private set; }
		public IDictionary<string, HashSet<string>> Dependencies { get; private set; }
		public bool CaseSensitive { get; private set; }
		public bool Compiled { get; private set; }
		public bool CacheExternalValue { get; set; }
		public TryGetValueDelegate TryGetExternalData { get; set; }
		public IParser Parser { get; private set; }

		Dictionary<string, ContextValue> _evalStacks = new Dictionary<string, ContextValue>();

		public ExecutionContext(IParser parser) {
			Parser = parser;
			CaseSensitive = false;
			Store = CaseSensitive ? new Dictionary<string, ContextValue>() : new Dictionary<string, ContextValue>(StringComparer.InvariantCultureIgnoreCase);
			Dependencies = CaseSensitive ? new Dictionary<string, HashSet<string>>() : new Dictionary<string, HashSet<string>>(StringComparer.InvariantCultureIgnoreCase);
		}
		public void Clear() {
			Store.Clear();
			Dependencies.Clear();
		}

		public object Eval(string expression, object input, Type outputDataType = null) {
			ContextValue value;
			if (!_evalStacks.TryGetValue(expression, out value)) {
				value = new ContextValue() {
					 Value = expression,
					 DataType = outputDataType,
					 ContextType = ContextType.Expression,
				};
				_evalStacks.Add(expression, value);
			}
			return value.GetValue(Parser, this, input);
		}

		bool TryGetExternal(string name, object input, bool contextOnly, out object data){
			ContextValue value;
			if (TryGetExternalData != null && TryGetExternalData(name, input, out data)) {
				if (data is ContextValue) {
					value = (ContextValue)data;
					if (CacheExternalValue) { Store.Add(name, value); }
					if (!contextOnly) {
						data = value.GetValue(Parser, this, input);
					}
				} else {
					value = new ContextValue() { Name = name, Value = data, ContextType = ContextType.Value, };
					if (CacheExternalValue) { Store.Add(name, value); }
					if (contextOnly) { data = value; }
				}
				return true;
			} else {
				data = null;
				return false;
			}
		}

		public object GetValue(string name, object input) {
			ContextValue value;
			object data;
			if (Store.TryGetValue(name, out value)) {
				if (value.ContextType == ContextType.Value) {
					return value.Value;
				} else if (value.ContextType == ContextType.Expression) {
					return value.GetValue(Parser, this, input);
				} else {
					throw new NotSupportedException();
				}
			}else if(TryGetExternal(name, input, false, out data)){
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
					data = value.GetValue(Parser, this, input);
				}
				return true;
			}else{
				return TryGetExternal(name, input, false, out data);
			}
		}

		internal bool TryGetContext(string name, object input, out ContextValue value) {
			Object data;
			if (Store.TryGetValue(name, out value)) {
				return true;
			} else if (TryGetExternal(name, input, true, out data)) {
				value = (ContextValue)data;
				return true;
			} else {
				value = null;
				return false;
			}
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
		public ISet<string> NewSet() {
			return CaseSensitive ? new HashSet<string>() : new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);
		}
		public void Compile() {
			Dependencies.Clear();
			foreach (ContextValue value in Store.Values) {
				if (value.ContextType == ContextType.Expression) {
					value.Build(Parser, this, null);
				}
			}
			foreach (ContextValue value in Store.Values) {
				if (value.ContextType == ContextType.Expression) {
					AddDependency(Dependencies, value.Name, value.Dependees);
				}
			}
		}
		public void CheckCircularReference(object input) {
			ISet<string> chain = NewSet();
			foreach (ContextValue value in Store.Values) {
				if (value.ContextType == ContextType.Expression) {
					value.CheckCircularReference(Parser, this, chain, input);
				}
			}
		}
		void AddDependency(IDictionary<string, HashSet<string>> dict, string depender, IEnumerable<string> dependees) {
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
