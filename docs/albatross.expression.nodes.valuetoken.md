# ValueToken

Namespace: Albatross.Expression.Nodes

Basic implementation of a value token that stores a simple string value.

```csharp
public class ValueToken : IValueToken, IToken
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ValueToken](./albatross.expression.nodes.valuetoken.md)<br>
Implements [IValueToken](./albatross.expression.nodes.ivaluetoken.md), [IToken](./albatross.expression.nodes.itoken.md)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **Value**

The string value contained by this token.

```csharp
public string Value { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Token**

The token representation, which is the same as the Value for basic value tokens.

```csharp
public string Token { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Constructors

### **ValueToken(String)**

Initializes a new instance of the [ValueToken](./albatross.expression.nodes.valuetoken.md) class with the specified value.

```csharp
public ValueToken(string value)
```

#### Parameters

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string value to store in this token.

## Methods

### **Text()**

Returns the text representation of this token.

```csharp
public string Text()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The text representation of the token.
