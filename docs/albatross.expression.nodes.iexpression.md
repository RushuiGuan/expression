# IExpression

Namespace: Albatross.Expression.Nodes

Represents an evaluable expression that can be executed with a given context.

```csharp
public interface IExpression : IToken
```

Implements [IToken](./albatross.expression.nodes.itoken.md)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute)

## Methods

### **Eval(Func&lt;String, Object&gt;)**

Evaluates the expression synchronously using the provided context function.

```csharp
object Eval(Func<string, object> context)
```

#### Parameters

`context` [Func&lt;String, Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>
A function that resolves variable names to their values.

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The result of evaluating the expression.

### **EvalAsync(Func&lt;String, Task&lt;Object&gt;&gt;)**

Evaluates the expression asynchronously using the provided context function.

```csharp
Task<object> EvalAsync(Func<string, Task<object>> context)
```

#### Parameters

`context` [Func&lt;String, Task&lt;Object&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>
A function that asynchronously resolves variable names to their values.

#### Returns

[Task&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task containing the result of evaluating the expression.
