[`< Back`](../../../)

---

# JoinPath

Namespace: Albatross.Expression.Prefix

Prefix expression that combines multiple path segments into a single file system path.
 Takes one or more string parameters and joins them using the appropriate path separator.

```csharp
public class JoinPath : PrefixExpression, Albatross.Expression.Nodes.IPrefixExpression, Albatross.Expression.Nodes.IExpression, Albatross.Expression.Nodes.IToken
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PrefixExpression](./albatross/expression/prefix/prefixexpression) → [JoinPath](./albatross/expression/prefix/joinpath)<br>
Implements [IPrefixExpression](./albatross/expression/nodes/iprefixexpression), [IExpression](./albatross/expression/nodes/iexpression), [IToken](./albatross/expression/nodes/itoken)

## Properties

### **Name**

The name of the prefix function.

```csharp
public string Name { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Token**

The token representation, which is the same as the Name.

```csharp
public string Token { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **MinOperandCount**

The minimum number of operands this function requires.

```csharp
public int MinOperandCount { get; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **MaxOperandCount**

The maximum number of operands this function accepts.

```csharp
public int MaxOperandCount { get; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **Operands**

The list of operand expressions passed to this function.

```csharp
public IReadOnlyList<IExpression> Operands { get; set; }
```

#### Property Value

[IReadOnlyList&lt;IExpression&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1)<br>

## Constructors

### **JoinPath()**

Initializes a new instance of the JoinPath class with name "JoinPath" and variable parameter count (minimum 1).

```csharp
public JoinPath()
```

## Methods

### **Run(List&lt;Object&gt;)**

Combines multiple path segments into a single path string using the platform-appropriate path separator.
 All operands are converted to strings before joining.

```csharp
protected object Run(List<object> operands)
```

#### Parameters

`operands` [List&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List containing one or more path segment operands to join.

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
A combined file system path string with proper separators for the current platform.

---

[`< Back`](../../../)
