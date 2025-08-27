[`< Back`](../../../)

---

# PrefixExpressionExtensions

Namespace: Albatross.Expression.Nodes

Extension methods for IPrefixExpression that provide convenient operand access and validation.
 Simplifies getting values from prefix expression operands with type conversion and error handling.

```csharp
public static class PrefixExpressionExtensions
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PrefixExpressionExtensions](./albatross/expression/nodes/prefixexpressionextensions)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute), [ExtensionAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.extensionattribute)

## Methods

### **GetValue(IPrefixExpression, Int32, Func&lt;String, Object&gt;)**

Gets the evaluated value of an operand at the specified index.

```csharp
public static object GetValue(IPrefixExpression expression, int index, Func<string, object> context)
```

#### Parameters

`expression` [IPrefixExpression](./albatross/expression/nodes/iprefixexpression)<br>
The prefix expression containing the operands.

`index` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The zero-based index of the operand.

`context` [Func&lt;String, Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>
Function to resolve variable values during evaluation.

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The evaluated value of the operand.

#### Exceptions

[OperandException](./albatross/expression/exceptions/operandexception)<br>
Thrown when the index is out of range.

### **GetValueAsync(IPrefixExpression, Int32, Func&lt;String, Task&lt;Object&gt;&gt;)**

Asynchronously gets the evaluated value of an operand at the specified index.

```csharp
public static Task<object> GetValueAsync(IPrefixExpression expression, int index, Func<string, Task<object>> context)
```

#### Parameters

`expression` [IPrefixExpression](./albatross/expression/nodes/iprefixexpression)<br>
The prefix expression containing the operands.

`index` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The zero-based index of the operand.

`context` [Func&lt;String, Task&lt;Object&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>
Async function to resolve variable values during evaluation.

#### Returns

[Task&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task containing the evaluated value of the operand.

#### Exceptions

[OperandException](./albatross/expression/exceptions/operandexception)<br>
Thrown when the index is out of range.

### **GetStringValue(IPrefixExpression, Int32, Func&lt;String, Object&gt;)**

Gets the string representation of an operand value at the specified index.

```csharp
public static string GetStringValue(IPrefixExpression expression, int index, Func<string, object> context)
```

#### Parameters

`expression` [IPrefixExpression](./albatross/expression/nodes/iprefixexpression)<br>
The prefix expression containing the operands.

`index` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The zero-based index of the operand.

`context` [Func&lt;String, Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>
Function to resolve variable values during evaluation.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string representation of the operand value.

#### Exceptions

[OperandException](./albatross/expression/exceptions/operandexception)<br>
Thrown when the index is out of range.

### **GetStringValueAsync(IPrefixExpression, Int32, Func&lt;String, Task&lt;Object&gt;&gt;)**

Asynchronously gets the string representation of an operand value at the specified index.

```csharp
public static Task<string> GetStringValueAsync(IPrefixExpression expression, int index, Func<string, Task<object>> context)
```

#### Parameters

`expression` [IPrefixExpression](./albatross/expression/nodes/iprefixexpression)<br>
The prefix expression containing the operands.

`index` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The zero-based index of the operand.

`context` [Func&lt;String, Task&lt;Object&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>
Async function to resolve variable values during evaluation.

#### Returns

[Task&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task containing the string representation of the operand value.

#### Exceptions

[OperandException](./albatross/expression/exceptions/operandexception)<br>
Thrown when the index is out of range.

### **GetRequiredStringValue(IPrefixExpression, Int32, Func&lt;String, Object&gt;)**

Gets a required non-empty string value of an operand at the specified index.
 Trims whitespace and throws an exception if the result is empty.

```csharp
public static string GetRequiredStringValue(IPrefixExpression expression, int index, Func<string, object> context)
```

#### Parameters

`expression` [IPrefixExpression](./albatross/expression/nodes/iprefixexpression)<br>
The prefix expression containing the operands.

`index` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The zero-based index of the operand.

`context` [Func&lt;String, Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>
Function to resolve variable values during evaluation.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The trimmed string value of the operand.

#### Exceptions

[OperandException](./albatross/expression/exceptions/operandexception)<br>
Thrown when the index is out of range or the string value is empty after trimming.

### **GetRequiredStringValueAsync(IPrefixExpression, Int32, Func&lt;String, Task&lt;Object&gt;&gt;)**

Asynchronously gets a required non-empty string value of an operand at the specified index.
 Trims whitespace and throws an exception if the result is empty.

```csharp
public static Task<string> GetRequiredStringValueAsync(IPrefixExpression expression, int index, Func<string, Task<object>> context)
```

#### Parameters

`expression` [IPrefixExpression](./albatross/expression/nodes/iprefixexpression)<br>
The prefix expression containing the operands.

`index` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The zero-based index of the operand.

`context` [Func&lt;String, Task&lt;Object&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>
Async function to resolve variable values during evaluation.

#### Returns

[Task&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task containing the trimmed string value of the operand.

#### Exceptions

[OperandException](./albatross/expression/exceptions/operandexception)<br>
Thrown when the index is out of range or the string value is empty after trimming.

### **GetValues(IPrefixExpression, Func&lt;String, Object&gt;)**

Gets all operand values as a list by evaluating each operand.

```csharp
public static List<object> GetValues(IPrefixExpression expression, Func<string, object> context)
```

#### Parameters

`expression` [IPrefixExpression](./albatross/expression/nodes/iprefixexpression)<br>
The prefix expression containing the operands.

`context` [Func&lt;String, Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>
Function to resolve variable values during evaluation.

#### Returns

[List&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
A list containing the evaluated values of all operands.

### **GetValuesAsync(IPrefixExpression, Func&lt;String, Task&lt;Object&gt;&gt;)**

Asynchronously gets all operand values as a list by evaluating each operand.

```csharp
public static Task<List<object>> GetValuesAsync(IPrefixExpression expression, Func<string, Task<object>> context)
```

#### Parameters

`expression` [IPrefixExpression](./albatross/expression/nodes/iprefixexpression)<br>
The prefix expression containing the operands.

`context` [Func&lt;String, Task&lt;Object&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>
Async function to resolve variable values during evaluation.

#### Returns

[Task&lt;List&lt;Object&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task containing a list of evaluated values of all operands.

### **GetRequiredStringValue(List&lt;Object&gt;, Int32)**

Gets a required non-empty string value from a list at the specified index.
 Trims whitespace and throws an exception if the result is empty.

```csharp
public static string GetRequiredStringValue(List<object> list, int index)
```

#### Parameters

`list` [List&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
The list of values.

`index` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The zero-based index of the value.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The trimmed string value at the specified index.

#### Exceptions

[OperandException](./albatross/expression/exceptions/operandexception)<br>
Thrown when the string value is empty after trimming.

[ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception)<br>
Thrown when the index is out of range.

---

[`< Back`](../../../)
