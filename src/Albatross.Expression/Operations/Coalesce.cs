﻿using System;
using Albatross.Expression.Tokens;


namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Prefix operation that return the first non null operand</para>
	/// <para>Operand Count: 1 to infinite</para>
	/// <para>Operand Type: any</para>
	/// <para>Example: Coalesce(null, 1, 2, 3) will return 1</para>
	/// </summary>
	[ParserOperation]
	public class Coalesce : PrefixOperationToken {

		public override string Name { get { return "Coalesce"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return int.MaxValue; } }
		public override bool Symbolic { get { return false; } }

		public override object? EvalValue(Func<string, object> context) {
			var list = GetOperands(context);
			foreach (object? obj in list) {
				if (obj != null) {
					return obj;
				}
			}
			return null;
		}
	}
}
