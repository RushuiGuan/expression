[`< Back`](../../../)

---

# Month

Namespace: Albatross.Expression.Prefix

Prefix expression that extracts the month component from a DateTime value.
 Returns an integer representing the month (1-12).

```csharp
public class Month : PrefixExpression, Albatross.Expression.Nodes.IPrefixExpression, Albatross.Expression.Nodes.IExpression, Albatross.Expression.Nodes.IToken
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PrefixExpression](./albatross/expression/prefix/prefixexpression) → [Month](./albatross/expression/prefix/month)<br>
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

### **Month()**

Initializes a new instance of the Month class with name "Month" and exactly one parameter.

```csharp
public Month()
```

## Methods

### **Run(List&lt;Object&gt;)**

Extracts the month component from the provided DateTime operand.

```csharp
protected object Run(List<object> operands)
```

#### Parameters

`operands` [List&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List containing exactly one operand that can be converted to DateTime.

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
An integer representing the month (1 for January, 12 for December).

#### Exceptions

[FormatException](https://docs.microsoft.com/en-us/dotnet/api/system.formatexception)<br>
Thrown when the operand cannot be converted to DateTime.

---

[`< Back`](../../../)
