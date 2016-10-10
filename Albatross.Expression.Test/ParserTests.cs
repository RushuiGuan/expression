using Albatross.Expression.Exceptions;
using Albatross.Expression.Tokens;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Albatross.Expression.Test {
	[TestFixture]
	[Category("Expression")]
	public class ParserTests {
		//logical
		[TestCase("true and 1", ExpectedResult = true)]
		[TestCase("1 and 1", ExpectedResult = true)]
		[TestCase("null and 1", ExpectedResult = false)]

		[TestCase("not(1)", ExpectedResult = false)]

		[TestCase("0 or \"\"", ExpectedResult = true)]	//blank string is considered as true
		[TestCase("1 or false", ExpectedResult = true)]
		[TestCase("1 or null", ExpectedResult = true)]
		[TestCase("null or 1", ExpectedResult = true)]
		[TestCase("1=2", ExpectedResult = false)]
		[TestCase("1=1", ExpectedResult = true)]

		[TestCase("1>=1", ExpectedResult = true)]
		[TestCase("2>=1", ExpectedResult = true)]
		[TestCase("1>=2", ExpectedResult = false)]
		[TestCase("1>=null", ExpectedResult = false)]

		[TestCase("1<=1", ExpectedResult = true)]
		[TestCase("2<=1", ExpectedResult = false)]
		[TestCase("1<=2", ExpectedResult = true)]
		[TestCase("1<=null", ExpectedResult = false)]

		[TestCase("1<1", ExpectedResult = false)]
		[TestCase("2<1", ExpectedResult = false)]
		[TestCase("1<2", ExpectedResult = true)]
		[TestCase("1<null", ExpectedResult = false)]

		[TestCase("1>1", ExpectedResult = false)]
		[TestCase("2>1", ExpectedResult = true)]
		[TestCase("1>2", ExpectedResult = false)]
		[TestCase("1>null", ExpectedResult = false)]

		[TestCase("1<>1", ExpectedResult = false)]
		[TestCase("1<>2", ExpectedResult = true)]
		[TestCase("1<>null", ExpectedResult = false)]

		[TestCase("if(1, 1, 2)", ExpectedResult = 1)]
		[TestCase("if(0, 1, 2)", ExpectedResult = 2)]
		[TestCase("if(null, 1, 2)", ExpectedResult = 2)]

		//arithmatic
		[TestCase("2*3", ExpectedResult = 6)]
		[TestCase("2*null", ExpectedResult = null)]

		[TestCase("4/2", ExpectedResult = 2)]
		[TestCase("4/0", ExpectedResult = double.PositiveInfinity)]

		[TestCase("-12", ExpectedResult = -12)]
		[TestCase("+12", ExpectedResult = 12)]

		[TestCase("1-2", ExpectedResult = -1)]
		[TestCase("1-null", ExpectedResult = null)]

		[TestCase("1+2", ExpectedResult = 3)]
		[TestCase("1+null", ExpectedResult = null)]

		[TestCase("null%3", ExpectedResult = null)]
		[TestCase("2%3", ExpectedResult = 2)]

		[TestCase("2^3", ExpectedResult = 8)]
		[TestCase("2^null", ExpectedResult = null)]
		[TestCase("null^2", ExpectedResult = null)]

		//text
		[TestCase("isblank(\"\")", ExpectedResult = true)]
		[TestCase("isblank(\"   \")", ExpectedResult = true)]
		[TestCase("isblank(\" a  \")", ExpectedResult = false)]
		[TestCase("isblank(null)", ExpectedResult = true)]

		[TestCase("month(\"2015-5-1\")", ExpectedResult = 5)]
		[TestCase("MonthName(1)", ExpectedResult = "January")]
		[TestCase("ShortMonthName(1)", ExpectedResult = "Jan")]
		[TestCase("Text(1)", ExpectedResult = "1")]
		[TestCase("Year(\"2015-1-1\")", ExpectedResult = 2015)]
		[TestCase("Format(Date(\"2015-2-10\"), \"yyyy-MM-dd\")", ExpectedResult = "2015-02-10")]

		//text
		[TestCase("padleft(1, 3)", ExpectedResult = "  1")]
		[TestCase("padleft(1, 3, 0)", ExpectedResult = "001")]
		[TestCase("padleft(1111, 3, 0)", ExpectedResult = "1111")]

		[TestCase("padright(1, 3)", ExpectedResult = "1  ")]
		[TestCase("padright(1, 3, 0)", ExpectedResult = "100")]
		[TestCase("padright(1111, 3, 0)", ExpectedResult = "1111")]
		
		[TestCase("format(1000, \"#,#\")", ExpectedResult = "1,000")]

		//other functions
		[TestCase("avg(3, 4, 5 )", ExpectedResult = 4)]
		[TestCase("avg(null, 4, 5 )", ExpectedResult = 4.5)]
		[TestCase("avg(0, 4, 5 )", ExpectedResult = 3)]

		[TestCase("coalesce(2, 1)", ExpectedResult = 2)]
		[TestCase("coalesce(null, 1)", ExpectedResult = 1)]

		[TestCase("max(1, 2, 3)", ExpectedResult = 3)]
		[TestCase("max(1, 2, null)", ExpectedResult = 2)]

		[TestCase("min(1, 2, 3)", ExpectedResult = 1)]
		[TestCase("min(null, 1, 3)", ExpectedResult = 1)]
		[TestCase("len(@(null, 1, 3))", ExpectedResult = 3)]
		[TestCase("len(\"abc\")", ExpectedResult = 3)]

		public object OperationsTesting(string expression) {
			return Parser.GetParser().Compile(expression).EvalValue(null);
		}

		[TestCase("1+ 2/2", ExpectedResult = 2)]
		[TestCase("1+ 2*2", ExpectedResult = 5)]
		[TestCase("(1+ 2)*2", ExpectedResult = 6)]
		[TestCase("1* 2* 3", ExpectedResult = 6)]
		[TestCase("1* 2- 3", ExpectedResult = -1)]
		[TestCase("2* 2^3", ExpectedResult = 16)]
		[TestCase("max(6, 2* 2^3)", ExpectedResult = 16)]
		[TestCase("(1 - 1) and (2 + 6)", ExpectedResult = false)]
		[TestCase("1 or 1 and 0", ExpectedResult = true)]
		[TestCase("(1 or 1) and 0", ExpectedResult = false)]
		[TestCase("1--1", ExpectedResult = 2)]
		[TestCase("1-+1", ExpectedResult = 0)]

		[TestCase("10+avg(@(1,2,3,4))", ExpectedResult=12.5)]
		public object PrecedenceTesting(string expression) {
			IParser parser = Parser.GetParser();
			IToken token = parser.Compile(expression);
			return token.EvalValue(null);
		}

		[TestCase("avg(4, 5,\"x\")", typeof(UnexpectedTypeException))]
		[TestCase("min(4, 5,\"x\")", typeof(UnexpectedTypeException))]
		[TestCase("max(4, 5,\"x\")", typeof(UnexpectedTypeException))]
		[TestCase("1 + today()", typeof(UnexpectedTypeException))]
		[TestCase("monthname(today())", typeof(UnexpectedTypeException))]
		[TestCase("len(today())", typeof(UnexpectedTypeException))]
		public void ParsingFailure(string expression, Type errType) {
			TestDelegate handler = new TestDelegate(()=>{
				IParser parser = Parser.GetParser();
				IToken token = parser.Compile(expression);
				token.EvalValue(null);
			});
			Assert.Throws(errType, handler);
		}

		public class CircularReferenceTestCase : IEnumerable {
			public IEnumerator GetEnumerator() {
				object[] obj = new object[] { 
					new ContextValue[]{
						new ContextValue() { ContextType = ContextType.Expression, Name = "a", Value ="b+1"},
						new ContextValue() { ContextType = ContextType.Expression, Name = "b", Value = "a+1" },
					},

					new ContextValue[]{
						new ContextValue() { ContextType = ContextType.Expression, Name = "a", Value ="b+1"},
						new ContextValue() { ContextType = ContextType.Expression, Name = "b", Value = "c+1" },
						new ContextValue() { ContextType = ContextType.Expression, Name = "c", Value = "a+1" },
					},

					new ContextValue[]{
						new ContextValue() { ContextType = ContextType.Expression, Name = "a", Value ="b+c+d+e"},
						new ContextValue() { ContextType = ContextType.Expression, Name = "b", Value = "c+1" },
						new ContextValue() { ContextType = ContextType.Expression, Name = "c", Value = "d+1" },
						new ContextValue() { ContextType = ContextType.Expression, Name = "d", Value = "e+1" },
						new ContextValue() { ContextType = ContextType.Expression, Name = "e", Value = "b+1" },
					},
				};
				return obj.GetEnumerator();
			}
		}

		[TestCaseSource(typeof(CircularReferenceTestCase))]
		public void CircularReferenceTesting1(ContextValue[] values) {
			TestDelegate handle = new TestDelegate(() => {
				ExecutionContext context = new ExecutionContext(Parser.GetParser());
				foreach (ContextValue value in values) {
					context.Set(value);
				}
				context.GetValue("a", null);
			});
			Assert.Throws<CircularReferenceException>(handle);
		}

		[TestCaseSource(typeof(CircularReferenceTestCase))]
		public void CircularReferenceTesting2(ContextValue[] values) {
			TestDelegate handle = new TestDelegate(() => {
				ExecutionContext context = new ExecutionContext(Parser.GetParser());
				foreach (ContextValue value in values) {
					context.Set(value);
				}
				context.GetValue("a", null);
			});
			Assert.Throws<CircularReferenceException>(handle);
		}

		public class ExternalValueTestCase : IEnumerable {
			public IEnumerator GetEnumerator() {
				return new object[] { 
					new TestCaseData(
						new object[]{
							new ContextValue[]{
								new ContextValue(){Name = "a", Value = "b + c + d", ContextType = ContextType.Expression },
								new ContextValue(){Name = "b", Value = 1},
								new ContextValue(){Name = "c", Value = 2},
								new ContextValue(){Name = "d", Value = 3},
						}}){ ExpectedResult = 6},

					new TestCaseData(
						new object[]{
							new ContextValue[]{
								new ContextValue(){Name = "a", Value = "b + c + d", ContextType = ContextType.Expression },
								new ContextValue(){Name = "b", Value = "c + d", ContextType = ContextType.Expression,},
								new ContextValue(){Name = "c", Value = 2},
								new ContextValue(){Name = "d", Value = 3},
						}}){ ExpectedResult = 10},
				}.GetEnumerator();
			}
		}

		[TestCaseSource(typeof(ExternalValueTestCase))]
		public object ExternalValueTestingWithoutCaching(ContextValue[] values) {
			return ExternalValueTesting(false, values);
		}
		[TestCaseSource(typeof(ExternalValueTestCase))]
		public object ExternalValueTestingWithCaching(ContextValue[] values) {
			return ExternalValueTesting(true, values);
		}

		public object ExternalValueTesting(bool caching, ContextValue[] values) {
			Dictionary<string, object> externals = new Dictionary<string, object>();
			foreach (ContextValue value in values) {
				if (value.ContextType == ContextType.Value) {
					externals.Add(value.Name, value.Value);
				} else {
					externals.Add(value.Name, value);
				}
			}

			ExecutionContext context = new ExecutionContext(Parser.GetParser()) { CacheExternalValue = caching, };
			context.TryGetExternalData = new TryGetValueDelegate((string name, object input, out object value) => {
				if (input is IDictionary<string, object>) {
					return ((IDictionary<string, object>)input).TryGetValue(name, out value);
				} else {
					value = null; 
					return true;
				}
			});
			object result =  context.GetValue("a", externals);
			return result;
		}

		[TestCaseSource(typeof(CircularReferenceTestCase))]
		public void ExternalValueWithCircularReferenceWithoutCaching(ContextValue[] values) {
			ExternalValueWithCircularReference(false, values);
		}

		[TestCaseSource(typeof(CircularReferenceTestCase))]
		public void ExternalValueWithCircularReferenceWithCaching(ContextValue[] values) {
			ExternalValueWithCircularReference(true, values);
		}

		void ExternalValueWithCircularReference(bool caching, ContextValue[] values) {
			TestDelegate handle = new TestDelegate(() => {
				Dictionary<string, object> externals = new Dictionary<string, object>();
				foreach (ContextValue value in values) {
					if (value.ContextType == ContextType.Value) {
						externals.Add(value.Name, value.Value);
					} else {
						externals.Add(value.Name, value);
					}
				}

				ExecutionContext context = new ExecutionContext(Parser.GetParser()) { CacheExternalValue = caching, };
				context.TryGetExternalData = new TryGetValueDelegate((string name, object input, out object value) => {
					if (input is IDictionary<string, object>) {
						return ((IDictionary<string, object>)input).TryGetValue(name, out value);
					} else {
						value = null;
						return true;
					}
				});
				context.GetValue("a", externals);
			});
			Assert.Throws<CircularReferenceException>(handle);
		}
	}
}
