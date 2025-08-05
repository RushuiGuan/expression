using Albatross.Expression.Nodes;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Albatross.Expression {
	public static class Extensions {
		public static bool ConvertToBoolean(this object? obj) {
			if (obj != null) {
				if (obj is double d) {
					return d != 0;
				} else if (obj is bool b) {
					return b;
				} else {
					return true;
				}
			} else {
				return false;
			}
		}

		public static object? GetJsonValue(this JsonElement elem) {
			switch (elem.ValueKind) {
				case JsonValueKind.Null:
				case JsonValueKind.Undefined:
					return null;
				case JsonValueKind.True:
					return true;
				case JsonValueKind.False:
					return false;
				case JsonValueKind.Number:
					return elem.GetDouble();
				case JsonValueKind.String:
					return elem.GetString();
				default:
					return elem;
			}
		}

		#region IExecutionContext

		public static void SetExpression<T>(this IExecutionContext<T> context, string name, string expression) {
			context.Set(new ContextValue(name, expression) { ContextType = ContextType.Expression, });
		}

		public static void SetExpression<T>(this IExecutionContext<T> context, string name, string expression, Type dataType) {
			context.Set(new ContextValue(name, expression) { ContextType = ContextType.Expression, DataType = dataType });
		}

		public static void SetValue<T>(this IExecutionContext<T> context, string name, object value) {
			context.Set(new ContextValue(name, value) { ContextType = ContextType.Value });
		}

		public static object? GetValue<T>(this IExecutionContext<T> context, string name, T input) {
			if (context.TryGetValue(name, input, out var data)) {
				return data;
			} else {
				return null;
			}
		}

		public static ValueType Eval<T, ValueType>(this IExecutionContext<T> context, string expression, T input) {
			var result = context.Eval(expression, input, typeof(ValueType));
			return (ValueType)Convert.ChangeType(result, typeof(ValueType));
		}

		public static bool TryGetValue<T, ValueType>(this IExecutionContext<T> context, string name, T input, out ValueType? data) {
			if (context.TryGetValue(name, input, out var value)) {
				data = (ValueType)Convert.ChangeType(value, typeof(ValueType));
				return true;
			} else {
				data = default(ValueType);
				return false;
			}
		}

		#endregion

		#region IToken

		public static bool IsVariable(this INode token) {
			return token is IVariable;
		}

		/// <summary>
		/// Move find the next index that is not a space.  This method doesn't perform check of the starting index in any way.
		/// </summary>
		/// <param name="expression"></param>
		/// <param name="start">The current index</param>
		/// <returns></returns>
		public static int SkipSpace(this string expression, int start) {
			while (expression.Length > start && char.IsWhiteSpace(expression[start])) {
				start++;
			}
			return start;
		}

		#endregion

		#region IParser

		public static INode Compile(this IParser parser, string expression) {
			Queue<INode> queue = parser.Tokenize(expression);
			Stack<INode> stack = parser.BuildStack(queue);
			return parser.CreateTree(stack);
		}

		#endregion
	}
}