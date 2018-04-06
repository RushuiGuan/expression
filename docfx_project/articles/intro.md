# Introduction
Albatross.Expression api is created to process text based expression strings.  The api tokenizes the expression text and create a tree model from the tokens.  Using the model, it can evaluate the expression or convert it to a expression of different format.  Some applications revert the process by creating the model first and using it to generate certain expression such as a sql query statement.

# Usage
Use the easiest way to use the parser is by calling the singleton instance of the [Factory](xref:Albatross.Expression.Factory) class.
```csharp
var parser = Factory.Instance.Create();
parser.Compile("1 + 5").EvalValue(null);
```

# Supported Operations
The api supports three diffent kinds of operations
* Infix operation 
    * `1 + 1`
    * `if (true, "Yes", "No")`
* Prefix operation
    * `max(1,2,3)`
    * `pi()`
    * `today()`
    * `left(string, length)`
* Unary operation
    * `-1`  \\negative 1
    * `@(1, 2, 3)`  \\ an array of 1, 2 and 3

It supports `string`, `boolean` and `numeric` literals.  It treats all numbers as `double`.  Reference the [operations](operations.md) page to see the list of supported operations.