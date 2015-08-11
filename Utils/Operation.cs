using Albatross.Expression.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Albatross.Expression.Utils {
	public static class Operation {
		public static object GetMax<T>(IEnumerable<object> list) where T : struct {
			T? t = null;
			foreach (T? item in list) {
				if (item.HasValue) {
					if (t.HasValue) {
						if (Comparer<T>.Default.Compare(item.Value, t.Value) > 0) {
							t = item.Value;
						}
					} else {
						t = item;
					}
				}
			}
			if (t.HasValue) {
				return t.Value;
			} else {
				return null;
			}
		}
		public static object GetMaxString(IEnumerable<object> list) {
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
		public static object GetMin<T>(IEnumerable<object> list) where T : struct {
			T? t = null;
			foreach (T? item in list) {
				if (item.HasValue) {
					if (t.HasValue) {
						if (Comparer<T>.Default.Compare(item.Value, t.Value) < 0) {
							t = item.Value;
						}
					} else {
						t = item;
					}
				}
			}
			if (t.HasValue) {
				return t.Value;
			} else {
				return null;
			}
		}
		public static object GetMinString(IEnumerable<object> list) {
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
	}
}