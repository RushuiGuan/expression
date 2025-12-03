using Albatross.Expression.Nodes;
using System.Collections.Generic;

namespace Albatross.Expression.Parsing {
	/// <summary>
	/// Builder class for creating Parser instances with customizable token factories.
	/// Provides fluent interface for configuring different types of expression parsing capabilities.
	/// </summary>
	public class ParserBuilder {
		readonly List<IExpressionFactory<IToken>> factories = new List<IExpressionFactory<IToken>>();
		/// <summary>
		/// Return a read-only list of the currently registered expression factories.
		/// </summary>
		public IReadOnlyList<IExpressionFactory<IToken>> Factories => factories;

		/// <summary>
		/// Adds a custom expression factory to the parser configuration.
		/// </summary>
		/// <param name="factory">The factory to add for parsing specific token types.</param>
		/// <returns>This ParserBuilder instance for method chaining.</returns>
		public ParserBuilder AddFactory(IExpressionFactory<IToken> factory) {
			factories.Add(factory);
			return this;
		}

		/// <summary>
		/// Adds standard value node factories (literals and variables) to the parser.
		/// </summary>
		/// <param name="caseSensitive">Whether parsing should be case-sensitive.</param>
		/// <returns>This ParserBuilder instance for method chaining.</returns>
		public ParserBuilder AddValueNodeFactories(bool caseSensitive) {
			AddFactory(new BooleanLiteralFactory(caseSensitive));
			AddFactory(new NumericLiteralFactory());
			AddFactory(StringLiteralFactory.DoubleQuote);
			AddFactory(StringLiteralFactory.SingleQuote);
			AddFactory(new VariableFactory());
			return this;
		}

		/// <summary>
		/// Adds infix operation factories (binary operators like +, -, *, etc.) to the parser.
		/// </summary>
		/// <param name="caseSensitive">Whether parsing should be case-sensitive.</param>
		/// <returns>This ParserBuilder instance for method chaining.</returns>
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

		/// <summary>
		/// Adds unary operation factories (unary operators like +x, -x) to the parser.
		/// </summary>
		/// <returns>This ParserBuilder instance for method chaining.</returns>
		public ParserBuilder AddUnaryFactories() {
			AddFactory(new UnaryExpressionFactory<Unary.Negative>());
			AddFactory(new UnaryExpressionFactory<Unary.Positive>());
			return this;
		}

		/// <summary>
		/// Adds a comprehensive set of built-in prefix functions to the parser.
		/// </summary>
		/// <param name="caseSensitive">Whether parsing should be case-sensitive.</param>
		/// <returns>This ParserBuilder instance for method chaining.</returns>
		public ParserBuilder AddGenericPrefixFactory(bool caseSensitive) {
			var factory = new GenericPrefixExpressionFactory(caseSensitive);
			factory.Add<Prefix.ArrayItem>();
			factory.Add<Prefix.Avg>();
			factory.Add<Prefix.Concat>();
			factory.Add<Prefix.CreateDate>();
			factory.Add<Prefix.CurrentApp>();
			factory.Add<Prefix.CurrentMachine>();
			factory.Add<Prefix.DateTimeExpression>();
			factory.Add<Prefix.DayOfWeek>();
			factory.Add<Prefix.Floor>();
			factory.Add<Prefix.Format>();
			factory.Add<Prefix.GetJsonProperty>();
			factory.Add<Prefix.If>();
			factory.Add<Prefix.JoinPath>();
			factory.Add<Prefix.Left>();
			factory.Add<Prefix.Len>();
			factory.Add<Prefix.Lower>();
			factory.Add<Prefix.MaxNumber>();
			factory.Add<Prefix.MinNumber>();
			factory.Add<Prefix.Month>();
			factory.Add<Prefix.MonthName>();
			factory.Add<Prefix.NextWeekDay>();
			factory.Add<Prefix.Not>();
			factory.Add<Prefix.Now>();
			factory.Add<Prefix.Number>();
			factory.Add<Prefix.PadLeft>();
			factory.Add<Prefix.PadRight>();
			factory.Add<Prefix.PreviousWeekDay>();
			factory.Add<Prefix.Random>();
			factory.Add<Prefix.RegexCapture>();
			factory.Add<Prefix.Right>();
			factory.Add<Prefix.Round>();
			factory.Add<Prefix.ShortMonthName>();
			factory.Add<Prefix.Text>();
			factory.Add<Prefix.Today>();
			factory.Add<Prefix.UnixTimestamp>();
			factory.Add<Prefix.Upper>();
			factory.Add<Prefix.Utc>();
			factory.Add<Prefix.UtcNow>();
			factory.Add<Prefix.Year>();

			AddFactory(factory);
			return this;
		}

		/// <summary>
		/// Adds named prefix expression factories that require specific syntax.
		/// </summary>
		/// <param name="caseSensitive">Whether parsing should be case-sensitive.</param>
		/// <returns>This ParserBuilder instance for method chaining.</returns>
		public ParserBuilder AddNamedPrefixFactories(bool caseSensitive) {
			AddFactory(new PrefixExpressionFactory<Prefix.Array>(caseSensitive));
			return this;
		}

		/// <summary>
		/// Adds all standard expression parsing capabilities (values, infix, unary, and prefix operations).
		/// </summary>
		/// <param name="caseSensitive">Whether parsing should be case-sensitive.</param>
		/// <returns>This ParserBuilder instance for method chaining.</returns>
		public ParserBuilder AddDefault(bool caseSensitive = false) {
			AddValueNodeFactories(caseSensitive);
			AddInfixFactories(caseSensitive);
			AddUnaryFactories();
			AddGenericPrefixFactory(caseSensitive);
			AddNamedPrefixFactories(caseSensitive);
			return this;
		}

		/// <summary>
		/// Creates a Parser instance with all default parsing capabilities enabled.
		/// </summary>
		/// <param name="caseSensitive">Whether parsing should be case-sensitive.</param>
		/// <returns>A fully configured Parser instance.</returns>
		public Parser BuildDefault(bool caseSensitive = false) {
			this.AddDefault(caseSensitive);
			return new Parser(factories, caseSensitive);
		}
	}
}
