[`< Back`](../../../)

---

# GreaterThanExpressionFactory

Namespace: Albatross.Expression.Parsing

Factory class that parses greater-than comparison operators from text input.
 Recognizes the "&gt;" operator but excludes "&gt;=" to avoid conflicts.

```csharp
public class GreaterThanExpressionFactory : IExpressionFactory`1
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [GreaterThanExpressionFactory](./albatross/expression/parsing/greaterthanexpressionfactory)<br>
Implements [IExpressionFactory&lt;GreaterThan&gt;](./albatross/expression/parsing/iexpressionfactory-1)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Constructors

### **GreaterThanExpressionFactory()**

```csharp
public GreaterThanExpressionFactory()
```

## Methods

### **Parse(String, Int32, Int32&)**

Attempts to parse a greater-than operator from the specified position in the text.
 Uses a negative lookahead to ensure it doesn't match "&gt;=" operators.

```csharp
public GreaterThan Parse(string text, int start, Int32& next)
```

#### Parameters

`text` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The input text to parse.

`start` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The starting position in the text.

`next` [Int32&](https://docs.microsoft.com/en-us/dotnet/api/system.int32&)<br>
When this method returns, contains the next position after the parsed operator.

#### Returns

[GreaterThan](./albatross/expression/infix/greaterthan)<br>
A GreaterThan infix expression if parsing succeeds; otherwise, null.

---

[`< Back`](../../../)
