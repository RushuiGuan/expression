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
	/// <summary>
	/// instead of using a default static method to create the parser.  The new Parser concret class
	/// has a constructor with its operations.  The operations can be preregistered using an IOC container.
	/// Containers such as SimpleInjector supports Registrations of collections are very handy.
	/// </summary>
	[TestFixture]
	public class iocSample {
		Container _container;

		[OneTimeSetUp]
		public void Setup() {
			_container = new Container();
			//register the operations collection
			_container.RegisterCollection<IToken>(
				new Type[] {
					typeof(And),
					typeof(Albatross.Expression.Operations.Array),
					typeof(Avg),
					typeof(Coalesce),
					typeof(CurrentUser),
					typeof(CurrentMachine),
					typeof(CurrentApp),
					typeof(Divide),
					typeof(Equal),
					typeof(Format),
					typeof(GreaterEqual),
					typeof(GreaterThan),
					typeof(If),
					typeof(IsBlank),
					typeof(LessEqual),
					typeof(LessThan),
					typeof(Len),
					typeof(Max),
					typeof(Min),
					typeof(Minus),
					typeof(Mod),
					typeof(Month),
					typeof(MonthName),
					typeof(Multiply),
					typeof(Negative),
					typeof(Not),
					typeof(NotEqual),
					typeof(Now),
					typeof(Or),
					typeof(PadLeft),
					typeof(PadRight),
					typeof(Plus),
					typeof(Positive),
					typeof(Power),
					typeof(ShortMonthName),
					typeof(Text),
					typeof(Today),
					typeof(Year),
					typeof(Date),
				}
			);
			//register parser and the execution context factory class
			_container.Register<IParser, Parser>();
			_container.Register<IVariableToken, VariableToken>();
			_container.Register<IStringLiteralToken, StringLiteralToken>();
			_container.Register<IExecutionContextFactory, ExecutionContextFactory>();
		}

		[Test]
		public void Test() {
			IExecutionContextFactory factory = _container.GetInstance<IExecutionContextFactory>();
			IExecutionContext context = factory.Create(false);
			object result = context.Eval("1+1", null, typeof(int));
			Assert.AreEqual(result, 2);

			result = context.Eval("avg(1, 2)", null, typeof(decimal));
			Assert.AreEqual(result, 1.5);
		}


		[OneTimeTearDown]
		public void TearDown() {
			_container.Dispose();
		}
	}
}
