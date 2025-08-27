[`< Back`](../../../)

---

# SetCommand

Namespace: Albatross.Expression.Utility

Command validation logic for the set command that ensures variable names are valid.

```csharp
public sealed class SetCommand : System.CommandLine.Command, System.CommandLine.Completions.ICompletionSource, System.Collections.Generic.IEnumerable`1[[System.CommandLine.Symbol, System.CommandLine, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]], System.Collections.IEnumerable, Albatross.CommandLine.IRequireInitialization
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → Symbol → IdentifierSymbol → Command → [SetCommand](./albatross/expression/utility/setcommand)<br>
Implements ICompletionSource, [IEnumerable&lt;Symbol&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1), [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerable), IRequireInitialization<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **Option_Name**

```csharp
public Option<string> Option_Name { get; }
```

#### Property Value

Option&lt;String&gt;<br>

### **Option_Value**

```csharp
public Option<string> Option_Value { get; }
```

#### Property Value

Option&lt;String&gt;<br>

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

### **SetCommand()**

```csharp
public SetCommand()
```

## Methods

### **Init()**

Initializes validation rules for the set command to verify variable name format.

```csharp
public void Init()
```

---

[`< Back`](../../../)
