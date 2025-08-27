[`< Back`](../../../)

---

# PadRight

Namespace: Albatross.Expression.Prefix

Prefix expression that pads a string to a specified total length by adding characters to the right.
 Takes 2-3 parameters: source string, total width, and optional padding character (defaults to space).

```csharp
public class PadRight : PrefixExpression, Albatross.Expression.Nodes.IPrefixExpression, Albatross.Expression.Nodes.IExpression, Albatross.Expression.Nodes.IToken
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PrefixExpression](./albatross/expression/prefix/prefixexpression) → [PadRight](./albatross/expression/prefix/padright)<br>
Implements [IPrefixExpression](./albatross/expression/nodes/iprefixexpression), [IExpression](./albatross/expression/nodes/iexpression), [IToken](./albatross/expression/nodes/itoken)

## Fields

### **DefaultPaddingCharacter**

The default padding character used when none is specified (space character).

```csharp
public static char DefaultPaddingCharacter;
```

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

### **PadRight()**

Initializes a new instance of the PadRight class with name "PadRight" and 2-3 parameters.

```csharp
public PadRight()
```

## Methods

### **Run(List&lt;Object&gt;)**

Pads the input string to the specified total width by adding padding characters to the right.
 If the string is already longer than the target width, returns the original string unchanged.

```csharp
protected object Run(List<object> operands)
```

#### Parameters

`operands` [List&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List containing 2-3 operands: source string, target width, and optional padding character.

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
A string padded to the specified width with characters added to the right.

#### Exceptions

!:FormatException<br>
Thrown when operands cannot be converted to appropriate types.

!:ArgumentOutOfRangeException<br>
Thrown when the target width is negative.

---

[`< Back`](../../../)
