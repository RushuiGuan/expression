[`< Back`](../../../)

---

# MinNumber

Namespace: Albatross.Expression.Prefix

Prefix expression that finds the minimum value among multiple numeric operands.
 Takes zero or more parameters and returns the smallest numeric value, or MaxValue if no operands.

```csharp
public class MinNumber : PrefixExpression, Albatross.Expression.Nodes.IPrefixExpression, Albatross.Expression.Nodes.IExpression, Albatross.Expression.Nodes.IToken
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PrefixExpression](./albatross/expression/prefix/prefixexpression) → [MinNumber](./albatross/expression/prefix/minnumber)<br>
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

### **MinNumber()**

Initializes a new instance of the MinNumber class with name "Min" and variable parameter count (minimum 0).

```csharp
public MinNumber()
```

## Methods

### **Run(List&lt;Object&gt;)**

Finds and returns the minimum numeric value from all operands.
 Each operand is converted to double before comparison. Returns MaxValue if no operands provided.

```csharp
protected object Run(List<object> operands)
```

#### Parameters

`operands` [List&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List containing zero or more numeric operands to compare.

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The minimum numeric value as a double, or double.MaxValue if no operands.

#### Exceptions

[FormatException](https://docs.microsoft.com/en-us/dotnet/api/system.formatexception)<br>
Thrown when any operand cannot be converted to a numeric value.

---

[`< Back`](../../../)
