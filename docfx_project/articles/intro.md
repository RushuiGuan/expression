# Introduction
Albatross.Expression api is created to process text based expressions.  The api tokenizes the expression text and create a tree model from the tokens.  Using the model, it can evaluate the expression or convert it to a expression of different format.  Some applications revert the process by creating the model first and using it to generate certain expressions such as a sql query statement.

# Usage
Use the easiest way to use the parser is by calling the default instance of the [Factory](xref:Albatross.Expression.Factory) class.
```csharp
var parser = Factory.Instance.Create();
parser.Compile("1 + 5").EvalValue(null);
```
## Use of [ExecutionContext](xref:Albatross.Expression.ExecutionContext) class with variables
The evaluation of expressions made of literals is not very helpful and it doesn't have many use cases.  The api was created to solve a different problem - the problem of user defined calculations.  Here is a code sample:
```csharp
    ExecutionContext context = new ExecutionContext(Factory.Instance, true);
    context.SetValue("a", 1);
    context.SetValue("b", 2);
    var result = context.Eval("a + b", null);
    //the result should be 3;
    
    context.SetValue("a", 2);
    result = context.Eval("a + b", null);
    //the result should be 4 now.
```
In the code sample above, the context was able to store the value of variable `a` and `b` and use it to calculate expressions that have those variables.  It is useful in situations where users are allowed to define custom calculations using a formula and the application is expected to perform the calculation of the dynamically defined formulas.

The [ExecutionContext](xref:Albatross.Expression.ExecutionContext) class can also reference data externally so that the value of the variables doesn't need to be established in the object itself.  It is a nessary feature because when data change, instead of calling the SetValue method, it is more efficient for the context to access the external data directly.  Here is a code sample:

```csharp
    //working on it!
```

# Supported Operations
The api supports three diffent kinds of operations
* Infix operation 
    * `1 + 1`
    * `1 + 3 * 7 > 4 and 1 - 4 < 8`
* Prefix operation
    * `if (true, "Yes", "No")`
    * `max(1,2,3)`
    * `pi()`
    * `today()`
    * `left(string, length)`
* Unary operation
    * `-1`  \\negative 1

It supports `string`, `boolean` and `numeric` literals.  It treats all numbers as `double`.  Reference the [operations](operations.md) page to see the list of built-in operations.