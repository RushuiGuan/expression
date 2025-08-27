[`< Back`](../../../)

---

# Set

Namespace: Albatross.Expression.Utility

Command handler for storing variables to the file system. Creates a text file for each variable
 in the application directory with the variable name as filename and value as content.

```csharp
public class Set : Albatross.CommandLine.BaseHandler`1[[Albatross.Expression.Utility.SetOptions, Albatross.Expression.Utility, Version=4.0.0.0, Culture=neutral, PublicKeyToken=null]], System.CommandLine.Invocation.ICommandHandler
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → BaseHandler&lt;SetOptions&gt; → [Set](./albatross/expression/utility/set)<br>
Implements ICommandHandler<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Fields

### **options**

```csharp
protected SetOptions options;
```

## Properties

### **writer**

```csharp
protected TextWriter writer { get; }
```

#### Property Value

[TextWriter](https://docs.microsoft.com/en-us/dotnet/api/system.io.textwriter)<br>

## Constructors

### **Set(ExpressionConfig, IOptions&lt;SetOptions&gt;)**

Initializes a new instance of the Set class.

```csharp
public Set(ExpressionConfig config, IOptions<SetOptions> options)
```

#### Parameters

`config` [ExpressionConfig](./albatross/expression/utility/expressionconfig)<br>
Configuration providing application directory path.

`options` IOptions&lt;SetOptions&gt;<br>
Command options containing variable name and value.

## Methods

### **InvokeAsync(InvocationContext)**

Executes the set command by writing the variable value to a text file.
 Creates the application directory if it doesn't exist and overwrites any existing variable with the same name.

```csharp
public Task<int> InvokeAsync(InvocationContext context)
```

#### Parameters

`context` InvocationContext<br>
The invocation context for the command.

#### Returns

[Task&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task representing the asynchronous operation. Returns 0 on success.

---

[`< Back`](../../../)
