[`< Back`](../../../)

---

# NotEqual

Namespace: Albatross.Expression.Infix

Infix expression that performs not-equal comparison between two operands.
 Uses the "&lt;&gt;" operator with precedence 50.

```csharp
public class NotEqual : ComparisonInfixOperation, Albatross.Expression.Nodes.IInfixExpression, Albatross.Expression.Nodes.IExpression, Albatross.Expression.Nodes.IToken, Albatross.Expression.Nodes.IHasPrecedence
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [InfixExpression](./albatross/expression/infix/infixexpression) → [ComparisonInfixOperation](./albatross/expression/infix/comparisoninfixoperation) → [NotEqual](./albatross/expression/infix/notequal)<br>
Implements [IInfixExpression](./albatross/expression/nodes/iinfixexpression), [IExpression](./albatross/expression/nodes/iexpression), [IToken](./albatross/expression/nodes/itoken), [IHasPrecedence](./albatross/expression/nodes/ihasprecedence)

## Properties

### **Operator**

The operator symbol for this infix operation.

```csharp
public string Operator { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Token**

The token representation, which is the same as the Operator.

```csharp
public string Token { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Precedence**

The precedence level of this operation for proper evaluation order.

```csharp
public int Precedence { get; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **Left**

The left operand of the infix operation.

```csharp
public IExpression Left { get; set; }
```

#### Property Value

[IExpression](./albatross/expression/nodes/iexpression)<br>

### **Right**

The right operand of the infix operation.

```csharp
public IExpression Right { get; set; }
```

#### Property Value

[IExpression](./albatross/expression/nodes/iexpression)<br>

### **RequiredLeft**

Gets the required left operand, throwing an exception if it's null.

```csharp
public IExpression RequiredLeft { get; }
```

#### Property Value

[IExpression](./albatross/expression/nodes/iexpression)<br>

### **RequiredRight**

Gets the required right operand, throwing an exception if it's null.

```csharp
public IExpression RequiredRight { get; }
```

#### Property Value

[IExpression](./albatross/expression/nodes/iexpression)<br>

## Constructors

### **NotEqual()**

Initializes a new instance of the NotEqual class with operator "&lt;&gt;" and precedence 50.

```csharp
public NotEqual()
```

## Methods

### **Interpret(Int32)**

Interprets the comparison result to determine if the operands are not equal.

```csharp
public bool Interpret(int comparisonResult)
```

#### Parameters

`comparisonResult` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The result from comparing the operands (-1, 0, or 1).

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
true if the operands are not equal (comparison result is not 0); otherwise, false.

---

[`< Back`](../../../)
