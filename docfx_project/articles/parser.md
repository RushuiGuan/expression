# Parser
The class [Albatross.Expression.Parser](xref:Albatross.Expression.Parser) implements interface [Albatross.Expression.IParser](xref:Albatross.Expression.IParser).  It performs the function of processing, evaluating and generating of expressions.

## Design
The [Parser](xref:Albatross.Expression.Parser) class parses the expression by
1. Tokenize the text
1. Build a stack
1. Create a token tree

Once the token tree is created, the parser can evaluate the result of the expression by evaluating the tree nodes recursively.  

The implementation of the design supports the following functionalties:
* Tokens
    * String Literal - `"yes"`
    * Numeric Literal - `100 + 4.0`
        * The [NumericLiteralToken](xref:Albatross.Expression.Tokens.NumericLiteralToken) class handles number and it converts all numeric value to C# type `System.Double`.
    * Variable - `a + 4`
    * Parantheses - `4 * (1 + 2)`
* Infix operation - Operations with two operands and a operator in the middle: `1 + 2`
    * operation precedence
* unary operation - Negative sign: `-1`
* prefix operation - Functions with fixed or optional parameter and a return value: `Now(), Left("Orange", 4)`
* unlimited optional function parameters - `max(1,2,3,4,5)`
* Array - Array is a special function that returns an array object: `@(1, 2, 3, 4, 5)`


## Tokenization
Tokenization reads the expression from left to right.  Its function is to recognize individual components (tokens) of an expression.  This step will throw [TokenParsingException](xref:Albatross.Expression.Exceptions.TokenParsingException) if the expression has errors.  The resulting tokens are inserted into a queue.  The implementation is in the [Tokenize](xref:Albatross.Expression.Parser.Tokenize(System.String)) method of the [Parser](xref:Albatross.Expression.Parser) class.

Here are some examples:
* Expression: `4 + 5 * 6 - max(7, 1)`
    * `4`
    * `+`
    * `5`
    * `*`
    * `6`
    * `-`
    * `max`
    * `(`
    * `7`
    * `,`
    * `1`
    * `)`
* Expression: `if (a > b, "Yes", "No")`
    * `if`
    * `(`
    * `a`
    * `>`
    * `b`
    * `,`
    * `"Yes"`
    * `,`
    * `"No"`
    * `)`

Notice that comma and parentheses are considered as control tokens but the string boundary (double quote) are not.  String boundaries are part of the string token and will be stripped and disgarded by the [StringLiteralToken](xref:Albatross.Expression.Tokens.StringLiteralToken) class during the evaluation process.

## Create a Stack
This step converts the tokenized queue into a postfix stack using the [Shunting-yard algorithm](https://en.wikipedia.org/wiki/Shunting-yard_algorithm).  The implementation is in the [BuildStack](xref:Albatross.Expression.Parser.BuildStack(System.Collections.Generic.Queue{Albatross.Expression.Tokens.IToken})) method of the [Parser](xref:Albatross.Expression.Parser) class.  A postfix stack is also called a [Reverse polish notion](https://en.wikipedia.org/wiki/Reverse_Polish_notation).  

Here are the top popping stack for the example above:
* Expression: `4 + 5 * 6 - max(7, 1)`
    * `-`
	* `max`
	* `1`
	* `7`
	* `$`
	* `+`
	* `*`
	* `6`
	* `5`
	* `4`
* Expression: `if (a > b, "Yes", "No")`
	* `If`
	* `"No"`
	* `"Yes"`
	* `>`
	* `b`
	* `a`
	* `$`
* Expression: `Format(Today(), "yyyy-MM-DD")`
	* `Format`
	* `"yyyy-MM-DD"`
	* `Today`
	* `$`
	* `$`

A special control token `$` is used to indicate the end of parameters for prefix operations.  This allows functions with unknown number of optional parameters.  It also simplify the tree creation logic because it doesn't need to know how many parameters the prefix function has.

## Create a Tree
This step is to create a tree from the postfix stack.  The process of converting a stack to a tree is the same process of evaluating (popping) the postfix stack.  The tree is created so that the expression can be evaluated multiple times without rebuilding the stack.  The result object is of type [IToken](xref:Albatross.Expression.Tokens.IToken).

Here are the trees for the example above:

* Expression: `4 + 5 * 6 - max(7, 1)`
	* `-`
		* `+`
			* `4`
			* `*`
				* `5`
				* `6`
		* `max`
			* `7`
			* `1`
* Expression: `if (a > b, "Yes", "No")`
	* `If`
		* `>`
			* `a`
			* `b`
		* `"Yes"`
		* `"No"`
* Expression: `Format(Today(), "yyyy-MM-DD")`
	* `Format`
		* `Today`
		* `"yyyy-MM-DD"`

## Evaluate a tree
With a tree built, the evaluation process is a simple recursive call to the [EvalValue](xref:Albatross.Expression.Tokens.IToken.EvalValue(System.Func{System.String,System.Object})) function of the [IToken](xref:Albatross.Expression.Tokens.IToken) interface.

## Regenerate the expression
Using the same [IToken](xref:Albatross.Expression.Tokens.IToken) object, the parser can regenerate the original expression or convert it to an expression of different format by calling the [EvalText](xref:Albatross.Expression.Tokens.IToken.EvalText(System.String)) method.  The default EvalText method will produce an expression string with equal functionality as the original with consistent spacing and mininum usage of parantheses.  For example: if the original expression is `1+(2*3)`, the regenerated expression will be: `1 + 2 * 3`.

## Use of variable in an expression
When evaluating expressions with variables, the [EvalValue](xref:Albatross.Expression.Tokens.IToken.EvalValue(System.Func{System.String,System.Object})) has a second parameter of type `Func<object, string>` that can be used to return the value of a variable. Here is an example:
```csharp
[TestCase("a + b * c", ExpectedResult = 7)]
[TestCase("a + b + c", ExpectedResult =6)]
public object Run(string expression) {
	Func<string, object> func = name => {
		switch (name.ToLower()) {
			case "a":
				return 1;
			case "b":
				return 2;
			case "c":
				return 3;
			default:
				return null;
		}
	};
	IParser parser = Factory.Instance.Create();
	return parser.Compile(expression).EvalValue(func);
}	
```
