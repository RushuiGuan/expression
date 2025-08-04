﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Albatross.Expression.Exceptions;

namespace Albatross.Expression.Tokens {
	/// <summary>
	/// will take any string literal enclosed by double quotes.  use back slash to escape.  
	/// Check the GetStringEscape function for escapable chars
	/// </summary>
	public class SingleQuoteStringLiteralToken :StringLiteralToken {
		public override char Boundary => '\'';
		public override INode Clone() {
			return new SingleQuoteStringLiteralToken();
		}
	}
}