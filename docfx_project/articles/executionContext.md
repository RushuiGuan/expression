# Execution Context
There isn't much use case for a parser that can only evaluate expressions made of literals.  However by introducing variables, the expressions becomes formulas.  User defined formulas are found in many applications.  For example Microsoft Excel has a complex formula system.  The [ExecutionContext<T>](xref:Albatross.Expression.ExecutionContext`1) class is created to for this purpose.

## Design


The [ExecutionContext<T>](xref:Albatross.Expression.ExecutionContext`1) class uses [ContextValue](xref:Albatross.Expression.ContextValue) too 

## [DataRowExecutionContextFactory](xref:Albatross.Expression.DataRowExecutionContextFactory)

## Customization