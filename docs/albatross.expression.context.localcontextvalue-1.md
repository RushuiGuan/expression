# LocalContextValue&lt;T&gt;

Namespace: Albatross.Expression.Context

```csharp
public class LocalContextValue<T> : IContextValue`1
```

#### Type Parameters

`T`<br>

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [LocalContextValue&lt;T&gt;](./albatross.expression.context.localcontextvalue-1.md)<br>
Implements IContextValue&lt;T&gt;<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **Name**

```csharp
public string Name { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Value**

```csharp
public object Value { get; }
```

#### Property Value

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

## Constructors

### **LocalContextValue(String, Object)**

```csharp
public LocalContextValue(string name, object value)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`value` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

## Methods

### **GetValue(T, Func&lt;String, T, Object&gt;)**

```csharp
public object GetValue(T input, Func<string, T, object> func)
```

#### Parameters

`input` T<br>

`func` Func&lt;String, T, Object&gt;<br>

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **GetValueAsync(T, Func&lt;String, T, Task&lt;Object&gt;&gt;)**

```csharp
public Task<object> GetValueAsync(T input, Func<string, T, Task<object>> func)
```

#### Parameters

`input` T<br>

`func` Func&lt;String, T, Task&lt;Object&gt;&gt;<br>

#### Returns

[Task&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
