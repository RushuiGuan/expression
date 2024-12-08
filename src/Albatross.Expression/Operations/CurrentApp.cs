﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Exceptions;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Prefix operation that returns the current app domain friendly name</para>
	/// <para>Operand Count: 0</para>
	/// <para>Output Type: string</para>
	/// </summary>
	[ParserOperation]
	public class CurrentApp : PrefixOperationToken {
		
		public override string Name { get { return "CurrentApp"; } }
		public override int MinOperandCount { get { return 0; } }
		public override int MaxOperandCount { get { return 0; } }
		public override bool Symbolic { get { return false; } }

		public override object? EvalValue(Func<string, object> context) {
			return AppDomain.CurrentDomain.FriendlyName;
		}
	}
}
