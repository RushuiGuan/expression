[`< Back`](../../../)

---

# MaxNumber

Namespace: Albatross.Expression.Prefix

Prefix expression that finds the maximum value among multiple numeric operands.
 Takes one or more parameters and returns the largest numeric value.

```csharp
public class MaxNumber : PrefixExpression, Albatross.Expression.Nodes.IPrefixExpression, Albatross.Expression.Nodes.IExpression, Albatross.Expression.Nodes.IToken
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PrefixExpression](./albatross/expression/prefix/prefixexpression) → [MaxNumber](./albatross/expression/prefix/maxnumber)<br>
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

### **MaxNumber()**

Initializes a new instance of the MaxNumber class with name "Max" and variable parameter count (minimum 1).

```csharp
public MaxNumber()
```

## Methods

### **Run(List&lt;Object&gt;)**

Finds and returns the maximum numeric value from all operands.
 Each operand is converted to double before comparison.

```csharp
protected object Run(List<object> list)
```

#### Parameters

`list` [List&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List containing one or more numeric operands to compare.

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The maximum numeric value as a double.

#### Exceptions

[FormatException](https://docs.microsoft.com/en-us/dotnet/api/system.formatexception)<br>
Thrown when any operand cannot be converted to a numeric value.

---

[`< Back`](../../../)
