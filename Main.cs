using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.Expression {
	class Program{
		static void Main() {
			// simple evaluation
			object value = Parser.GetParser().Compile("4 + 6").EvalValue(null);
			Console.WriteLine(value);

			// evaluation with an external variable
			Dictionary<string, object> variables = new Dictionary<string, object>();
			Func<string, object> func = new Func<string, object>(name => variables[name]);
			variables.Add("a", 4);
			value = Parser.GetParser().Compile("a + 6").EvalValue(func);
			Console.WriteLine(value);

			//evaluation with an execution context
			ExecutionContext context = new ExecutionContext();
			context.SetExpression("b", "a + 6");
			context.SetValue("a", 4);
			Console.WriteLine(context.GetValue("b", null));

			//evaluation expressions with multiple dependencies
			context.SetExpression("c", "b * a");
			Console.WriteLine(context.GetValue("c", null));

			//evaluation expressions with external dependencies
			context.Clear();
			//a is the external dependency that comes from the dictionary object;
			context.SetExpression("b", "a + 6");
			context.SetExpression("c", "b * a");
			context.GetExternalData = (name, input) => ((IDictionary<string, object>)input)[name];
			Console.WriteLine(context.GetValue("c", variables));
		}
	}
}
