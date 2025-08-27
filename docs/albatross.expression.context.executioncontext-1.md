# ExecutionContext&lt;T&gt;

Namespace: Albatross.Expression.Context

```csharp
public abstract class ExecutionContext<T> : IExecutionContext`1
```

#### Type Parameters

`T`<br>

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ExecutionContext&lt;T&gt;](./albatross.expression.context.executioncontext-1.md)<br>
Implements IExecutionContext&lt;T&gt;<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **Parser**

```csharp
public IParser Parser { get; private set; }
```

#### Property Value

[IParser](./albatross.expression.iparser.md)<br>

## Constructors

### **ExecutionContext(IParser)**

```csharp
protected ExecutionContext(IParser parser)
```

#### Parameters

`parser` [IParser](./albatross.expression.iparser.md)<br>

## Methods

### **GetValue(String, T)**

```csharp
public object GetValue(string name, T input)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`input` T<br>

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **TryGetValueHandler(String, IContextValue`1&)**

```csharp
protected abstract bool TryGetValueHandler(string name, IContextValue`1& value)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`value` IContextValue`1&<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **TryGetValue(String, T, Object&)**

```csharp
public bool TryGetValue(string name, T input, Object& data)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`input` T<br>

`data` [Object&](https://docs.microsoft.com/en-us/dotnet/api/system.object&)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **GetValueAsync(String, T)**

```csharp
public Task<object> GetValueAsync(string name, T input)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`input` T<br>

#### Returns

[Task&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
