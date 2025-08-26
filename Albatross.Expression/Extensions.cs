using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Albatross.Expression {
	/// <summary>
	/// Provides extension methods for type conversion and object manipulation within the Expression framework.
	/// </summary>
	public static class Extensions {
		/// <summary>
		/// Converts an object to its string representation, handling JsonElement and other types.
		/// </summary>
		/// <param name="obj">The object to convert to string.</param>
		/// <returns>A string representation of the object, or an empty string if the object is null.</returns>
		public static string ConvertToString(this object obj) {
			if (obj is string text) {
				return text;
			} else if (obj is JsonElement element && element.ValueKind == JsonValueKind.String) {
				return element.GetString() ?? string.Empty;
			} else {
				return obj?.ToString() ?? string.Empty;
			}
		}
		
		/// <summary>
		/// Converts an object to a boolean value with support for various input types.
		/// </summary>
		/// <param name="obj">The object to convert to boolean.</param>
		/// <returns>The boolean representation of the object.</returns>
		/// <exception cref="FormatException">Thrown when the object cannot be converted to boolean.</exception>
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

		/// <summary>
		/// Converts an object to a double value with support for various numeric types.
		/// </summary>
		/// <param name="obj">The object to convert to double.</param>
		/// <returns>The double representation of the object.</returns>
		/// <exception cref="FormatException">Thrown when the object cannot be converted to double.</exception>
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
			} else {
				return Convert.ToDouble(obj);
			}
			throw new FormatException($"Cannot convert {obj} to double");
		}

		/// <summary>
		/// Converts an object to a DateTime value with support for various date types.
		/// </summary>
		/// <param name="obj">The object to convert to DateTime.</param>
		/// <returns>The DateTime representation of the object.</returns>
		/// <exception cref="FormatException">Thrown when the object cannot be converted to DateTime.</exception>
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

		/// <summary>
		/// Converts an object to an integer value with rounding for double values.
		/// </summary>
		/// <param name="obj">The object to convert to int.</param>
		/// <returns>The integer representation of the object.</returns>
		/// <exception cref="FormatException">Thrown when the object cannot be converted to int.</exception>
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

		/// <summary>
		/// Converts an object to a JsonElement by parsing string content or returning existing JsonElement.
		/// </summary>
		/// <param name="obj">The object to convert to JsonElement.</param>
		/// <returns>A JsonElement representation of the object.</returns>
		/// <exception cref="FormatException">Thrown when the object cannot be converted to JsonElement.</exception>
		public static JsonElement ConvertToJsonElement(this object obj) {
			if (obj is JsonElement elem) {
				return elem;
			} else if (obj is string text) {
				try {
					return JsonDocument.Parse(text).RootElement;
				} catch {
					// ignored
				}
			}
			throw new FormatException($"Cannot convert {obj} to JsonElement");
		}

		/// <summary>
		/// Extracts the underlying value from a JsonElement into appropriate .NET types.
		/// </summary>
		/// <param name="elem">The JsonElement to extract value from.</param>
		/// <returns>The underlying value as a .NET object, or null for null/undefined JSON values.</returns>
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
	}
}