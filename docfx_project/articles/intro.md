# Introduction
Albatross.Expression api is created to parse and evaluate single statement expressions.  It supports the following kinds of operations:
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

It supports `string`, `boolean` and `numeric` literals.  It treats all numbers as `double`.

# Usage
Use the easiest way to use the parser is by calling the singleton instance of the [Factory](xref:Albatross.Expression.Factory) class.
```csharp
var parser = Factory.Instance.Create();
parser.Compile("1 + 5").EvalValue(null);
```