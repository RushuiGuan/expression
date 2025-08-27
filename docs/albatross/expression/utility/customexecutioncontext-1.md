[`< Back`](../../../)

---

# CustomExecutionContext&lt;T&gt;

Namespace: Albatross.Expression.Utility

Custom execution context that provides variable resolution from the file system.
 Extends the base ExecutionContext to load variables from text files stored in the application directory.

```csharp
public class CustomExecutionContext<T> : , 
```

#### Type Parameters

`T`<br>
The type of the root context object.

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ExecutionContext&lt;T&gt; → [CustomExecutionContext&lt;T&gt;](./albatross/expression/utility/customexecutioncontext-1)<br>
Implements IExecutionContext&lt;T&gt;<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **Parser**

```csharp
public IParser Parser { get; }
```

#### Property Value

IParser<br>

## Constructors

### **CustomExecutionContext(IParser, ExpressionConfig)**

Initializes a new instance of the CustomExecutionContext class.

```csharp
public CustomExecutionContext(IParser parser, ExpressionConfig config)
```

#### Parameters

`parser` IParser<br>
The expression parser for evaluating variable expressions.

`config` [ExpressionConfig](./albatross/expression/utility/expressionconfig)<br>
Configuration providing the application directory path for variable storage.

## Methods

### **TryGetValueHandler(String, IContextValue`1&)**

Attempts to resolve a variable value by reading from the corresponding text file.
 Looks for a file named "{name}.txt" in the application directory and creates an expression context value if found.

```csharp
protected bool TryGetValueHandler(string name, IContextValue`1& value)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The variable name to resolve.

`value` IContextValue`1&<br>
When this method returns, contains the context value if the variable was found, or null if not found.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
true if the variable file exists and was successfully loaded; otherwise, false.

---

[`< Back`](../../../)
