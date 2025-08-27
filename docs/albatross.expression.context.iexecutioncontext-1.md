# IExecutionContext&lt;T&gt;

Namespace: Albatross.Expression.Context

Provides execution context for evaluating expressions with variable resolution.

```csharp
public interface IExecutionContext<T>
```

#### Type Parameters

`T`<br>
The type of input object that provides context data.

Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute)

## Properties

### **Parser**

The parser instance used for expression parsing.

```csharp
public abstract IParser Parser { get; }
```

#### Property Value

[IParser](./albatross.expression.iparser.md)<br>

## Methods

### **GetValue(String, T)**

Retrieves the value of a named variable from the input context.

```csharp
object GetValue(string name, T input)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The variable name to resolve.

`input` T<br>
The input object containing context data.

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The resolved variable value.

### **TryGetValue(String, T, Object&)**

Attempts to retrieve the value of a named variable from the input context.

```csharp
bool TryGetValue(string name, T input, Object& data)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The variable name to resolve.

`input` T<br>
The input object containing context data.

`data` [Object&](https://docs.microsoft.com/en-us/dotnet/api/system.object&)<br>
When this method returns, contains the resolved variable value if found; otherwise, null.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
True if the variable was found and resolved; otherwise, false.

### **GetValueAsync(String, T)**

Asynchronously retrieves the value of a named variable from the input context.

```csharp
Task<object> GetValueAsync(string name, T input)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The variable name to resolve.

`input` T<br>
The input object containing context data.

#### Returns

[Task&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task containing the resolved variable value.
