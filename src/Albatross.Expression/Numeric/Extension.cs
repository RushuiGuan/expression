using Albatross.Expression.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Albatross.Expression.Numeric {
	public static class Extension {
		public static bool IsNumericType(this Type type) {
			switch (Type.GetTypeCode(type)) {
				case TypeCode.Byte:
				case TypeCode.SByte:
				case TypeCode.UInt16:
				case TypeCode.UInt32:
				case TypeCode.UInt64:
				case TypeCode.Int16:
				case TypeCode.Int32:
				case TypeCode.Int64:
				case TypeCode.Decimal:
				case TypeCode.Double:
				case TypeCode.Single:
					return true;
				default:
					return false;
			}
		}
		public static void EnsureNumericType(this Type type) {
			if (!type.IsNumericType()) {
				throw new UnexpectedTypeException($"{type.Name} is not a numeric type");
			}
		}
	}
}
