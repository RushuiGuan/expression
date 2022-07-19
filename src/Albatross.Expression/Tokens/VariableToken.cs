using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Albatross.Expression.Exceptions;

namespace Albatross.Expression.Tokens {
	/// <summary>
	/// <para>
	/// VariableToken class will look for names in the expression string.  It follows the same rule as C# variable names which allows alpha numeric 
	/// and underline characters.  The leading character of a variable cannot be numeric.  In addition, it allows two name to be joined together using a period.  So "name1.name2" is also OK.  However "name1.name2.name3" 
	/// is not allowed.
	/// </para>
	/// 
	/// <para>
	/// Note: a variable name cannot be followed by a open parentheses because it will become a function.  Please keep that in mind when creating a custom <see cref="Albatross.Expression.Tokens.IVariableToken"/> implementation.
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
	public class VariableToken : IVariableToken {
		//const string VariableNamePattern = @"^\s*([a-zA-Z_]+\.?[a-zA-Z0-9_]*) \b (?!\s*\() ";
		const string VariableNamePattern = Config.DefaultVariableNamePattern;
		static Regex VariableNameRegex = new Regex(VariableNamePattern, RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

		public string Name { get; private set; }
		public string Group { get { return "System"; } }
		public bool Match(string expression, int start, out int next) {
			next = expression.Length;
			if (start < expression.Length) {
				Match match = VariableNameRegex.Match(expression.Substring(start));
				if (match.Success) {
					Name = match.Groups[1].Value;
					next = start + match.Value.Length;
					return true;
				}
			}
			return false;
		}
		public override string ToString() { return Name; }
		public object Value { get; set; }
		public bool Calculated { get; set; }
		public int CompareTo(IOperandToken other) {
			throw new NotImplementedException();
		}
		public string EvalText(string format) {
			return Name;
		}
		public IToken Clone() {
			return new VariableToken() { Name = Name };
		}
		public object EvalValue(Func<string, object> context) {
			object value;
			if (context != null){
				value = context(Name);
				if (value is int || value is float || value is long || value is short || value is uint || value is decimal || value is ushort || value is ulong) {
					value = Convert.ToDouble(value);
				}
				return value;
			} else {
				return null;
				//throw new VariableNotFoundException(Name);
			}
		}
	}
}
