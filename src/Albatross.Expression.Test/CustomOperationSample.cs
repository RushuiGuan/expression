using Albatross.Expression.Operations;
using Albatross.Expression.Tokens;
using NUnit.Framework;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.Expression.Test {
	[ParserOperation]
	public class Sin : PrefixOperationToken {
		public override IToken Clone() {
			return new Sin();
		}
		public override int MaxOperandCount => 1;
		public override int MinOperandCount => 1;
		public override string Name => "custom_sin";
		public override bool Symbolic => false;
		public override object EvalValue(Func<string, object> context) {
			double input = base.GetOperands<double>(context).First<double>();
			return Math.Sin(input);
		}
	}

	[ParserOperation]
	public class AbsoluteMax : PrefixOperationToken {

		public override string Name { get { return "max"; } }
		public override int MinOperandCount { get { return 0; } }
		public override int MaxOperandCount { get { return int.MaxValue; } }
		public override bool Symbolic { get { return false; } }


		public override object EvalValue(Func<string, object> context) {
			if (Operands.Count == 0) { return null; }
			var items = GetOperands<double>(context);
			double max = items.First();
			foreach (var item in items) {
				if (max < Math.Abs(item)) {
					max = Math.Abs(item);
				}
			}
			return max;
		}
	}

	[TestFixture]
	public class CustomOperationSample {

		[TestCase("custom_sin(pi()/2)", ExpectedResult = 1)]
		public object TestCustomOperation(string expression) {
			Factory factory = new Factory().Register(this.GetType().Assembly);
			return factory.Create().Compile(expression).EvalValue(null);
		}

		[TestCase("max(-1, -2, -3)", ExpectedResult = -1)]
		public object TestDefaultMaxOperation(string expression) {
			Factory factory = new Factory();
			return factory.Create().Compile(expression).EvalValue(null);
		}

		[TestCase("max(-1, -2, -3)", ExpectedResult = 3)]
		public object TestOverrideMaxOperation(string expression) {
			Factory factory = new Factory().Replace<Max, AbsoluteMax>();
			return factory.Create().Compile(expression).EvalValue(null);
		}
	}
}
