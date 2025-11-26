[`< Back`](../../../)

---

# Minus

Namespace: Albatross.Expression.Infix

Infix expression that performs arithmetic subtraction between two numeric operands.
 Uses the "-" operator with precedence 100.

```csharp
public class Minus : InfixExpression, Albatross.Expression.Nodes.IInfixExpression, Albatross.Expression.Nodes.IExpression, Albatross.Expression.Nodes.IToken, Albatross.Expression.Nodes.IHasPrecedence
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [InfixExpression](./albatross/expression/infix/infixexpression) → [Minus](./albatross/expression/infix/minus)<br>
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

### **Minus()**

Initializes a new instance of the Minus class with operator "-" and precedence 100.

```csharp
public Minus()
```

## Methods

### **Run(Object, Object)**

Performs subtraction by converting both operands to double and subtracting the right from the left.

```csharp
protected object Run(object left, object right)
```

#### Parameters

`left` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The left operand (minuend) to convert to double.

`right` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The right operand (subtrahend) to convert to double.

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The result of left minus right as a double.

#### Exceptions

[FormatException](https://docs.microsoft.com/en-us/dotnet/api/system.formatexception)<br>
Thrown when either operand cannot be converted to double.

---

[`< Back`](../../../)
