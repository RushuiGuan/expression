[`< Back`](../../../)

---

# AsyncExternalContextValue&lt;T&gt;

Namespace: Albatross.Expression.Context

Context value that delegates value retrieval to an asynchronous external function.
 Computes the value dynamically and asynchronously based on the input context using the provided async function.

```csharp
public class AsyncExternalContextValue<T> : IContextValue`1
```

#### Type Parameters

`T`<br>
The type of the root context object.

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [AsyncExternalContextValue&lt;T&gt;](./albatross/expression/context/asyncexternalcontextvalue-1)<br>
Implements IContextValue&lt;T&gt;<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **Name**

Gets the name of this context value.

```csharp
public string Name { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Constructors

### **AsyncExternalContextValue(String, Func&lt;T, Task&lt;Object&gt;&gt;)**

Initializes a new instance of the AsyncExternalContextValue class with an async value computation function.

```csharp
public AsyncExternalContextValue(string name, Func<T, Task<object>> func)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of this context value.

`func` Func&lt;T, Task&lt;Object&gt;&gt;<br>
The async function that computes the value based on the input context.

## Methods

### **GetValue(T, Func&lt;String, T, Object&gt;)**

Throws NotSupportedException as this context value only supports asynchronous evaluation.
 Use GetValueAsync instead for async-only context values.

```csharp
public object GetValue(T input, Func<string, T, object> _)
```

#### Parameters

`input` T<br>
The root context object (ignored).

`_` Func&lt;String, T, Object&gt;<br>
Function to resolve variables (ignored).

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
Never returns normally.

#### Exceptions

[NotSupportedException](https://docs.microsoft.com/en-us/dotnet/api/system.notsupportedexception)<br>
Always thrown since this context value requires asynchronous evaluation.

### **GetValueAsync(T, Func&lt;String, T, Task&lt;Object&gt;&gt;)**

Asynchronously computes and returns the value by invoking the external async function with the input context.
 Ignores the variable resolution function parameter since this value doesn't depend on other variables.

```csharp
public Task<object> GetValueAsync(T input, Func<string, T, Task<object>> _)
```

#### Parameters

`input` T<br>
The root context object passed to the computation function.

`_` Func&lt;String, T, Task&lt;Object&gt;&gt;<br>
Async function to resolve variables (ignored).

#### Returns

[Task&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task containing the result of the async computation function.

---

[`< Back`](../../../)
