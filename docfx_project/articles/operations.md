# Built-In Operations
| Operation | Class | Operation Type |
|---|---|---|
| `-` | @Albatross.Expression.Infix.Minus | infix |
| `-` | @Albatross.Expression.Unary.Negative | Unary |
| `%` | @Albatross.Expression.Infix.Mod | infix |
| `*` | @Albatross.Expression.Infix.Multiply | infix |
| `/` | @Albatross.Expression.Infix.Divide | infix |
| `@` | @Albatross.Expression.Prefix.Array | Unary |
| `^` | @Albatross.Expression.Infix.Power | infix |
| `+` | @Albatross.Expression.Infix.Plus | infix |
| `+` | @Albatross.Expression.Unary.Positive | Unary |
| `<` | @Albatross.Expression.Infix.LessThan | infix |
| `<=` | @Albatross.Expression.Infix.LessEqual | infix |
| `<>` | @Albatross.Expression.Infix.NotEqual | infix |
| `=` | @Albatross.Expression.Infix.Equal | infix |
| `>` | @Albatross.Expression.Infix.GreaterThan | infix |
| `>=` | @Albatross.Expression.Infix.GreaterEqual | infix |
| `and` | @Albatross.Expression.Infix.And | infix |
| `avg` | @Albatross.Expression.Prefix.Avg | prefix |
| `Coalesce` | @Albatross.Expression.Prefix.Coalesce | prefix |
| `CurrentApp` | @Albatross.Expression.Prefix.CurrentApp | prefix |
| `CurrentMachine` | @Albatross.Expression.Prefix.CurrentMachine | prefix |
| `CurrentUser` | @Albatross.Expression.Prefix.CurrentUser | prefix |
| `date` | @Albatross.Expression.Prefix.Date | prefix |
| `Format` | @Albatross.Expression.Prefix.Format | prefix |
| `If` | @Albatross.Expression.Prefix.If | prefix |
| `IsBlank` | @Albatross.Expression.Prefix.IsBlank | prefix |
| `Left` | @Albatross.Expression.Prefix.Left | prefix |
| `len` | @Albatross.Expression.Prefix.Len | prefix |
| `max` | @Albatross.Expression.Prefix.Max | prefix |
| `min` | @Albatross.Expression.Prefix.Min | prefix |
| `Month` | @Albatross.Expression.Prefix.Month | prefix |
| `MonthName` | @Albatross.Expression.Prefix.MonthName | prefix |
| `not` | @Albatross.Expression.Prefix.Not | prefix |
| `Now` | @Albatross.Expression.Prefix.Now | prefix |
| `or` | @Albatross.Expression.Infix.Or | infix |
| `PadLeft` | @Albatross.Expression.Prefix.PadLeft | prefix |
| `PadRight` | @Albatross.Expression.Prefix.PadRight | prefix |
| `pi` | @Albatross.Expression.Prefix.Pi | prefix |
| `Right` | @Albatross.Expression.Prefix.Right | prefix |
| `ShortMonthName` | @Albatross.Expression.Prefix.ShortMonthName | prefix |
| `Text` | @Albatross.Expression.Prefix.Text | prefix |
| `Today` | @Albatross.Expression.Prefix.Today | prefix |
| `Year` | @Albatross.Expression.Prefix.Year | prefix |

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

## The Precedence of Infix Operations
| Operation | Class | Precedence |
|---|---|---|
| `or` | @Albatross.Expression.Infix.Or | 20 |
| `and` | @Albatross.Expression.Infix.And | 30 |
| `=` | @Albatross.Expression.Infix.Equal | 50 |
| `>=` | @Albatross.Expression.Infix.GreaterEqual | 50 |
| `>` | @Albatross.Expression.Infix.GreaterThan | 50 |
| `<=` | @Albatross.Expression.Infix.LessEqual | 50 |
| `<` | @Albatross.Expression.Infix.LessThan | 50 |
| `-` | @Albatross.Expression.Infix.Minus | 100 |
| `<>` | @Albatross.Expression.Infix.NotEqual | 100 |
| `+` | @Albatross.Expression.Infix.Plus | 100 |
| `/` | @Albatross.Expression.Infix.Divide | 200 |
| `%` | @Albatross.Expression.Infix.Mod | 200 |
| `*` | @Albatross.Expression.Infix.Multiply | 200 |
| `^` | @Albatross.Expression.Infix.Power | 300 |

