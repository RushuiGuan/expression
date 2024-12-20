﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Exceptions;


namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Prefix if operation</para>
	/// <para>Operand Count: 2 or 3</para>
	/// <list type="number">
	///		<listheader>
	///		<description>Operands</description>
	///		</listheader>
	///		<item><description>condition: any</description></item>
	///		<item><description>result when true: any</description></item>
	///		<item><description>result when false, if omitted, will be default to null: any</description></item>
	/// </list>
	/// 
	/// <para>Output Type: any</para>
	/// <para>Usage: if( 3 > 2, "OK", "No")</para>
	/// </summary>
	[ParserOperation]
	public class If : PrefixOperationToken {

		public override string Name { get { return "If"; } }
		public override int MinOperandCount { get { return 2; } }
		public override int MaxOperandCount { get { return 3; } }
		public override bool Symbolic { get { return false; } }


		public override object? EvalValue(Func<string, object> context) {
			ValidateOperands();
			object obj = Operands.First().EvalValue(context);

			if (obj.ConvertToBoolean()) {
				return Operands[1].EvalValue(context);
			} else {
				if (Operands.Count >= 3) {
					return Operands[2].EvalValue(context);
				} else {
					return null;
				}
			}
		}
	}
}
