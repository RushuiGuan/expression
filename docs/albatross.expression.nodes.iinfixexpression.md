# IInfixExpression

Namespace: Albatross.Expression.Nodes

Represents an infix binary operation expression (e.g., a + b, x &gt; y).

```csharp
public interface IInfixExpression : IExpression, IToken, IHasPrecedence
```

Implements [IExpression](./albatross.expression.nodes.iexpression.md), [IToken](./albatross.expression.nodes.itoken.md), [IHasPrecedence](./albatross.expression.nodes.ihasprecedence.md)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute)

## Properties

### **Operator**

The operator symbol used for this infix operation.

```csharp
public abstract string Operator { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Left**

The left operand of the infix operation.

```csharp
public abstract IExpression Left { get; set; }
```

#### Property Value

[IExpression](./albatross.expression.nodes.iexpression.md)<br>

### **Right**

The right operand of the infix operation.

```csharp
public abstract IExpression Right { get; set; }
```

#### Property Value

[IExpression](./albatross.expression.nodes.iexpression.md)<br>
