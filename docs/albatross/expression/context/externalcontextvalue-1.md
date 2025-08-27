[`< Back`](../../../)

---

# ExternalContextValue&lt;T&gt;

Namespace: Albatross.Expression.Context

Context value that delegates value retrieval to an external function.
 Computes the value dynamically based on the input context using the provided function.

```csharp
public class ExternalContextValue<T> : IContextValue`1
```

#### Type Parameters

`T`<br>
The type of the root context object.

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ExternalContextValue&lt;T&gt;](./albatross/expression/context/externalcontextvalue-1)<br>
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

### **ExternalContextValue(String, Func&lt;T, Object&gt;)**

Initializes a new instance of the ExternalContextValue class with a value computation function.

```csharp
public ExternalContextValue(string name, Func<T, object> func)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of this context value.

`func` Func&lt;T, Object&gt;<br>
The function that computes the value based on the input context.

## Methods

### **GetValue(T, Func&lt;String, T, Object&gt;)**

Computes and returns the value by invoking the external function with the input context.
 Ignores the variable resolution function parameter since this value doesn't depend on other variables.

```csharp
public object GetValue(T input, Func<string, T, object> _)
```

#### Parameters

`input` T<br>
The root context object passed to the computation function.

`_` Func&lt;String, T, Object&gt;<br>
Function to resolve variables (ignored).

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The result of invoking the computation function with the input context.

### **GetValueAsync(T, Func&lt;String, T, Task&lt;Object&gt;&gt;)**

Asynchronously computes and returns the value by invoking the external function with the input context.
 Returns a completed task since the computation is synchronous.

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
A completed task containing the result of the computation function.

---

[`< Back`](../../../)
