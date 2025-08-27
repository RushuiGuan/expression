[`< Back`](../../../)

---

# DefaultExecutionContext&lt;T&gt;

Namespace: Albatross.Expression.Context

Default implementation of execution context that maintains an in-memory store of variable values.
 Provides case-sensitive or case-insensitive variable lookups based on parser configuration.

```csharp
public class DefaultExecutionContext<T> : ExecutionContext`1, IExecutionContext`1
```

#### Type Parameters

`T`<br>
The type of the root context object.

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ExecutionContext&lt;T&gt; → [DefaultExecutionContext&lt;T&gt;](./albatross/expression/context/defaultexecutioncontext-1)<br>
Implements IExecutionContext&lt;T&gt;<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **Store**

Gets the internal dictionary that stores variable names and their corresponding context values.

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

[IParser](./albatross/expression/iparser)<br>

## Constructors

### **DefaultExecutionContext(IParser)**

Initializes a new instance of the DefaultExecutionContext class.
 Creates an internal dictionary with case-sensitivity matching the parser's configuration.

```csharp
public DefaultExecutionContext(IParser parser)
```

#### Parameters

`parser` [IParser](./albatross/expression/iparser)<br>
The parser instance that determines case-sensitivity settings.

## Methods

### **TryGetValueHandler(String, IContextValue`1&)**

Attempts to retrieve a context value from the internal store by name.

```csharp
protected bool TryGetValueHandler(string name, IContextValue`1& value)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the variable to look up.

`value` IContextValue`1&<br>
When this method returns, contains the context value if found, or null if not found.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
true if the variable was found in the store; otherwise, false.

### **Clear()**

Removes all variables from the execution context store.

```csharp
public void Clear()
```

### **Set(IContextValue&lt;T&gt;)**

Adds or updates a context value in the execution context store.

```csharp
public void Set(IContextValue<T> value)
```

#### Parameters

`value` IContextValue&lt;T&gt;<br>
The context value to add or update.

---

[`< Back`](../../../)
