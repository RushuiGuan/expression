[`< Back`](../../../)

---

# Right

Namespace: Albatross.Expression.Prefix

Prefix expression that extracts a specified number of characters from the right side of a string.
 Takes two parameters: the source string and the number of characters to extract.

```csharp
public class Right : PrefixExpression, Albatross.Expression.Nodes.IPrefixExpression, Albatross.Expression.Nodes.IExpression, Albatross.Expression.Nodes.IToken
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PrefixExpression](./albatross/expression/prefix/prefixexpression) → [Right](./albatross/expression/prefix/right)<br>
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

### **Right()**

Initializes a new instance of the Right class with name "Right" and exactly two parameters.

```csharp
public Right()
```

## Methods

### **Run(List&lt;Object&gt;)**

Extracts the specified number of characters from the right side of the input string.
 If the requested count is greater than the string length, returns the entire string.

```csharp
protected object Run(List<object> operands)
```

#### Parameters

`operands` [List&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List containing exactly two operands: source string and character count.

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
A string containing the rightmost characters, or the entire string if count exceeds length.

#### Exceptions

[OperandException](./albatross/expression/exceptions/operandexception)<br>
Thrown when the character count is negative.

[FormatException](https://docs.microsoft.com/en-us/dotnet/api/system.formatexception)<br>
Thrown when operands cannot be converted to string and integer respectively.

---

[`< Back`](../../../)
