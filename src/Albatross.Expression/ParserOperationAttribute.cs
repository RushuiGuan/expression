using System;
using System.Collections.Generic;
using System.Text;

namespace Albatross.Expression
{
	[AttributeUsage(AttributeTargets.Class)]
    public class ParserOperationAttribute : Attribute
    {
		public string Description { get; set; }
		public string Group { get; set; }
	}
}
