[`< Back`](../../../)

---

# ControlToken

Namespace: Albatross.Expression.Nodes

Represents control tokens used for parsing expression structure (parentheses, commas, etc.).

```csharp
public class ControlToken : IToken
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ControlToken](./albatross/expression/nodes/controltoken)<br>
Implements [IToken](./albatross/expression/nodes/itoken)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **Token**

The token character as a string.

```csharp
public string Token { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Constructors

### **ControlToken(Char)**

Initializes a new instance of the [ControlToken](./albatross/expression/nodes/controltoken) class.

```csharp
public ControlToken(char token)
```

#### Parameters

`token` [Char](https://docs.microsoft.com/en-us/dotnet/api/system.char)<br>
The control character for this token.

## Methods

### **Text()**

Returns the text representation of this control token.

```csharp
public string Text()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The token character as a string.

---

[`< Back`](../../../)
