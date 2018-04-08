# Albatross Expression Api

## Summary
[Albatross.Expression](xref:Albatross.Expression) is a text expression parser.  It can evaluate the value of a text expression.  It can also parse a text expression and use the model to produce another expression of different format.

## Description
The Api supports 
* infix operator: 1 + 1
* prefix operations: 1 - -2 (the negative sign is a prefix operator )
* functions: max(1, 2, 3)

[Albatross.Expression](xref:Albatross.Expression) parses the expression by
1. Tokenize the text
1. Build a stack
1. Create a token tree

Once the token tree is created, the parser will evaluate the result of the expression by evaluating the tree nodes recursively.  

## Why not evaluate the expression after step 2, using the stack?
It is true that the value can be evaluated using the stack.  But the stack would be popped during the evaluation process and it cannot be reused.  The token tree however can be called repeately.

## Why would you want to reuse an expression tree?
There is no reason to reused an expression if it is made of literals such as 1 + 1.  However if an expression is created using variables: a + b.  Its value will depends on the input variable.  Once constructed, the tree can be invoked repeatedly using different input values.

## How to construct an expression using variables?


# Projects

* [Albatross.Expression](xref:Albatross.Expression) - Class and interface definition
* [Albatross.Expression.Test](xref:Albatross.Expression.Test) - Unit test using NUnit

# How to use the Api


Albatross.Expression is a single statement expression parser.  

The Albatross.Expression.IParser is the main interface that will tokenize an expression, build the stack and eventually create a final token for evaluation.

The standard parser Albatross.Expression.Parser supports both infix and prefix operations.  The static method Parser.GetParser() will construct the parser with all supported operations.  
If new operations need to be added, it is easy to create the new operations and add it manually.  There is no need to reimplement the Parser class because the logic of tokenizing, building stack and building tree are the same for most kinds of expressions.

The arithmetic operations such as plus, minus, sum, etc. only support C# double types for the sake of simplicity.  This again is a implementation of the operations rather than the parser itself.

The ExecutionContext class is an useful utility class that can hold a set of expressions.
Expression such as:

0. MV = Price * Qty;</div>
0. Price = (Bid + Ask)/2;
0. Bid = .6;
0. Ask = .8;

can be created and evaluated using the ExecutionContext class.  The Compile function will build the expressions and detect circular reference.  Recursive expressions are not supported and will be considered as circular.

After the token tree has been created, the Eval function of the IToken object is thread safe.  Same can be said for the GetValue function of the ExecutionContext object after it has been compiled.

0. [List of Operations](https://github.com/RushuiGuan/Albatross/wiki/Expression-Operations)

Here is some code example:

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
