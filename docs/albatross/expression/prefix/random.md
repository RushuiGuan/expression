[`< Back`](../../../)

---

# Random

Namespace: Albatross.Expression.Prefix

Prefix expression that generates a random integer within a specified range.
 Takes two parameters: minimum (inclusive) and maximum (exclusive) values.

```csharp
public class Random : PrefixExpression, Albatross.Expression.Nodes.IPrefixExpression, Albatross.Expression.Nodes.IExpression, Albatross.Expression.Nodes.IToken
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PrefixExpression](./albatross/expression/prefix/prefixexpression) → [Random](./albatross/expression/prefix/random)<br>
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

### **Random()**

Initializes a new instance of the Random class with name "Random" and exactly two parameters.

```csharp
public Random()
```

## Methods

### **Run(List&lt;Object&gt;)**

Generates a random integer between the minimum (inclusive) and maximum (exclusive) values.
 Uses the shared Random instance for thread safety.

```csharp
protected object Run(List<object> operands)
```

#### Parameters

`operands` [List&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List containing exactly two operands: minimum and maximum integer values.

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
A random integer greater than or equal to min and less than max.

#### Exceptions

[FormatException](https://docs.microsoft.com/en-us/dotnet/api/system.formatexception)<br>
Thrown when operands cannot be converted to integers.

!:ArgumentOutOfRangeException<br>
Thrown when min is greater than max.

---

[`< Back`](../../../)
