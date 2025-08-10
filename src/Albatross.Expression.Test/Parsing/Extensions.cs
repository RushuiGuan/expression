using Albatross.Expression.ExpressionFactory;
using Albatross.Expression.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Albatross.Expression.Test.Parsing {
	public static class Extensions {
		public static void VerifyValueFactory(this IExpressionFactory<IValueToken> factory, string text, bool parsed, int expected_next, string expected_value) {
			var result = factory.Parse(text, 0, out var next);
			if (parsed) {
				Assert.NotNull(result);
				Assert.Equal(expected_value, result.Value);
				Assert.Equal(expected_next, next);
			} else {
				Assert.Null(result);
			}
		}

	}
}
