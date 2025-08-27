# DefaultExecutionContext&lt;T&gt;

Namespace: Albatross.Expression.Context

```csharp
public class DefaultExecutionContext<T> : ExecutionContext`1, IExecutionContext`1
```

#### Type Parameters

`T`<br>

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ExecutionContext&lt;T&gt; → [DefaultExecutionContext&lt;T&gt;](./albatross.expression.context.defaultexecutioncontext-1.md)<br>
Implements IExecutionContext&lt;T&gt;<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **Store**

```csharp
public Dictionary<string, IContextValue<T>> Store { get; private set; }
```

#### Property Value

Dictionary&lt;String, IContextValue&lt;T&gt;&gt;<br>

### **Parser**

```csharp
public IParser Parser { get; }
```

#### Property Value

[IParser](./albatross.expression.iparser.md)<br>

## Constructors

### **DefaultExecutionContext(IParser)**

```csharp
public DefaultExecutionContext(IParser parser)
```

#### Parameters

`parser` [IParser](./albatross.expression.iparser.md)<br>

## Methods

### **TryGetValueHandler(String, IContextValue`1&)**

```csharp
protected bool TryGetValueHandler(string name, IContextValue`1& value)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`value` IContextValue`1&<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **Clear()**

```csharp
public void Clear()
```

### **Set(IContextValue&lt;T&gt;)**

```csharp
public void Set(IContextValue<T> value)
```

#### Parameters

`value` IContextValue&lt;T&gt;<br>
