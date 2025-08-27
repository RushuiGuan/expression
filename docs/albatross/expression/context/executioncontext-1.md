[`< Back`](../../../)

---

# ExecutionContext&lt;T&gt;

Namespace: Albatross.Expression.Context

Abstract base class for execution contexts that provide variable resolution and evaluation capabilities.
 Manages variable lookups, circular reference detection, and both synchronous and asynchronous evaluation.

```csharp
public abstract class ExecutionContext<T> : IExecutionContext`1
```

#### Type Parameters

`T`<br>
The type of the root context object.

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ExecutionContext&lt;T&gt;](./albatross/expression/context/executioncontext-1)<br>
Implements IExecutionContext&lt;T&gt;<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **Parser**

Gets the parser instance associated with this execution context.

```csharp
public IParser Parser { get; private set; }
```

#### Property Value

[IParser](./albatross/expression/iparser)<br>

## Constructors

### **ExecutionContext(IParser)**

Initializes a new instance of the ExecutionContext class.

```csharp
protected ExecutionContext(IParser parser)
```

#### Parameters

`parser` [IParser](./albatross/expression/iparser)<br>
The parser instance used for expression parsing and case-sensitivity settings.

## Methods

### **GetValue(String, T)**

Gets the value of a variable by name from the execution context.
 Throws an exception if the variable is not found.

```csharp
public object GetValue(string name, T input)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the variable to retrieve.

`input` T<br>
The root context object.

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The value of the variable.

#### Exceptions

[MissingVariableException](./albatross/expression/exceptions/missingvariableexception)<br>
Thrown when the variable is not found in the context.

### **TryGetValueHandler(String, IContextValue`1&)**

Abstract method that derived classes must implement to provide variable lookup logic.

```csharp
protected abstract bool TryGetValueHandler(string name, IContextValue`1& value)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the variable to look up.

`value` IContextValue`1&<br>
When this method returns, contains the context value if found, or null if not found.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
true if the variable was found; otherwise, false.

### **TryGetValue(String, T, Object&)**

Attempts to get the value of a variable by name from the execution context.
 Includes circular reference detection for expression-based context values.

```csharp
public bool TryGetValue(string name, T input, Object& data)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the variable to retrieve.

`input` T<br>
The root context object.

`data` [Object&](https://docs.microsoft.com/en-us/dotnet/api/system.object&)<br>
When this method returns, contains the variable value if found, or null if not found.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
true if the variable was found and evaluated successfully; otherwise, false.

### **GetValueAsync(String, T)**

```csharp
public Task<object> GetValueAsync(string name, T input)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`input` T<br>

#### Returns

[Task&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

---

[`< Back`](../../../)
