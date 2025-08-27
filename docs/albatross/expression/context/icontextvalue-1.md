[`< Back`](../../../)

---

# IContextValue&lt;T&gt;

Namespace: Albatross.Expression.Context

Represents a context value that can be resolved during expression evaluation.

```csharp
public interface IContextValue<T>
```

#### Type Parameters

`T`<br>
The type of input object used for value resolution.

Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute)

## Properties

### **Name**

The name of this context value.

```csharp
public abstract string Name { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Methods

### **GetValue(T, Func&lt;String, T, Object&gt;)**

Retrieves the value using the provided input and context resolution function.

```csharp
object GetValue(T input, Func<string, T, object> func)
```

#### Parameters

`input` T<br>
The input object containing context data.

`func` Func&lt;String, T, Object&gt;<br>
Function to resolve additional context values if needed.

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The resolved value.

### **GetValueAsync(T, Func&lt;String, T, Task&lt;Object&gt;&gt;)**

Asynchronously retrieves the value using the provided input and context resolution function.

```csharp
Task<object> GetValueAsync(T input, Func<string, T, Task<object>> func)
```

#### Parameters

`input` T<br>
The input object containing context data.

`func` Func&lt;String, T, Task&lt;Object&gt;&gt;<br>
Function to asynchronously resolve additional context values if needed.

#### Returns

[Task&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task containing the resolved value.

---

[`< Back`](../../../)
