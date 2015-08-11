using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Albatross.Expression.Utils {
	public static class Ext {
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
		public static HashSet<T> AddRange<T>(this HashSet<T> set, IEnumerable<T> range) {
			foreach (T t in range) {
				set.Add(t);
			}
			return set;
		}
	}
}
