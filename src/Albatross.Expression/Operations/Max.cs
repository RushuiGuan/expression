using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Exceptions;
using System.Collections;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Documentation;

namespace Albatross.Expression.Operations {
	[OperationDoc(Group.Boolean, "{token}(@v1, @v2, ...)",
		@"
### Returns the largest of the given numbers.

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
		@"
{token}(1,2,3)
        "
	)]
	[ParserOperation]
	public class Max : PrefixOperationToken {
		
		public override string Name { get { return "max"; } }
		public override int MinOperandCount { get { return 0; } }
		public override int MaxOperandCount { get { return int.MaxValue; } }
		public override bool Symbolic { get { return false; } }


		public override object EvalValue(Func<string, object> context) {
			if (Operands.Count == 0) { return null; }
            System.Type type;
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
