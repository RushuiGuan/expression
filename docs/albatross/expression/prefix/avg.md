[`< Back`](../../../)

---

# Avg

Namespace: Albatross.Expression.Prefix

Prefix expression that calculates the arithmetic average of multiple numeric operands.
 Takes zero or more parameters and returns their mean value.

```csharp
public class Avg : PrefixExpression, Albatross.Expression.Nodes.IPrefixExpression, Albatross.Expression.Nodes.IExpression, Albatross.Expression.Nodes.IToken
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PrefixExpression](./albatross/expression/prefix/prefixexpression) → [Avg](./albatross/expression/prefix/avg)<br>
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

### **Avg()**

Initializes a new instance of the Avg class with name "Avg" and variable parameter count (minimum 0).

```csharp
public Avg()
```

## Methods

### **Run(List&lt;Object&gt;)**

Calculates the arithmetic average of all numeric operands.
 Each operand is converted to double, summed, and divided by the count. Returns NaN if no operands provided.

```csharp
protected object Run(List<object> items)
```

#### Parameters

`items` [List&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List containing zero or more numeric operands to average.

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The arithmetic mean of all operands as a double, or NaN for empty lists.

#### Exceptions

[FormatException](https://docs.microsoft.com/en-us/dotnet/api/system.formatexception)<br>
Thrown when any operand cannot be converted to a numeric value.

[DivideByZeroException](https://docs.microsoft.com/en-us/dotnet/api/system.dividebyzeroexception)<br>
May return NaN when dividing by zero operands.

---

[`< Back`](../../../)
