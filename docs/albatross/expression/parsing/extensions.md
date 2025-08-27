[`< Back`](../../../)

---

# Extensions

Namespace: Albatross.Expression.Parsing

Provides extension methods for parser operations and convenience methods.

```csharp
public static class Extensions
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Extensions](./albatross/expression/parsing/extensions)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute), [ExtensionAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.extensionattribute)

## Methods

### **Build(IParser, String)**

Builds an expression tree from the given expression string.

```csharp
public static IExpression Build(IParser parser, string expression)
```

#### Parameters

`parser` [IParser](./albatross/expression/iparser)<br>
The parser instance to use.

`expression` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The expression string to parse.

#### Returns

[IExpression](./albatross/expression/nodes/iexpression)<br>
The parsed expression tree.

### **Eval&lt;T&gt;(IParser, String, IExecutionContext&lt;T&gt;, T)**

Parses and evaluates an expression string using the provided execution context.

```csharp
public static object Eval<T>(IParser parser, string expression, IExecutionContext<T> context, T t)
```

#### Type Parameters

`T`<br>
The type of input object for the execution context.

#### Parameters

`parser` [IParser](./albatross/expression/iparser)<br>
The parser instance to use.

`expression` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The expression string to parse and evaluate.

`context` IExecutionContext&lt;T&gt;<br>
The execution context for variable resolution.

`t` T<br>
The input object containing context data.

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The result of evaluating the expression.

---

[`< Back`](../../../)
