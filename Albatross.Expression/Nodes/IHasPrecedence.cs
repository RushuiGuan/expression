namespace Albatross.Expression.Nodes {
	/// <summary>
	/// Interface for tokens that have operator precedence to determine order of evaluation.
	/// </summary>
	public interface IHasPrecedence {
		/// <summary>
		/// The precedence level of this operation. Higher values indicate higher precedence.
		/// </summary>
		int Precedence { get; }
	}
}