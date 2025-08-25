using Albatross.Expression.Nodes;
using System.Collections.Generic;

namespace Albatross.Expression.ExpressionFactory {
	public class ParserBuilder {
		List<IExpressionFactory<IToken>> Factories = new List<IExpressionFactory<IToken>>();

		public ParserBuilder AddFactory(IExpressionFactory<IToken> factory) {
			Factories.Add(factory);
			return this;
		}

		public ParserBuilder AddValueNodeFactories(bool caseSensitive) {
			AddFactory(new BooleanLiteralFactory(caseSensitive));
			AddFactory(new NumericLiteralFactory());
			AddFactory(StringLiteralFactory.DoubleQuote);
			AddFactory(StringLiteralFactory.SingleQuote);
			AddFactory(new VariableFactory());
			return this;
		}
		public ParserBuilder AddInfixFactories(bool caseSensitive) {
			AddFactory(new GreaterThanExpressionFactory());
			AddFactory(new LessThanExpressionFactory());
			AddFactory(new InfixExpressionFactory<InfixOperations.And>(caseSensitive));
			AddFactory(new InfixExpressionFactory<InfixOperations.Divide>(caseSensitive));
			AddFactory(new InfixExpressionFactory<InfixOperations.Equal>(caseSensitive));
			AddFactory(new InfixExpressionFactory<InfixOperations.GreaterEqual>(caseSensitive));
			AddFactory(new GreaterThanExpressionFactory());
			AddFactory(new InfixExpressionFactory<InfixOperations.LessEqual>(caseSensitive));
			AddFactory(new LessThanExpressionFactory());
			AddFactory(new InfixExpressionFactory<InfixOperations.Minus>(caseSensitive));
			AddFactory(new InfixExpressionFactory<InfixOperations.Mod>(caseSensitive));
			AddFactory(new InfixExpressionFactory<InfixOperations.Multiply>(caseSensitive));
			AddFactory(new InfixExpressionFactory<InfixOperations.NotEqual>(caseSensitive));
			AddFactory(new InfixExpressionFactory<InfixOperations.Or>(caseSensitive));
			AddFactory(new InfixExpressionFactory<InfixOperations.Plus>(caseSensitive));
			AddFactory(new InfixExpressionFactory<InfixOperations.Power>(caseSensitive));
			return this;
		}

		public ParserBuilder AddUnaryFactories() {
			AddFactory(new UnaryExpressionFactory<UnaryOperations.Negative>());
			AddFactory(new UnaryExpressionFactory<UnaryOperations.Positive>());
			return this;
		}

		public ParserBuilder AddGenericPrefixFactory(bool caseSensitive) {
			var factory = new GenericPrefixExpressionFactory(caseSensitive);
			factory.Add(new PrefixOperations.ArrayItem());
			factory.Add(new PrefixOperations.Avg());
			factory.Add(new PrefixOperations.CreateDate());
			factory.Add(new PrefixOperations.CurrentApp());
			factory.Add(new PrefixOperations.CurrentMachine());
			factory.Add(new PrefixOperations.DateTimeExpression());
			factory.Add(new PrefixOperations.DayOfWeek());
			factory.Add(new PrefixOperations.Floor());
			factory.Add(new PrefixOperations.Format());
			factory.Add(new PrefixOperations.GetJsonProperty());
			factory.Add(new PrefixOperations.If());
			factory.Add(new PrefixOperations.Left());
			factory.Add(new PrefixOperations.Len());
			factory.Add(new PrefixOperations.Lower());
			factory.Add(new PrefixOperations.MaxNumber());
			factory.Add(new PrefixOperations.MinNumber());
			factory.Add(new PrefixOperations.Month());
			factory.Add(new PrefixOperations.MonthName());
			factory.Add(new PrefixOperations.NextWeekDay());
			factory.Add(new PrefixOperations.Not());
			factory.Add(new PrefixOperations.Now());
			factory.Add(new PrefixOperations.Number());
			factory.Add(new PrefixOperations.PadLeft());
			factory.Add(new PrefixOperations.PadRight());
			factory.Add(new PrefixOperations.PreviousWeekDay());
			factory.Add(new PrefixOperations.Random());
			factory.Add(new PrefixOperations.RegexCapture());
			factory.Add(new PrefixOperations.Right());
			factory.Add(new PrefixOperations.Round());
			factory.Add(new PrefixOperations.ShortMonthName());
			factory.Add(new PrefixOperations.Text());
			factory.Add(new PrefixOperations.Today());
			factory.Add(new PrefixOperations.UnixTimestamp());
			factory.Add(new PrefixOperations.Upper());
			factory.Add(new PrefixOperations.Utc());
			factory.Add(new PrefixOperations.UtcNow());
			factory.Add(new PrefixOperations.Year());
			AddFactory(factory);
			return this;
		}

		public ParserBuilder AddNamedPrefixFactories(bool caseSensitive) {
			AddFactory(new PrefixExpressionFactory<PrefixOperations.Array>(caseSensitive));
			return this;
		}

		public ParserBuilder AddDefault(bool caseSensitive = false) {
			AddValueNodeFactories(caseSensitive);
			AddInfixFactories(caseSensitive);
			AddUnaryFactories();
			AddGenericPrefixFactory(caseSensitive);
			AddNamedPrefixFactories(caseSensitive);
			return this;
		}

		public Parser Build() => new Parser(Factories);
	}
}
