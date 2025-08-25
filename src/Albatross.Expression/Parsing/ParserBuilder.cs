using Albatross.Expression.Nodes;
using System.Collections.Generic;

namespace Albatross.Expression.Parsing {
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
			AddFactory(new InfixExpressionFactory<Infix.And>(caseSensitive));
			AddFactory(new InfixExpressionFactory<Infix.Divide>(caseSensitive));
			AddFactory(new InfixExpressionFactory<Infix.Equal>(caseSensitive));
			AddFactory(new InfixExpressionFactory<Infix.GreaterEqual>(caseSensitive));
			AddFactory(new GreaterThanExpressionFactory());
			AddFactory(new InfixExpressionFactory<Infix.LessEqual>(caseSensitive));
			AddFactory(new LessThanExpressionFactory());
			AddFactory(new InfixExpressionFactory<Infix.Minus>(caseSensitive));
			AddFactory(new InfixExpressionFactory<Infix.Mod>(caseSensitive));
			AddFactory(new InfixExpressionFactory<Infix.Multiply>(caseSensitive));
			AddFactory(new InfixExpressionFactory<Infix.NotEqual>(caseSensitive));
			AddFactory(new InfixExpressionFactory<Infix.Or>(caseSensitive));
			AddFactory(new InfixExpressionFactory<Infix.Plus>(caseSensitive));
			AddFactory(new InfixExpressionFactory<Infix.Power>(caseSensitive));
			return this;
		}

		public ParserBuilder AddUnaryFactories() {
			AddFactory(new UnaryExpressionFactory<Unary.Negative>());
			AddFactory(new UnaryExpressionFactory<Unary.Positive>());
			return this;
		}

		public ParserBuilder AddGenericPrefixFactory(bool caseSensitive) {
			var factory = new GenericPrefixExpressionFactory(caseSensitive);
			factory.Add(new Prefix.ArrayItem());
			factory.Add(new Prefix.Avg());
			factory.Add(new Prefix.Concat());
			factory.Add(new Prefix.CreateDate());
			factory.Add(new Prefix.CurrentApp());
			factory.Add(new Prefix.CurrentMachine());
			factory.Add(new Prefix.DateTimeExpression());
			factory.Add(new Prefix.DayOfWeek());
			factory.Add(new Prefix.Floor());
			factory.Add(new Prefix.Format());
			factory.Add(new Prefix.GetJsonProperty());
			factory.Add(new Prefix.If());
			factory.Add(new Prefix.JoinPath());
			factory.Add(new Prefix.Left());
			factory.Add(new Prefix.Len());
			factory.Add(new Prefix.Lower());
			factory.Add(new Prefix.MaxNumber());
			factory.Add(new Prefix.MinNumber());
			factory.Add(new Prefix.Month());
			factory.Add(new Prefix.MonthName());
			factory.Add(new Prefix.NextWeekDay());
			factory.Add(new Prefix.Not());
			factory.Add(new Prefix.Now());
			factory.Add(new Prefix.Number());
			factory.Add(new Prefix.PadLeft());
			factory.Add(new Prefix.PadRight());
			factory.Add(new Prefix.PreviousWeekDay());
			factory.Add(new Prefix.Random());
			factory.Add(new Prefix.RegexCapture());
			factory.Add(new Prefix.Right());
			factory.Add(new Prefix.Round());
			factory.Add(new Prefix.ShortMonthName());
			factory.Add(new Prefix.Text());
			factory.Add(new Prefix.Today());
			factory.Add(new Prefix.UnixTimestamp());
			factory.Add(new Prefix.Upper());
			factory.Add(new Prefix.Utc());
			factory.Add(new Prefix.UtcNow());
			factory.Add(new Prefix.Year());

			AddFactory(factory);
			return this;
		}

		public ParserBuilder AddNamedPrefixFactories(bool caseSensitive) {
			AddFactory(new PrefixExpressionFactory<Prefix.Array>(caseSensitive));
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

		public Parser BuildDefault(bool caseSensitive = false) {
			this.AddDefault(caseSensitive);
			return new Parser(Factories, caseSensitive);
		}
	}
}
