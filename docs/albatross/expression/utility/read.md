[`< Back`](../../../)

---

# Read

Namespace: Albatross.Expression.Utility

Command handler for reading and displaying stored variable values.
 Retrieves a variable from the execution context and outputs its current value.

```csharp
public class Read : Albatross.CommandLine.BaseHandler`1[[Albatross.Expression.Utility.EvalOptions, Albatross.Expression.Utility, Version=4.0.0.0, Culture=neutral, PublicKeyToken=null]], System.CommandLine.Invocation.ICommandHandler
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → BaseHandler&lt;EvalOptions&gt; → [Read](./albatross/expression/utility/read)<br>
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

### **Read(IOptions&lt;EvalOptions&gt;, IParser, IExecutionContext&lt;Object&gt;)**

Initializes a new instance of the Read class.

```csharp
public Read(IOptions<EvalOptions> options, IParser parser, IExecutionContext<object> executionContext)
```

#### Parameters

`options` IOptions&lt;EvalOptions&gt;<br>
Command options containing the variable name to read.

`parser` IParser<br>
Expression parser for building variable references.

`executionContext` IExecutionContext&lt;Object&gt;<br>
Execution context providing access to stored variables.

## Methods

### **Invoke(InvocationContext)**

Executes the read command by retrieving the variable value from the execution context.
 Outputs the variable value to the writer, or returns an error if the variable doesn't exist.

```csharp
public int Invoke(InvocationContext context)
```

#### Parameters

`context` InvocationContext<br>
The invocation context for the command.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Returns 0 on successful variable retrieval, non-zero if variable not found.

---

[`< Back`](../../../)
