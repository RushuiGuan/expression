using Albatross.Expression.Documentation;
using NUnit.Framework;
using System.Linq;

namespace Albatross.Expression.Test.Documentation
{
    [TestFixture]
    [Category("Documentation")]
    public class DocGenerateTest
    {
        [Test]
        public void GenerateDocs()
        {
            var list = DocGenerator.Generate();

            Assert.IsTrue(list.Count > 0);

            Assert.IsFalse(list.Any(x => x.Description == null));
        }
    }
}
