# InfixExpressionFactory&lt;T&gt;

Namespace: Albatross.Expression.Parsing

Generic factory for creating infix expression instances by matching their operator tokens.

```csharp
public class InfixExpressionFactory<T> : IExpressionFactory`1
```

#### Type Parameters

`T`<br>
The type of infix expression to create.

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [InfixExpressionFactory&lt;T&gt;](./albatross.expression.parsing.infixexpressionfactory-1.md)<br>
Implements IExpressionFactory&lt;T&gt;<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Constructors

### **InfixExpressionFactory(Boolean)**

Initializes a new instance of the [InfixExpressionFactory&lt;T&gt;](./albatross.expression.parsing.infixexpressionfactory-1.md) class.

```csharp
public InfixExpressionFactory(bool caseSensitive)
```

#### Parameters

`caseSensitive` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Whether operator matching should be case-sensitive.

## Methods

### **Parse(String, Int32, Int32&)**

```csharp
public T Parse(string text, int start, Int32& next)
```

#### Parameters

`text` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`start` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`next` [Int32&](https://docs.microsoft.com/en-us/dotnet/api/system.int32&)<br>

#### Returns

T<br>
