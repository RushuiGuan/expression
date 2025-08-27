[`< Back`](../../../)

---

# BooleanLiteralFactory

Namespace: Albatross.Expression.Parsing

Factory class that parses boolean literal expressions from text input.
 Recognizes "true" and "false" values with optional case-sensitivity.

```csharp
public class BooleanLiteralFactory : IExpressionFactory`1
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [BooleanLiteralFactory](./albatross/expression/parsing/booleanliteralfactory)<br>
Implements [IExpressionFactory&lt;BooleanLiteral&gt;](./albatross/expression/parsing/iexpressionfactory-1)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Constructors

### **BooleanLiteralFactory(Boolean)**

Initializes a new instance of the BooleanLiteralFactory class.

```csharp
public BooleanLiteralFactory(bool caseSensitive)
```

#### Parameters

`caseSensitive` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Whether to perform case-sensitive matching for boolean literals.

## Methods

### **Parse(String, Int32, Int32&)**

Attempts to parse a boolean literal from the specified position in the text.
 Matches "true" or "false" strings and creates a corresponding BooleanLiteral token.

```csharp
public BooleanLiteral Parse(string text, int start, Int32& next)
```

#### Parameters

`text` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The input text to parse.

`start` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The starting position in the text.

`next` [Int32&](https://docs.microsoft.com/en-us/dotnet/api/system.int32&)<br>
When this method returns, contains the next position after the parsed token.

#### Returns

[BooleanLiteral](./albatross/expression/nodes/booleanliteral)<br>
A BooleanLiteral token if parsing succeeds; otherwise, null.

---

[`< Back`](../../../)
