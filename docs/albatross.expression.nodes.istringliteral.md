# IStringLiteral

Namespace: Albatross.Expression.Nodes

Represents a string literal token with boundary character information.

```csharp
public interface IStringLiteral : IValueToken, IToken, IExpression
```

Implements [IValueToken](./albatross.expression.nodes.ivaluetoken.md), [IToken](./albatross.expression.nodes.itoken.md), [IExpression](./albatross.expression.nodes.iexpression.md)

## Properties

### **Boundary**

The boundary character (quote type) that delimits this string literal.

```csharp
public abstract char Boundary { get; }
```

#### Property Value

[Char](https://docs.microsoft.com/en-us/dotnet/api/system.char)<br>
