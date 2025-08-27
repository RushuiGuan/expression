[`< Back`](../../../)

---

# LessThanExpressionFactory

Namespace: Albatross.Expression.Parsing

Instead of using infix operator parser, regex is used to match the operator to avoid ambiguity with other operators like &lt;= and &lt;&gt;

```csharp
public class LessThanExpressionFactory : IExpressionFactory`1
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [LessThanExpressionFactory](./albatross/expression/parsing/lessthanexpressionfactory)<br>
Implements [IExpressionFactory&lt;LessThan&gt;](./albatross/expression/parsing/iexpressionfactory-1)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Constructors

### **LessThanExpressionFactory()**

```csharp
public LessThanExpressionFactory()
```

## Methods

### **Parse(String, Int32, Int32&)**

```csharp
public LessThan Parse(string text, int start, Int32& next)
```

#### Parameters

`text` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`start` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`next` [Int32&](https://docs.microsoft.com/en-us/dotnet/api/system.int32&)<br>

#### Returns

[LessThan](./albatross/expression/infix/lessthan)<br>

---

[`< Back`](../../../)
