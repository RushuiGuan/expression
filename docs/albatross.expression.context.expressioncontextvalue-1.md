# ExpressionContextValue&lt;T&gt;

Namespace: Albatross.Expression.Context

```csharp
public class ExpressionContextValue<T> : IContextValue`1
```

#### Type Parameters

`T`<br>

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ExpressionContextValue&lt;T&gt;](./albatross.expression.context.expressioncontextvalue-1.md)<br>
Implements IContextValue&lt;T&gt;<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **Name**

```csharp
public string Name { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Expression**

```csharp
public string Expression { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Tree**

```csharp
public IExpression Tree { get; }
```

#### Property Value

[IExpression](./albatross.expression.nodes.iexpression.md)<br>

### **Dependees**

```csharp
public ISet<string> Dependees { get; }
```

#### Property Value

[ISet&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.iset-1)<br>

## Constructors

### **ExpressionContextValue(String, String, IParser)**

```csharp
public ExpressionContextValue(string name, string expression, IParser parser)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`expression` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`parser` [IParser](./albatross.expression.iparser.md)<br>

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
