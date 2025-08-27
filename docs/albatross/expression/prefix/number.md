[`< Back`](../../../)

---

# Number

Namespace: Albatross.Expression.Prefix

Prefix expression that converts an operand to a numeric (double) value.
 Takes exactly one parameter and performs type conversion to double.

```csharp
public class Number : PrefixExpression, Albatross.Expression.Nodes.IPrefixExpression, Albatross.Expression.Nodes.IExpression, Albatross.Expression.Nodes.IToken
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PrefixExpression](./albatross/expression/prefix/prefixexpression) → [Number](./albatross/expression/prefix/number)<br>
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

### **Number()**

Initializes a new instance of the Number class with name "Number" and exactly one parameter.

```csharp
public Number()
```

## Methods

### **Run(List&lt;Object&gt;)**

Converts the provided operand to a double value using the framework's conversion methods.
 Supports conversion from strings, numeric types, and JSON elements.

```csharp
protected object Run(List<object> operands)
```

#### Parameters

`operands` [List&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List containing exactly one operand to convert to numeric value.

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The numeric representation of the operand as a double.

#### Exceptions

[FormatException](https://docs.microsoft.com/en-us/dotnet/api/system.formatexception)<br>
Thrown when the operand cannot be converted to a numeric value.

---

[`< Back`](../../../)
