[`< Back`](../../../)

---

# Remove

Namespace: Albatross.Expression.Utility

Command handler for removing stored variables from the file system.
 Deletes the text file associated with the specified variable name.

```csharp
public class Remove : Albatross.CommandLine.BaseHandler`1[[Albatross.Expression.Utility.RemoveOptions, Albatross.Expression.Utility, Version=4.0.0.0, Culture=neutral, PublicKeyToken=null]], System.CommandLine.Invocation.ICommandHandler
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → BaseHandler&lt;RemoveOptions&gt; → [Remove](./albatross/expression/utility/remove)<br>
Implements ICommandHandler<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Fields

### **options**

```csharp
protected RemoveOptions options;
```

## Properties

### **writer**

```csharp
protected TextWriter writer { get; }
```

#### Property Value

[TextWriter](https://docs.microsoft.com/en-us/dotnet/api/system.io.textwriter)<br>

## Constructors

### **Remove(IOptions&lt;RemoveOptions&gt;, ExpressionConfig)**

Initializes a new instance of the Remove class.

```csharp
public Remove(IOptions<RemoveOptions> options, ExpressionConfig config)
```

#### Parameters

`options` IOptions&lt;RemoveOptions&gt;<br>
Command options containing the variable name to remove.

`config` [ExpressionConfig](./albatross/expression/utility/expressionconfig)<br>
Configuration providing application directory path.

## Methods

### **Invoke(InvocationContext)**

Executes the remove command by deleting the variable file if it exists.
 Performs a silent delete operation - no error is thrown if the variable doesn't exist.

```csharp
public int Invoke(InvocationContext context)
```

#### Parameters

`context` InvocationContext<br>
The invocation context for the command.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Returns 0 on successful completion regardless of whether the file existed.

---

[`< Back`](../../../)
