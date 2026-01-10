# Execution Context
There isn't much use case for a parser that can only evaluate expressions made of literals.  However by introducing variables, the expressions becomes formulas.  User defined formulas are found in many applications.  For example Microsoft Excel has a complex formula system.  Even though the [Parser](xref:Albatross.Expression.Parser) class can pass the value of variables by calling the [EvalValue](xref:Albatross.Expression.Tokens.IToken.EvalValue(System.Func{System.String,System.Object})) method with `Func<string, object>` delegate.  The [ExecutionContext<T>](xref:Albatross.Expression.ExecutionContext`1) class is created to manage the use of formulas.

## Design
The [ExecutionContext<T>](xref:Albatross.Expression.ExecutionContext`1) class is a generic class.  The generic type T indicates the type of the input object.  The [ExecutionContext<T>](xref:Albatross.Expression.ExecutionContext`1) class itself doesn't know how to extract the values of variables from class T.  For that, it relies on its factory [IExecutionContextFactory<T>](xref:Albatross.Expression.IExecutionContextFactory`1).

## [DataRowExecutionContextFactory](xref:Albatross.Expression.DataRowExecutionContextFactory)

## Customization