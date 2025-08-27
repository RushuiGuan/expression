[`< Back`](../../../)

---

# LocalContextValue&lt;T&gt;

Namespace: Albatross.Expression.Context

Context value that holds a static, pre-computed value.
 Does not depend on the input context and always returns the same value.

```csharp
public class LocalContextValue<T> : IContextValue`1
```

#### Type Parameters

`T`<br>
The type of the root context object.

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [LocalContextValue&lt;T&gt;](./albatross/expression/context/localcontextvalue-1)<br>
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

### **Value**

Gets the static value associated with this context value.

```csharp
public object Value { get; }
```

#### Property Value

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

## Constructors

### **LocalContextValue(String, Object)**

Initializes a new instance of the LocalContextValue class with a fixed value.

```csharp
public LocalContextValue(string name, object value)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of this context value.

`value` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The static value to return when evaluated.

## Methods

### **GetValue(T, Func&lt;String, T, Object&gt;)**

Returns the static value, ignoring the input context and function parameters.

```csharp
public object GetValue(T input, Func<string, T, object> func)
```

#### Parameters

`input` T<br>
The root context object (ignored).

`func` Func&lt;String, T, Object&gt;<br>
Function to resolve variables (ignored).

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The static value stored in this context value.

### **GetValueAsync(T, Func&lt;String, T, Task&lt;Object&gt;&gt;)**

Asynchronously returns the static value, ignoring the input context and function parameters.

```csharp
public Task<object> GetValueAsync(T input, Func<string, T, Task<object>> func)
```

#### Parameters

`input` T<br>
The root context object (ignored).

`func` Func&lt;String, T, Task&lt;Object&gt;&gt;<br>
Async function to resolve variables (ignored).

#### Returns

[Task&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A completed task containing the static value.

---

[`< Back`](../../../)
