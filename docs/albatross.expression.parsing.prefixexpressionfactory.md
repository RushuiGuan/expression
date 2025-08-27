# PrefixExpressionFactory

Namespace: Albatross.Expression.Parsing

Factory for creating prefix expressions using a provided factory function.

```csharp
public class PrefixExpressionFactory : IExpressionFactory`1
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PrefixExpressionFactory](./albatross.expression.parsing.prefixexpressionfactory.md)<br>
Implements [IExpressionFactory&lt;IPrefixExpression&gt;](./albatross.expression.parsing.iexpressionfactory-1.md)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Constructors

### **PrefixExpressionFactory(Func&lt;IPrefixExpression&gt;, Boolean)**

Initializes a new instance of the [PrefixExpressionFactory](./albatross.expression.parsing.prefixexpressionfactory.md) class.

```csharp
public PrefixExpressionFactory(Func<IPrefixExpression> func, bool caseSensitive)
```

#### Parameters

`func` [Func&lt;IPrefixExpression&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
Function that creates instances of the prefix expression.

`caseSensitive` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Whether function name matching should be case-sensitive.

## Methods

### **Parse(String, Int32, Int32&)**

```csharp
public IPrefixExpression Parse(string text, int start, Int32& next)
```

#### Parameters

`text` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`start` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`next` [Int32&](https://docs.microsoft.com/en-us/dotnet/api/system.int32&)<br>

#### Returns

[IPrefixExpression](./albatross.expression.nodes.iprefixexpression.md)<br>
