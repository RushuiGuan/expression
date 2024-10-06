namespace Albatross.Expression.Tokens {
	/// <summary>
	/// will take any string literal enclosed by double quotes.  use back slash to escape.  
	/// Check the GetStringEscape function for escapable chars
	/// </summary>
	public class SingleQuoteStringLiteralToken :StringLiteralToken {
		public override char Boundary => '\'';
		public override IToken Clone() {
			return new SingleQuoteStringLiteralToken();
		}
	}
}