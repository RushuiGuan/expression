# ExternalContextValue&lt;T&gt;

Namespace: Albatross.Expression.Context

```csharp
public class ExternalContextValue<T> : IContextValue`1
```

#### Type Parameters

`T`<br>

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ExternalContextValue&lt;T&gt;](./albatross.expression.context.externalcontextvalue-1.md)<br>
Implements IContextValue&lt;T&gt;<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **Name**

```csharp
public string Name { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Constructors

### **ExternalContextValue(String, Func&lt;T, Object&gt;)**

```csharp
public ExternalContextValue(string name, Func<T, object> func)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`func` Func&lt;T, Object&gt;<br>

## Methods

### **GetValue(T, Func&lt;String, T, Object&gt;)**

```csharp
public object GetValue(T input, Func<string, T, object> _)
```

#### Parameters

`input` T<br>

`_` Func&lt;String, T, Object&gt;<br>

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **GetValueAsync(T, Func&lt;String, T, Task&lt;Object&gt;&gt;)**

```csharp
public Task<object> GetValueAsync(T input, Func<string, T, Task<object>> _)
```

#### Parameters

`input` T<br>

`_` Func&lt;String, T, Task&lt;Object&gt;&gt;<br>

#### Returns

[Task&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
