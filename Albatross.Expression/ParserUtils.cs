using Albatross.Expression.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Albatross.Expression {
	public static class ParserUtils {
		public static Stack<T> Reverse<T>(this Stack<T> src) {
			Stack<T> dst = new Stack<T>();
			while (src.Count > 0) {
				dst.Push(src.Pop());
			}
			return dst;
		}
		public static bool IsNumeric(object obj) {
			return obj is sbyte || obj is byte
				|| obj is ushort || obj is short
				|| obj is uint || obj is int
				|| obj is ulong || obj is long
				|| obj is float
				|| obj is decimal
				|| obj is double;
		}
		public static bool IsInteger(object obj) {
			return obj is sbyte || obj is byte
				|| obj is ushort || obj is short
				|| obj is uint || obj is int
				|| obj is ulong || obj is long;
		}
		public static ISet<T> AddRange<T>(this ISet<T> set, IEnumerable<T> range) {
			foreach (T t in range) {
				set.Add(t);
			}
			return set;
		}
		public static object GetMax<T>(IEnumerable list) where T : struct {
			T? t = null;
			try {
				foreach (T? item in list) {
					if (item != null) {
						if (t.HasValue) {
							if (Comparer<T>.Default.Compare(item.Value, t.Value) > 0) {
								t = item.Value;
							}
						} else {
							t = item.Value;
						}
					}
				}
			} catch (InvalidCastException) {
				throw new UnexpectedTypeException();
			}
			if (t.HasValue) {
				return t.Value;
			} else {
				return null;
			}
		}
		public static object GetMaxString(IEnumerable list) {
			string max = null, item;
			foreach (object obj in list) {
				item = Convert.ToString(obj);
				if (item != null) {
					if (max == null) {
						max = item;
					} else if (string.Compare(item, max) > 0) {
						max = item;
					}
				}
			}
			return max;
		}
		public static object GetMin<T>(IEnumerable list) where T : struct {
			T? t = null;
			try {
				foreach (T? item in list) {
					if (item != null) {
						if (t.HasValue) {
							if (Comparer<T>.Default.Compare(item.Value, t.Value) < 0) {
								t = item.Value;
							}
						} else {
							t = item.Value;
						}
					}
				}
			} catch (InvalidCastException) {
				throw new UnexpectedTypeException();
			}
			if (t.HasValue) {
				return t.Value;
			} else {
				return null;
			}
		}
		public static object GetMinString(IEnumerable list) {
			string max = null, item;
			foreach (object obj in list) {
				item = Convert.ToString(obj);
				if (item != null) {
					if (max == null) {
						max = item;
					} else if (string.Compare(item, max) < 0) {
						max = item;
					}
				}
			}
			return max;
		}
		public static bool GetLogicalValue(object obj) {
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

		public static StringBuilder ConcatenateText(this StringBuilder sb, char delimiter, string text) {
			if (sb == null) { sb = new StringBuilder(); } else { sb.Append("+"); }
			text = text.Replace(delimiter.ToString(), $"\\{delimiter}");
			sb.Append($"{delimiter}{text}{delimiter}");
			return sb;
		}
		public static StringBuilder ConcatenateExpression(this StringBuilder sb, string expression) {
			if (sb == null) { sb = new StringBuilder(); } else { sb.Append("+"); }
			sb.Append($"{expression}");
			return sb;
		}
	}
}
