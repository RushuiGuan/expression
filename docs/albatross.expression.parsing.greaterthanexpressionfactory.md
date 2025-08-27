# GreaterThanExpressionFactory

Namespace: Albatross.Expression.Parsing

```csharp
public class GreaterThanExpressionFactory : IExpressionFactory`1
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [GreaterThanExpressionFactory](./albatross.expression.parsing.greaterthanexpressionfactory.md)<br>
Implements [IExpressionFactory&lt;GreaterThan&gt;](./albatross.expression.parsing.iexpressionfactory-1.md)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Constructors

### **GreaterThanExpressionFactory()**

```csharp
public GreaterThanExpressionFactory()
```

## Methods

### **Parse(String, Int32, Int32&)**

```csharp
public GreaterThan Parse(string text, int start, Int32& next)
```

#### Parameters

`text` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`start` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`next` [Int32&](https://docs.microsoft.com/en-us/dotnet/api/system.int32&)<br>

#### Returns

[GreaterThan](./albatross.expression.infix.greaterthan.md)<br>
