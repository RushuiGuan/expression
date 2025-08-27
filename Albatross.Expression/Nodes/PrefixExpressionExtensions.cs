using Albatross.Expression.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Albatross.Expression.Nodes {
	/// <summary>
	/// Extension methods for IPrefixExpression that provide convenient operand access and validation.
	/// Simplifies getting values from prefix expression operands with type conversion and error handling.
	/// </summary>
	public static class PrefixExpressionExtensions {
		/// <summary>
		/// Gets the evaluated value of an operand at the specified index.
		/// </summary>
		/// <param name="expression">The prefix expression containing the operands.</param>
		/// <param name="index">The zero-based index of the operand.</param>
		/// <param name="context">Function to resolve variable values during evaluation.</param>
		/// <returns>The evaluated value of the operand.</returns>
		/// <exception cref="OperandException">Thrown when the index is out of range.</exception>
		public static object GetValue(this IPrefixExpression expression, int index, Func<string, object> context) {
			if (index >= expression.Operands.Count) {
				throw new OperandException($"prefix expression {expression.Name} is missing operand at position {index}");
			}
			return expression.Operands[index].Eval(context);
		}

		/// <summary>
		/// Asynchronously gets the evaluated value of an operand at the specified index.
		/// </summary>
		/// <param name="expression">The prefix expression containing the operands.</param>
		/// <param name="index">The zero-based index of the operand.</param>
		/// <param name="context">Async function to resolve variable values during evaluation.</param>
		/// <returns>A task containing the evaluated value of the operand.</returns>
		/// <exception cref="OperandException">Thrown when the index is out of range.</exception>
		public static async Task<object> GetValueAsync(this IPrefixExpression expression, int index, Func<string, Task<object>> context) {
			if (index >= expression.Operands.Count) {
				throw new OperandException($"prefix expression {expression.Name} is missing operand at position {index}");
			}
			return await expression.Operands[index].EvalAsync(context);
		}

		/// <summary>
		/// Gets the string representation of an operand value at the specified index.
		/// </summary>
		/// <param name="expression">The prefix expression containing the operands.</param>
		/// <param name="index">The zero-based index of the operand.</param>
		/// <param name="context">Function to resolve variable values during evaluation.</param>
		/// <returns>The string representation of the operand value.</returns>
		/// <exception cref="OperandException">Thrown when the index is out of range.</exception>
		public static string GetStringValue(this IPrefixExpression expression, int index, Func<string, object> context) {
			var value = expression.GetValue(index, context);
			return $"{value}";
		}

		/// <summary>
		/// Asynchronously gets the string representation of an operand value at the specified index.
		/// </summary>
		/// <param name="expression">The prefix expression containing the operands.</param>
		/// <param name="index">The zero-based index of the operand.</param>
		/// <param name="context">Async function to resolve variable values during evaluation.</param>
		/// <returns>A task containing the string representation of the operand value.</returns>
		/// <exception cref="OperandException">Thrown when the index is out of range.</exception>
		public static async Task<string> GetStringValueAsync(this IPrefixExpression expression, int index, Func<string, Task<object>> context) {
			var value = await expression.GetValueAsync(index, context);
			return $"{value}";
		}

		/// <summary>
		/// Gets a required non-empty string value of an operand at the specified index.
		/// Trims whitespace and throws an exception if the result is empty.
		/// </summary>
		/// <param name="expression">The prefix expression containing the operands.</param>
		/// <param name="index">The zero-based index of the operand.</param>
		/// <param name="context">Function to resolve variable values during evaluation.</param>
		/// <returns>The trimmed string value of the operand.</returns>
		/// <exception cref="OperandException">Thrown when the index is out of range or the string value is empty after trimming.</exception>
		public static string GetRequiredStringValue(this IPrefixExpression expression, int index, Func<string, object> context) {
			var value = expression.GetValue(index, context);
			string result = $"{value}".Trim();
			if (result == string.Empty) {
				throw new OperandException($"prefix expression {expression.Name} is missing required string operand at position {index}");
			} else {
				return result;
			}
		}

		/// <summary>
		/// Asynchronously gets a required non-empty string value of an operand at the specified index.
		/// Trims whitespace and throws an exception if the result is empty.
		/// </summary>
		/// <param name="expression">The prefix expression containing the operands.</param>
		/// <param name="index">The zero-based index of the operand.</param>
		/// <param name="context">Async function to resolve variable values during evaluation.</param>
		/// <returns>A task containing the trimmed string value of the operand.</returns>
		/// <exception cref="OperandException">Thrown when the index is out of range or the string value is empty after trimming.</exception>
		public static async Task<string> GetRequiredStringValueAsync(this IPrefixExpression expression, int index, Func<string, Task<object>> context) {
			var value = await expression.GetValueAsync(index, context);
			string result = $"{value}".Trim();
			if (result == string.Empty) {
				throw new OperandException($"prefix expression {expression.Name} is missing required string operand at position {index}");
			} else {
				return result;
			}
		}

		/// <summary>
		/// Gets all operand values as a list by evaluating each operand.
		/// </summary>
		/// <param name="expression">The prefix expression containing the operands.</param>
		/// <param name="context">Function to resolve variable values during evaluation.</param>
		/// <returns>A list containing the evaluated values of all operands.</returns>
		public static List<Object> GetValues(this IPrefixExpression expression, Func<string, object> context) {
			var list = new List<object>();
			foreach (var token in expression.Operands) {
				var value = token.Eval(context);
				list.Add(value);
			}
			return list;
		}

		/// <summary>
		/// Asynchronously gets all operand values as a list by evaluating each operand.
		/// </summary>
		/// <param name="expression">The prefix expression containing the operands.</param>
		/// <param name="context">Async function to resolve variable values during evaluation.</param>
		/// <returns>A task containing a list of evaluated values of all operands.</returns>
		public static async Task<List<Object>> GetValuesAsync(this IPrefixExpression expression, Func<string, Task<object>> context) {
			var list = new List<object>();
			foreach (var token in expression.Operands) {
				var value = await token.EvalAsync(context);
				list.Add(value);
			}
			return list;
		}

		/// <summary>
		/// Gets a required non-empty string value from a list at the specified index.
		/// Trims whitespace and throws an exception if the result is empty.
		/// </summary>
		/// <param name="list">The list of values.</param>
		/// <param name="index">The zero-based index of the value.</param>
		/// <returns>The trimmed string value at the specified index.</returns>
		/// <exception cref="OperandException">Thrown when the string value is empty after trimming.</exception>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the index is out of range.</exception>
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