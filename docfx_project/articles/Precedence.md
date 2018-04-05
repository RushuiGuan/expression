## What is an **Infix operation**?
It is a math expression with an operator in the middle and two operands, one on each side of the operator.  Here are some examples.
1. `1 + 2`
1. `1 + 2 + 3 `
1. `2 + 5 * 4 `
1. `1 > 2 or 3 > 2 `
1. `(1 + 2) * 3 `
1. ` 1 * -1 `

Infix operation can be chained as the examples shown above.  When chained, the precedence of the operator will decide who gets executed first.  If two operator has the same precedence, the operator should be executed from left to right.  For example ``2 + 5 * 4`` will execute ``5 * 4`` first because the `*` operator has a precedence of 200 which is larger than the precedence of the `+` operator.  The `+` operator will then execute `2 + 20`.  The second operand `20` comes from the output of the `*` operator.

The **parentheses** can be used to supersede the precedence of the operators as show in #5.

A **unary operator** such as the negative sign in #6 will always have precedence over any infix operators.

## List of Infix Operations
Infix Operation | Class | Precedence
--- | --- | ---
or | [Albatross.Expression.Operations.Or](xref:Albatross.Expression.Operations.Or) | 20
and | [Albatross.Expression.Operations.And](xref:Albatross.Expression.Operations.And) | 30
= | [Albatross.Expression.Operations.Equal](xref:Albatross.Expression.Operations.Equal) | 50
>= | [Albatross.Expression.Operations.GreaterEqual](xref:Albatross.Expression.Operations.GreaterEqual) | 50
> | [Albatross.Expression.Operations.GreaterThan](xref:Albatross.Expression.Operations.GreaterThan) | 50
<= | [Albatross.Expression.Operations.LessEqual](xref:Albatross.Expression.Operations.LessEqual) | 50
< | [Albatross.Expression.Operations.LessThan](xref:Albatross.Expression.Operations.LessThan) | 50
- | [Albatross.Expression.Operations.Minus](xref:Albatross.Expression.Operations.Minus) | 100
<> | [Albatross.Expression.Operations.NotEqual](xref:Albatross.Expression.Operations.NotEqual) | 100
+ | [Albatross.Expression.Operations.Plus](xref:Albatross.Expression.Operations.Plus) | 100
/ | [Albatross.Expression.Operations.Divide](xref:Albatross.Expression.Operations.Divide) | 200
% | [Albatross.Expression.Operations.Mod](xref:Albatross.Expression.Operations.Mod) | 200
* | [Albatross.Expression.Operations.Multiply](xref:Albatross.Expression.Operations.Multiply) | 200
^ | [Albatross.Expression.Operations.Power](xref:Albatross.Expression.Operations.Power) | 300

