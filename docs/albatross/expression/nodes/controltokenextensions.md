[`< Back`](../../../)

---

# ControlTokenExtensions

Namespace: Albatross.Expression.Nodes

Provides extension methods for identifying different types of control tokens.

```csharp
public static class ControlTokenExtensions
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ControlTokenExtensions](./albatross/expression/nodes/controltokenextensions)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute), [ExtensionAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.extensionattribute)

## Methods

### **IsLeftParenthesis(IToken, Boolean)**

Determines whether the token is a left parenthesis.

```csharp
public static bool IsLeftParenthesis(IToken token, bool value)
```

#### Parameters

`token` [IToken](./albatross/expression/nodes/itoken)<br>
The token to check.

`value` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
The expected result (defaults to true).

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
True if the token is a left parenthesis and matches the expected value.

### **IsRightParenthesis(IToken)**

Determines whether the token is a right parenthesis.

```csharp
public static bool IsRightParenthesis(IToken token)
```

#### Parameters

`token` [IToken](./albatross/expression/nodes/itoken)<br>
The token to check.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
True if the token is a right parenthesis.

### **IsComma(IToken)**

Determines whether the token is a comma separator.

```csharp
public static bool IsComma(IToken token)
```

#### Parameters

`token` [IToken](./albatross/expression/nodes/itoken)<br>
The token to check.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
True if the token is a comma.

### **IsFuncParamStart(IToken, Boolean)**

Determines whether the token marks the start of function parameters.

```csharp
public static bool IsFuncParamStart(IToken token, bool value)
```

#### Parameters

`token` [IToken](./albatross/expression/nodes/itoken)<br>
The token to check.

`value` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
The expected result (defaults to true).

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
True if the token marks function parameter start and matches the expected value.

---

[`< Back`](../../../)
