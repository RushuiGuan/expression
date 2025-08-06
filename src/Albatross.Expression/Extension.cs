using Albatross.Expression.Nodes;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Albatross.Expression {
	public static class Extensions {
		public static string ConvertToString(this object obj) {
			if (obj is string text) {
				return text;
			} else if (obj is JsonElement element && element.ValueKind == JsonValueKind.String) {
				return element.GetString() ?? string.Empty;
			} else {
				return obj?.ToString() ?? string.Empty;
			}
		}
		
		public static bool ConvertToBoolean(this object obj) {
			if (obj is double d) {
				return d != 0;
			} else if (obj is bool b) {
				return b;
			} else if (obj is string text && bool.TryParse(text, out b)) {
				return b;
			} else if (obj is JsonElement json) {
				if (json.ValueKind == JsonValueKind.True) {
					return true;
				} else if (json.ValueKind == JsonValueKind.False) {
					return false;
				} else if (json.ValueKind == JsonValueKind.String && bool.TryParse(json.GetString(), out b)) {
					return b;
				}
			}
			throw new FormatException($"Cannot convert {obj} to boolean");
		}

		public static double ConvertToDouble(this object obj) {
			if (obj is double d) {
				return d;
			} else if (obj is string text) {
				if (double.TryParse(text, out d)) {
					return d;
				}
			} else if (obj is JsonElement json) {
				if (json.ValueKind == JsonValueKind.Number) {
					return json.GetDouble();
				} else if (json.ValueKind == JsonValueKind.String && double.TryParse(json.GetString(), out d)) {
					return d;
				}
			}
			throw new FormatException($"Cannot convert {obj} to double");
		}

		public static DateTime ConvertToDateTime(this object obj) {
			if (obj is DateTime value) {
				return value;
			} else if (obj is DateOnly dateOnly) {
				return dateOnly.ToDateTime(TimeOnly.MinValue);
			} else if (obj is string text && DateTime.TryParse(text, out value)) {
				return value;
			} else if (obj is JsonElement json && json.ValueKind == JsonValueKind.String && DateTime.TryParse(json.GetString(), out value)) {
				return value;
			}
			throw new FormatException($"Cannot convert {obj} to DateTime");
		}

		public static int ConvertToInt(this object obj) {
			if (obj is double d) {
				return (int)Math.Round(d, 0, MidpointRounding.AwayFromZero);
			} else if (obj is string text && int.TryParse(text, out var value)) {
				return value;
			} else if (obj is JsonElement json) {
				if (json.ValueKind == JsonValueKind.Number) {
					return json.GetInt32();
				} else if (json.ValueKind == JsonValueKind.String && int.TryParse(json.GetString(), out value)) {
					return value;
				}
			}
			throw new FormatException($"Cannot convert {obj} to int");
		}

		public static JsonElement ConvertToJsonElement(this object obj) {
			if (obj is JsonElement elem) {
				return elem;
			} else if (obj is string text) {
				try {
					return JsonDocument.Parse(text).RootElement;
				} catch { 
				}
			}
			throw new FormatException($"Cannot convert {obj} to JsonElement");
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
				case JsonValueKind.Array:
					var array = new List<object?>();
					foreach (var item in elem.EnumerateArray()) {
						array.Add(item.GetJsonValue());
					}
					return array;
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