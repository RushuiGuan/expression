[`< Back`](../../../)

---

# List

Namespace: Albatross.Expression.Utility

Command handler for listing all stored variables in a tabular format.
 Reads all text files from the application directory and displays their names and values.

```csharp
public class List : Albatross.CommandLine.BaseHandler`1[[Albatross.Expression.Utility.EvalOptions, Albatross.Expression.Utility, Version=4.0.0.0, Culture=neutral, PublicKeyToken=null]], System.CommandLine.Invocation.ICommandHandler
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → BaseHandler&lt;EvalOptions&gt; → [List](./albatross/expression/utility/list)<br>
Implements ICommandHandler<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Fields

### **options**

```csharp
protected EvalOptions options;
```

## Properties

### **writer**

```csharp
protected TextWriter writer { get; }
```

#### Property Value

[TextWriter](https://docs.microsoft.com/en-us/dotnet/api/system.io.textwriter)<br>

## Constructors

### **List(IOptions&lt;EvalOptions&gt;, ExpressionConfig)**

Initializes a new instance of the List class.

```csharp
public List(IOptions<EvalOptions> options, ExpressionConfig config)
```

#### Parameters

`options` IOptions&lt;EvalOptions&gt;<br>
Command options for evaluation (inherited from base handler).

`config` [ExpressionConfig](./albatross/expression/utility/expressionconfig)<br>
Configuration providing application directory path.

## Methods

### **Invoke(InvocationContext)**

Executes the list command by reading all variable files and displaying them in a table format.
 Creates the application directory if it doesn't exist and shows an empty table if no variables are found.

```csharp
public int Invoke(InvocationContext context)
```

#### Parameters

`context` InvocationContext<br>
The invocation context for the command.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Returns 0 on successful completion.

---

[`< Back`](../../../)
