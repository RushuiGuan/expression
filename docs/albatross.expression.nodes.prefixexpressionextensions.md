# PrefixExpressionExtensions

Namespace: Albatross.Expression.Nodes

```csharp
public static class PrefixExpressionExtensions
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PrefixExpressionExtensions](./albatross.expression.nodes.prefixexpressionextensions.md)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute), [ExtensionAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.extensionattribute)

## Methods

### **GetValue(IPrefixExpression, Int32, Func&lt;String, Object&gt;)**

```csharp
public static object GetValue(IPrefixExpression expression, int index, Func<string, object> context)
```

#### Parameters

`expression` [IPrefixExpression](./albatross.expression.nodes.iprefixexpression.md)<br>

`index` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`context` [Func&lt;String, Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **GetValueAsync(IPrefixExpression, Int32, Func&lt;String, Task&lt;Object&gt;&gt;)**

```csharp
public static Task<object> GetValueAsync(IPrefixExpression expression, int index, Func<string, Task<object>> context)
```

#### Parameters

`expression` [IPrefixExpression](./albatross.expression.nodes.iprefixexpression.md)<br>

`index` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`context` [Func&lt;String, Task&lt;Object&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>

#### Returns

[Task&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetStringValue(IPrefixExpression, Int32, Func&lt;String, Object&gt;)**

```csharp
public static string GetStringValue(IPrefixExpression expression, int index, Func<string, object> context)
```

#### Parameters

`expression` [IPrefixExpression](./albatross.expression.nodes.iprefixexpression.md)<br>

`index` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`context` [Func&lt;String, Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **GetStringValueAsync(IPrefixExpression, Int32, Func&lt;String, Task&lt;Object&gt;&gt;)**

```csharp
public static Task<string> GetStringValueAsync(IPrefixExpression expression, int index, Func<string, Task<object>> context)
```

#### Parameters

`expression` [IPrefixExpression](./albatross.expression.nodes.iprefixexpression.md)<br>

`index` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`context` [Func&lt;String, Task&lt;Object&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>

#### Returns

[Task&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetRequiredStringValue(IPrefixExpression, Int32, Func&lt;String, Object&gt;)**

```csharp
public static string GetRequiredStringValue(IPrefixExpression expression, int index, Func<string, object> context)
```

#### Parameters

`expression` [IPrefixExpression](./albatross.expression.nodes.iprefixexpression.md)<br>

`index` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`context` [Func&lt;String, Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **GetRequiredStringValueAsync(IPrefixExpression, Int32, Func&lt;String, Task&lt;Object&gt;&gt;)**

```csharp
public static Task<string> GetRequiredStringValueAsync(IPrefixExpression expression, int index, Func<string, Task<object>> context)
```

#### Parameters

`expression` [IPrefixExpression](./albatross.expression.nodes.iprefixexpression.md)<br>

`index` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`context` [Func&lt;String, Task&lt;Object&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>

#### Returns

[Task&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetValues(IPrefixExpression, Func&lt;String, Object&gt;)**

```csharp
public static List<object> GetValues(IPrefixExpression expression, Func<string, object> context)
```

#### Parameters

`expression` [IPrefixExpression](./albatross.expression.nodes.iprefixexpression.md)<br>

`context` [Func&lt;String, Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>

#### Returns

[List&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **GetValuesAsync(IPrefixExpression, Func&lt;String, Task&lt;Object&gt;&gt;)**

```csharp
public static Task<List<object>> GetValuesAsync(IPrefixExpression expression, Func<string, Task<object>> context)
```

#### Parameters

`expression` [IPrefixExpression](./albatross.expression.nodes.iprefixexpression.md)<br>

`context` [Func&lt;String, Task&lt;Object&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>

#### Returns

[Task&lt;List&lt;Object&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetRequiredStringValue(List&lt;Object&gt;, Int32)**

```csharp
public static string GetRequiredStringValue(List<object> list, int index)
```

#### Parameters

`list` [List&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

`index` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
