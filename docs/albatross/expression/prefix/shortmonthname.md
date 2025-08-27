[`< Back`](../../../)

---

# ShortMonthName

Namespace: Albatross.Expression.Prefix

Prefix expression that returns the abbreviated month name from a DateTime value.
 Uses the current culture's formatting to return the localized short month name.

```csharp
public class ShortMonthName : PrefixExpression, Albatross.Expression.Nodes.IPrefixExpression, Albatross.Expression.Nodes.IExpression, Albatross.Expression.Nodes.IToken
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PrefixExpression](./albatross/expression/prefix/prefixexpression) → [ShortMonthName](./albatross/expression/prefix/shortmonthname)<br>
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

### **ShortMonthName()**

Initializes a new instance of the ShortMonthName class with name "ShortMonthName" and exactly one parameter.

```csharp
public ShortMonthName()
```

## Methods

### **Run(List&lt;Object&gt;)**

Returns the abbreviated month name from the provided DateTime operand using current culture formatting.
 For example, returns "Jan", "Feb", etc. in English or localized equivalents.

```csharp
protected object Run(List<object> operands)
```

#### Parameters

`operands` [List&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List containing exactly one operand that can be converted to DateTime.

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
A string containing the abbreviated month name in the current culture.

#### Exceptions

[FormatException](https://docs.microsoft.com/en-us/dotnet/api/system.formatexception)<br>
Thrown when the operand cannot be converted to DateTime.

---

[`< Back`](../../../)
