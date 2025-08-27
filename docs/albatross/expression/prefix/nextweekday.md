[`< Back`](../../../)

---

# NextWeekDay

Namespace: Albatross.Expression.Prefix

Prefix expression that finds the next weekday (Monday-Friday) from a given date.
 Takes 1-2 parameters: the starting date and optional number of weekdays to advance (defaults to 1).

```csharp
public class NextWeekDay : PrefixExpression, Albatross.Expression.Nodes.IPrefixExpression, Albatross.Expression.Nodes.IExpression, Albatross.Expression.Nodes.IToken
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PrefixExpression](./albatross/expression/prefix/prefixexpression) → [NextWeekDay](./albatross/expression/prefix/nextweekday)<br>
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

### **NextWeekDay()**

Initializes a new instance of the NextWeekDay class with name "NextWeekDay" and 1-2 parameters.

```csharp
public NextWeekDay()
```

## Methods

### **Run(List&lt;Object&gt;)**

Finds the next weekday by advancing the specified number of weekdays from the given date.
 Skips weekends (Saturday and Sunday) and returns the next business day.

```csharp
protected object Run(List<object> operands)
```

#### Parameters

`operands` [List&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List containing 1-2 operands: starting date and optional weekday count (defaults to 1).

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
A DateTime representing the next weekday after advancing the specified count.

#### Exceptions

!:FormatException<br>
Thrown when operands cannot be converted to appropriate types.

---

[`< Back`](../../../)
