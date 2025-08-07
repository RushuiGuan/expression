using Albatross.Expression.Nodes;
using System;
using System.Collections.Generic;

namespace Albatross.Expression {
	public enum ContextType {
		Value = 0, Expression = 1, 
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
}
