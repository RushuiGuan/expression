[`< Back`](../../../)

---

# NumericLiteralFactory

Namespace: Albatross.Expression.Parsing

Factory for parsing numeric literal tokens from expression text.

```csharp
public class NumericLiteralFactory : IExpressionFactory`1
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [NumericLiteralFactory](./albatross/expression/parsing/numericliteralfactory)<br>
Implements [IExpressionFactory&lt;NumericLiteral&gt;](./albatross/expression/parsing/iexpressionfactory-1)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Fields

### **NumericPatternRegex**

Compiled regex pattern for matching numeric literals.

```csharp
public static Regex NumericPatternRegex;
```

## Constructors

### **NumericLiteralFactory()**

```csharp
public NumericLiteralFactory()
```

## Methods

### **Parse(String, Int32, Int32&)**

```csharp
public NumericLiteral Parse(string text, int start, Int32& next)
```

#### Parameters

`text` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`start` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`next` [Int32&](https://docs.microsoft.com/en-us/dotnet/api/system.int32&)<br>

#### Returns

[NumericLiteral](./albatross/expression/nodes/numericliteral)<br>

---

[`< Back`](../../../)
