using Albatross.Expression.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Albatross.Expression.Nodes {
	public static class PrefixExpressionExtensions {
		public static object GetValue(this PrefixExpression expression, int index, Func<string, object> context) {
			if (index >= expression.Operands.Count) {
				throw new OperandException($"prefix expression {expression.Name} is missing operand at position {index}");
			}
			return expression.Operands[index].Eval(context);
		}

		public static async Task<object> GetValueAsync(this PrefixExpression expression, int index, Func<string, Task<object>> context) {
			if (index >= expression.Operands.Count) {
				throw new OperandException($"prefix expression {expression.Name} is missing operand at position {index}");
			}
			return await expression.Operands[index].EvalAsync(context);
		}

		public static string GetStringValue(this PrefixExpression expression, int index, Func<string, object> context) {
			var value = expression.GetValue(index, context);
			return $"{value}";
		}

		public static async Task<string> GetStringValueAsync(this PrefixExpression expression, int index, Func<string, Task<object>> context) {
			var value = await expression.GetValueAsync(index, context);
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

		public static async Task<string> GetRequiredStringValueAsync(this PrefixExpression expression, int index, Func<string, Task<object>> context) {
			var value = await expression.GetValueAsync(index, context);
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

		public static async Task<List<Object>> GetValuesAsync(this PrefixExpression expression, Func<string, Task<object>> context) {
			var list = new List<object>();
			foreach (var token in expression.Operands) {
				var value = await token.EvalAsync(context);
				list.Add(value);
			}
			return list;
		}

		public static string GetRequiredStringValue(this List<object> list, int index) {
			var value = list[index];
			string result = $"{value}".Trim();
			if (result == string.Empty) {
				throw new OperandException($"prefix expression is missing required string operand at position {index}");
			} else {
				return result;
			}
		}
	}
}