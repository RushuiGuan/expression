using Albatross.Expression.Nodes;
using System.Collections.Generic;

namespace Albatross.Expression.ExpressionFactory {
	public class ParserBuilder {
		List<IExpressionFactory<IToken>> Factories = new List<IExpressionFactory<IToken>>();

		public ParserBuilder AddFactory(IExpressionFactory<IToken> factory) {
			Factories.Add(factory);
			return this;
		}

		public ParserBuilder AddNodeFactories(bool caseSensitive) {
			AddFactory(new BooleanLiteralFactory(caseSensitive));
			AddFactory(ControlTokenFactory.LeftParenthesis);
			AddFactory(ControlTokenFactory.RightParenthesis);
			AddFactory(ControlTokenFactory.Comma);
			AddFactory(new NumericLiteralFactory());
			AddFactory(new GreaterThanExpressionFactory());
			AddFactory(new LessThanExpressionFactory());
			AddFactory(StringLiteralFactory.DoubleQuote);
			AddFactory(StringLiteralFactory.SingleQuote);
			return this;
		}
		public ParserBuilder AddInfixFactories(bool caseSensitive) {
			AddFactory(new InfixExpressionFactory<InfixOperations.And>(caseSensitive));
			AddFactory(new InfixExpressionFactory<InfixOperations.Divide>(caseSensitive));
			AddFactory(new InfixExpressionFactory<InfixOperations.Equal>(caseSensitive));
			AddFactory(new InfixExpressionFactory<InfixOperations.GreaterEqual>(caseSensitive));
			AddFactory(new InfixExpressionFactory<InfixOperations.GreaterThan>(caseSensitive));
			AddFactory(new InfixExpressionFactory<InfixOperations.LessEqual>(caseSensitive));
			AddFactory(new InfixExpressionFactory<InfixOperations.LessThan>(caseSensitive));
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

		public ParserBuilder AddPrefixFactories(bool caseSensitive) {
			AddFactory(new PrefixExpressionFactory<PrefixOperations.Array>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.ArrayItem>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.Avg>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.CreateDate>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.CurrentApp>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.CurrentMachine>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.DateTimeExpression>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.DayOfWeek>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.Floor>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.Format>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.GetJsonProperty>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.If>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.Left>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.Len>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.Lower>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.MaxNumber>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.MinNumber>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.Month>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.MonthName>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.NextWeekDay>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.Not>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.Now>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.Number>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.PadLeft>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.PadRight>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.PreviousWeekDay>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.Random>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.RegexCapture>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.Right>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.Round>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.ShortMonthName>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.Text>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.Today>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.UnixTimestamp>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.Upper>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.Utc>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.UtcNow>(caseSensitive));
			AddFactory(new PrefixExpressionFactory<PrefixOperations.Year>(caseSensitive));
			return this;
		}

		public ParserBuilder AddDefault(bool caseSensitive = false) {
			AddNodeFactories(caseSensitive);
			AddInfixFactories(caseSensitive);
			AddUnaryFactories();
			AddPrefixFactories(caseSensitive);
			return this;
		}

		public Parser Build() => new Parser(Factories);
	}
}
