using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Albatross.Expression.Nodes {
	/// <summary>
	/// <para>
	/// VariableToken class will look for names in the expression string.  It follows the same rule as C# variable names which allows alpha numeric 
	/// and underline characters.  The leading character of a variable cannot be numeric.  In addition, it allows two name to be joined together using a period.  So "name1.name2" is also OK.  However "name1.name2.name3" 
	/// is not allowed.
	/// </para>
	/// 
	/// <para>
	/// Note: a variable name cannot be followed by a open parentheses because it will become a function.  Please keep that in mind when creating a custom <see cref="IVariable"/> implementation.
	/// </para>
	/// 
	/// <list type="bullet">
	/// <listheader>
	///		<description>Legal Variable Names</description>
	/// </listheader>
	/// <item><description>cat</description></item>
	/// <item><description>_cat</description></item>
	/// <item><description>cat_</description></item>
	/// <item><description>cat0_</description></item>
	/// <item><description>field.cat0_</description></item>
	/// <item><description>field0.cat0_</description></item>
	/// </list>
	/// 
	/// <list type="bullet">
	///	<listheader>
	///		<description>Illegal Variable Names</description>
	/// </listheader>
	/// <item><description>test.field0.cat0_</description></item>
	/// <item><description>0cat</description></item>
	/// <item><description>cat.1cat</description></item>
	/// <item><description>0cat.cat</description></item>
	/// <item><description>$cat$</description></item>
	/// </list>
	/// </summary>
	public class Variable : IVariable {
		public Variable(string name) {
			this.Name = name;
		}
		public string Name { get; }
		public string Text() => Name;
		public object? Eval(Func<string, object>? context) {
			if (context != null){
				var value = context(Name);
				if (value is int || value is float || value is long || value is short || value is uint || value is decimal || value is ushort || value is ulong) {
					value = Convert.ToDouble(value);
				}else if(value is JsonElement) {
					value = ((JsonElement)value).GetJsonValue();
				}
				return value;
			} else {
				return null;
				//throw new VariableNotFoundException(Name);
			}
		}
	}
	
	public class VariableFactory : IExpressionFactory<Variable> {
		//const string VariableNamePattern = @"^\s*([a-zA-Z_]+\.?[a-zA-Z0-9_]*) \b (?!\s*\() ";
		const string VariableNamePattern = @"^\s*([a-zA-Z_][a-zA-Z0-9_]*(\.[a-zA-Z_][a-zA-Z0-9_]*)?) \b (?!\s*\() ";
		static readonly Regex variableNameRegex = new Regex(VariableNamePattern, RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
		public bool TryParse(string expression, int start, out int next, [NotNullWhen(true)] out Variable? node) {
			next = expression.Length;
			if (start < expression.Length) {
				Match match = variableNameRegex.Match(expression.Substring(start));
				if (match.Success) {
					node = new Variable(match.Groups[1].Value);
					next = start + match.Value.Length;
					return true;
				}
			}
			node = null;
			return false;
		}
	}
}
