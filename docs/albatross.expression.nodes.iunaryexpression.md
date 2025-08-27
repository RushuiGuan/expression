# IUnaryExpression

Namespace: Albatross.Expression.Nodes

Represents a unary operation expression that operates on a single operand (e.g., -x, +y).

```csharp
public interface IUnaryExpression : IExpression, IToken, IHasPrecedence
```

Implements [IExpression](./albatross.expression.nodes.iexpression.md), [IToken](./albatross.expression.nodes.itoken.md), [IHasPrecedence](./albatross.expression.nodes.ihasprecedence.md)

## Properties

### **Operator**

The operator symbol used for this unary operation.

```csharp
public abstract string Operator { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Operand**

The operand that this unary operation applies to.

```csharp
public abstract IExpression Operand { get; set; }
```

#### Property Value

[IExpression](./albatross.expression.nodes.iexpression.md)<br>
