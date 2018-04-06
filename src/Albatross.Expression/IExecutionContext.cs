using Albatross.Expression.Exceptions;
using Albatross.Expression.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Albatross.Expression {
	public delegate bool TryGetValueDelegate(string name, object input, out object value);
	public interface IExecutionContext:IEnumerable<ContextValue> {
		bool CaseSensitive { get; }
		TryGetValueDelegate TryGetExternalData { get; set; }
		IParser Parser { get; }
		bool CacheExternalValue { get; set; }
		void Clear();
		object Eval(string expression, object input, Type outputDataType);
		object GetValue(string name, object input);
		bool TryGetValue(string name, object input, out object data);
		void Set(ContextValue value);
		void Compile();
		void CheckCircularReference(object input);
		ISet<string> NewSet();
		IDictionary<string, HashSet<string>> Dependencies { get; }
		void GetDependants(string name, ISet<string> dependents);
	}
}
