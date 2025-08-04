using Albatross.Expression.Nodes;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Albatross.Expression.Exceptions;
using NUnit.Framework.Legacy;

namespace Albatross.Expression.Test
{
	[TestFixture]
    public class RegisterTokenInstancesTest
    {
		[Test]
		public void CanRegisterTokenInstance() {
			//Assemble
			var parser = new Factory().Register(new[] { new MyToken() }).Create();

			var ctx = new ExecutionContext<object>(parser, false, false, false, null);

			//Act
			var retval = (double)ctx.Eval("MyToken(1)", null);

			//Assert
			ClassicAssert.AreEqual(1, retval);
		}

		[Test]
		public void TokensWithoutParserOperationAttributeAreNotRegistered() {
			//Assemble
			var parser = new Factory().Create();

			var ctx = new ExecutionContext<object>(parser, false, false, false, null);

			//Act & Assert
			Assert.Throws<TokenParsingException>(() => ctx.Eval("MyToken(1)", null));
		}

		private class MyToken : PrefixExpression {

			public override string Name => nameof(MyToken);
			public override bool Symbolic => false;
			public override int MinOperandCount => 1;
			public override int MaxOperandCount => 1;

			public override object Eval(Func<string, object> context) {
				if (Operands.Count == 0) { return null; }
				Type type;
				IEnumerable items = GetParamsOperands(context, out type);

				var parms = items.Cast<object>().ToArray();

				return parms[0];
			}
		}

	}
}
