using Albatross.Expression.Exceptions;
using System;
using System.Collections.Generic;

namespace Albatross.Expression.Nodes {
	public static class PrefixExpressionExtensions {
		public static object GetValue(this PrefixExpression expression, int index, Func<string, object> context) {
			if (index >= expression.Operands.Count) {
				throw new OperandException($"prefix expression {expression.Name} is missing operand at position {index}");
			}
			return expression.Operands[index].Eval(context);
		}

		public static string GetStringValue(this PrefixExpression expression, int index, Func<string, object> context) {
			var value = expression.GetValue(index, context);
			return $"{value}";
		}

		public static string GetRequiredStringValue(this PrefixExpression expression, int index, Func<string, object> context) {
			var value = expression.GetValue(index, context);
			string result = $"{value}".Trim();
			if (result == string.Empty) {
				throw new OperandException($"prefix expression {expression.Name} is missing required string operand at position {index}");
			} else {
				return result;
			}
		}

		public static List<Object> GetValues(this PrefixExpression expression, Func<string, object> context) {
			var list = new List<object>();
			foreach (var token in expression.Operands) {
				var value = token.Eval(context);
				list.Add(value);
			}
			return list;
		}
	}
}