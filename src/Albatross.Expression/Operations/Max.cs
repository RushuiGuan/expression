using System;
using System.Collections.Generic;
using Albatross.Expression.Nodes;
using Albatross.Expression.Exceptions;
using System.Collections;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Max : PrefixExpression {
		public Max() : base("max", 0, int.MaxValue) { }

		public override object? Eval(Func<string, object> context) {
			if (Operands.Count == 0) { return null; }
			Type type;
			IEnumerable list = GetParamsOperands(context, out type);

			if (type == null) {
				return null;
			} else if (type == typeof(double)) {
				return GetMax<double>(list);
			} else if (type == typeof(DateTime)) {
				return GetMax<DateTime>(list);
			} else if (type == typeof(string)) {
				return GetMaxString(list);
			} else {
				throw new UnexpectedTypeException(type);
			}
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
	}
}
