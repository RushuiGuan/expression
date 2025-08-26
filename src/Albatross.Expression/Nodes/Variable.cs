using System;
using System.Threading.Tasks;

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
	public class Variable : ValueToken, IExpression {
		public Variable(string value) : base(value) {
		}

		public object Eval(Func<string, object> context) => context(Value);
		public Task<object> EvalAsync(Func<string, Task<object>> context) => context(this.Value);
	}
}