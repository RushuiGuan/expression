# BooleanLiteralFactory

Namespace: Albatross.Expression.Parsing

```csharp
public class BooleanLiteralFactory : IExpressionFactory`1
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [BooleanLiteralFactory](./albatross.expression.parsing.booleanliteralfactory.md)<br>
Implements [IExpressionFactory&lt;BooleanLiteral&gt;](./albatross.expression.parsing.iexpressionfactory-1.md)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Constructors

### **BooleanLiteralFactory(Boolean)**

```csharp
public BooleanLiteralFactory(bool caseSensitive)
```

#### Parameters

`caseSensitive` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

## Methods

### **Parse(String, Int32, Int32&)**

```csharp
public BooleanLiteral Parse(string text, int start, Int32& next)
```

#### Parameters

`text` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`start` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`next` [Int32&](https://docs.microsoft.com/en-us/dotnet/api/system.int32&)<br>

#### Returns

[BooleanLiteral](./albatross.expression.nodes.booleanliteral.md)<br>
