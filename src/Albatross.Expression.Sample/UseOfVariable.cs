using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Albatross.Expression.Sample
{
	/// <summary>
	/// This class provide examples on how to use variables with the <see cref="Albatross.Expression.Parser"/> class.  Note that the <see cref="Albatross.Expression.ExecutionContext{T}"/> class
	/// is created to provide better variable support and should be the preferred method of using parser with variables.
	/// </summary>
	[TestFixture]
    public class UseOfVariable
    {
		[TestCase("a + b * c", ExpectedResult = 7)]
		[TestCase("a + b + c", ExpectedResult =6)]
		public object Run(string expression) {
			Func<string, object> func = name => {
				switch (name.ToLower()) {
					case "a":
						return 1;
					case "b":
						return 2;
					case "c":
						return 3;
					default:
						return null;
				}
			};

			IParser parser = Factory.Instance.Create();
			return parser.Compile(expression).EvalValue(func);
		}
    }
}
