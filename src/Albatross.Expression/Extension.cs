﻿using Albatross.Expression.Exceptions;
using Albatross.Expression.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

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

		public static object GetJsonValue(this JsonElement elem) {
			switch (elem.ValueKind) {
				case JsonValueKind.Array:
					return elem;
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
			context.Set(new ContextValue() { Name = name, Value = expression, ContextType = ContextType.Expression, });
		}
		public static void SetExpression<T>(this IExecutionContext<T> context, string name, string expression, Type dataType) {
			context.Set(new ContextValue() { Name = name, Value = expression, ContextType = ContextType.Expression, DataType = dataType });
		}
		public static void SetValue<T>(this IExecutionContext<T> context, string name, object value) {
			context.Set(new ContextValue() { Name = name, Value = value, ContextType = ContextType.Value, });
		}
		public static object GetValue<T>(this IExecutionContext<T> context, string name, T input) {
			object data;
			if (context.TryGetValue(name, input, out data)) {
				return data;
			} else {
				return null;
			}
		}
		public static ContextValue Set<T>(this IExecutionContext<T> context, string assignmentExpression) {
			ContextValue value = new ContextValue {
				ContextType = ContextType.Expression,
			};
			IToken token = context.Parser.VariableToken();
			int start = 0, next;
			if (token.Match(assignmentExpression, start, out next)) {
				start = assignmentExpression.SkipSpace(start);
				value.Name = assignmentExpression.Substring(start, next - start);
				start = next;
				if (new AssignmentToken().Match(assignmentExpression, start, out next)) {
					value.Value = assignmentExpression.Substring(next);
					context.Set(value);
					return value;
				}
			}
			throw new Exceptions.TokenParsingException("Invalid assignment expression");
		}
		public static ValueType Eval<T, ValueType>(this IExecutionContext<T> context, string expression, T input) {
			object result = context.Eval(expression, input, typeof(ValueType));
			return (ValueType)Convert.ChangeType(result, typeof(ValueType));
		}
		public static bool TryGetValue<T, ValueType>(this IExecutionContext<T> context, string name, T input, out ValueType data) {
			if (context.TryGetValue(name, input, out object value)){
				data = (ValueType)Convert.ChangeType(value, typeof(ValueType));
				return true;
			} else {
				data = default(ValueType);
				return false;
			}
		}
		#endregion

		#region IToken
		public static bool IsVariable(this IToken token) {
			return token is IVariableToken;
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
		public static IToken Compile(this IParser parser, string expression) {
			Queue<IToken> queue = parser.Tokenize(expression);
			Stack<IToken> stack = parser.BuildStack(queue);
			return parser.CreateTree(stack);
		}
		#endregion
	}
}
