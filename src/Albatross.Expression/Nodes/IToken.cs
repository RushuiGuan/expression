using System;

namespace Albatross.Expression.Nodes {
	/// <summary>
	/// Base interface for all tokens in the expression system, providing basic token identification and text representation.
	/// </summary>
	public interface IToken {
		/// <summary>
		/// The token identifier used for parsing and recognition.
		/// </summary>
		string Token { get; }
		
		/// <summary>
		/// Returns the text representation of this token for display or serialization purposes.
		/// </summary>
		/// <returns>A string representation of the token.</returns>
		string Text();
	}
}