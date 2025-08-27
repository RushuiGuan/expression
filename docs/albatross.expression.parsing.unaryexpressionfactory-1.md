# UnaryExpressionFactory&lt;T&gt;

Namespace: Albatross.Expression.Parsing

Generic factory for creating unary expression instances by matching their operator tokens.

```csharp
public class UnaryExpressionFactory<T> : IExpressionFactory`1
```

#### Type Parameters

`T`<br>
The type of unary expression to create.

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [UnaryExpressionFactory&lt;T&gt;](./albatross.expression.parsing.unaryexpressionfactory-1.md)<br>
Implements IExpressionFactory&lt;T&gt;<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Constructors

### **UnaryExpressionFactory()**

```csharp
public UnaryExpressionFactory()
```

## Methods

### **Parse(String, Int32, Int32&)**

```csharp
public T Parse(string expression, int start, Int32& next)
```

#### Parameters

`expression` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`start` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`next` [Int32&](https://docs.microsoft.com/en-us/dotnet/api/system.int32&)<br>

#### Returns

T<br>
