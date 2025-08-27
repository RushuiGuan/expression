[`< Back`](../../../)

---

# IToken

Namespace: Albatross.Expression.Nodes

Base interface for all tokens in the expression system, providing basic token identification and text representation.

```csharp
public interface IToken
```

Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute)

## Properties

### **Token**

The token identifier used for parsing and recognition.

```csharp
public abstract string Token { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Methods

### **Text()**

Returns the text representation of this token for display or serialization purposes.

```csharp
string Text()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
A string representation of the token.

---

[`< Back`](../../../)
