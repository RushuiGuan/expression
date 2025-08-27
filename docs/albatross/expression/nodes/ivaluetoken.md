[`< Back`](../../../)

---

# IValueToken

Namespace: Albatross.Expression.Nodes

Represents a token that holds a value, typically a literal or variable reference.

```csharp
public interface IValueToken : IToken
```

Implements [IToken](./albatross/expression/nodes/itoken)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute)

## Properties

### **Value**

The string value contained by this token.

```csharp
public abstract string Value { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

---

[`< Back`](../../../)
