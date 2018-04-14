using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.Expression.Test
{
	[TestFixture]
    public class CodeCheck {

		[Test]
		public void ArrayLiteral() {
			var x = new[] { 1,2,3};
			Assert.AreEqual(typeof(int[]), x.GetType());
		}

		[Test]
		public void DictionaryLiteral() {
			var x = new Dictionary<string, object> { { "1", 2} };
		}
    }
}
