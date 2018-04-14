using Albatross.Expression.Exceptions;
using Albatross.Expression.Tokens;
using System;
using System.Collections.Generic;

namespace Albatross.Expression {
	public enum ContextType {
		Value = 0, Expression = 1, 
	}
	public class ContextValue {
		public ContextValue() { }
		public ContextValue(string name, object value) {
			Name = name;
			Value = value;
			ContextType = ContextType.Expression;
		}

		public string Name { get; set; }
		public object Value { get; set; }
		public ContextType ContextType { get; set; }
		public bool External { get; set; }

		public Type DataType { get; set; }
		public IToken Tree { get; set; }
		/// <summary>
		/// If this context value is a variable, Dependees will contain the set of variables that it depends on
		/// </summary>
		public ISet<string> Dependees { get; set; }
	}
}
