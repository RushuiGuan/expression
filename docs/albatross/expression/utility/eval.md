[`< Back`](../../../)

---

# Eval

Namespace: Albatross.Expression.Utility

Command handler for evaluating expressions using the Albatross.Expression parser.
 Supports mathematical, logical, string operations, date/time functions, and variable references.

```csharp
public class Eval : Albatross.CommandLine.BaseHandler`1[[Albatross.Expression.Utility.EvalOptions, Albatross.Expression.Utility, Version=4.0.0.0, Culture=neutral, PublicKeyToken=null]], System.CommandLine.Invocation.ICommandHandler
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → BaseHandler&lt;EvalOptions&gt; → [Eval](./albatross/expression/utility/eval)<br>
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

### **Eval(IOptions&lt;EvalOptions&gt;, IParser, IExecutionContext&lt;Object&gt;)**

Initializes a new instance of the Eval class.

```csharp
public Eval(IOptions<EvalOptions> options, IParser parser, IExecutionContext<object> executionContext)
```

#### Parameters

`options` IOptions&lt;EvalOptions&gt;<br>
Command options containing the expression to evaluate.

`parser` IParser<br>
Expression parser for tokenizing and evaluating expressions.

`executionContext` IExecutionContext&lt;Object&gt;<br>
Execution context providing variable scope and built-in functions.

## Methods

### **Invoke(InvocationContext)**

Executes the eval command by parsing and evaluating the provided expression.
 Writes the result to the output writer. Supports complex expressions with variables, functions, and operations.

```csharp
public int Invoke(InvocationContext context)
```

#### Parameters

`context` InvocationContext<br>
The invocation context for the command.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Returns 0 on successful evaluation, non-zero on parsing or evaluation errors.

---

[`< Back`](../../../)
