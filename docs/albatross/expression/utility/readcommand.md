[`< Back`](../../../)

---

# ReadCommand

Namespace: Albatross.Expression.Utility

```csharp
public sealed class ReadCommand : System.CommandLine.Command, System.CommandLine.Completions.ICompletionSource, System.Collections.Generic.IEnumerable`1[[System.CommandLine.Symbol, System.CommandLine, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]], System.Collections.IEnumerable
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → Symbol → IdentifierSymbol → Command → [ReadCommand](./albatross/expression/utility/readcommand)<br>
Implements ICompletionSource, [IEnumerable&lt;Symbol&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1), [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerable)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **Argument_Argument**

```csharp
public Argument<string> Argument_Argument { get; }
```

#### Property Value

Argument&lt;String&gt;<br>

### **Children**

```csharp
public IEnumerable<Symbol> Children { get; }
```

#### Property Value

[IEnumerable&lt;Symbol&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

### **Arguments**

```csharp
public IReadOnlyList<Argument> Arguments { get; }
```

#### Property Value

[IReadOnlyList&lt;Argument&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1)<br>

### **Options**

```csharp
public IReadOnlyList<Option> Options { get; }
```

#### Property Value

[IReadOnlyList&lt;Option&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1)<br>

### **Subcommands**

```csharp
public IReadOnlyList<Command> Subcommands { get; }
```

#### Property Value

[IReadOnlyList&lt;Command&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1)<br>

### **TreatUnmatchedTokensAsErrors**

```csharp
public bool TreatUnmatchedTokensAsErrors { get; set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **Handler**

```csharp
public ICommandHandler Handler { get; set; }
```

#### Property Value

ICommandHandler<br>

### **Aliases**

```csharp
public IReadOnlyCollection<string> Aliases { get; }
```

#### Property Value

[IReadOnlyCollection&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlycollection-1)<br>

### **Name**

```csharp
public string Name { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Description**

```csharp
public string Description { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **IsHidden**

```csharp
public bool IsHidden { get; set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **Parents**

```csharp
public IEnumerable<Symbol> Parents { get; }
```

#### Property Value

[IEnumerable&lt;Symbol&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

## Constructors

### **ReadCommand()**

```csharp
public ReadCommand()
```

---

[`< Back`](../../../)
