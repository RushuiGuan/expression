using Albatross.Expression.Exceptions;
using Albatross.Expression.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Albatross.Expression {
	public static class Extensions {
		public static bool ConvertToBoolean(this object obj) {
			if (obj != null) {
				if (obj is double) {
					return (double)obj != 0;
				} else if (obj is bool) {
					return (bool)obj;
				} else {
					return true;
				}

			} else {
				return false;
			}
		}

		#region IExecutionContext
		public static void SetExpression(this IExecutionContext context, string name, string expression) {
			context.Set(new ContextValue() { Name = name, Value = expression, ContextType = ContextType.Expression, });
		}
		public static void SetExpression(this IExecutionContext context, string name, string expression, Type dataType) {
			context.Set(new ContextValue() { Name = name, Value = expression, ContextType = ContextType.Expression, DataType = dataType });
		}
		public static void SetValue(this IExecutionContext context, string name, object value) {
			context.Set(new ContextValue() { Name = name, Value = value, ContextType = ContextType.Value, });
		}
		#endregion

		#region IToken
		public static bool IsVariable(this IToken token) {
			return token is IVariableToken;
		}
		#endregion
	}
}
