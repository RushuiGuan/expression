using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Albatross.Expression {
	public class ReflectionExecutionContextFactory<T> : IExecutionContextFactory<T> {
		IParser parser;

		public bool CaseSensitive { get { return true; } set { } }
		public bool CacheExternalValue { get; set; }
		public bool FailWhenMissingVariable { get; set; }

		Dictionary<string, PropertyInfo> properties = new Dictionary<string, PropertyInfo>();


		public ReflectionExecutionContextFactory(IParser parser) {
			this.parser = parser;
			CacheExternalValue = false;
			FailWhenMissingVariable = true;

			foreach (var property in typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty)) {
				properties[property.Name] = property;
			}
		}

		public IExecutionContext<T> Create() {
			return new ExecutionContext<T>(parser, CaseSensitive, CacheExternalValue, FailWhenMissingVariable, TryGetExternalValue);
		}

		public bool TryGetExternalValue(string name, T obj, out object value) {
			PropertyInfo property;
			if (obj != null && properties.TryGetValue(name, out property)) {
				value = property.GetValue(obj);
				return true;
			}
			value = null;
			return false;
		}
	}
}
