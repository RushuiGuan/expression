# GreaterThan

Namespace: Albatross.Expression.Infix

Infix GreaterThan operation.

Operand Count: 2

1. - Operand1 : any
2. - Operand2 : any

Output Type: Boolean

Usage: 3 &gt; 2

Precedance: 50

```csharp
public class GreaterThan : ComparisonInfixOperation, Albatross.Expression.Nodes.IInfixExpression, Albatross.Expression.Nodes.IExpression, Albatross.Expression.Nodes.IToken, Albatross.Expression.Nodes.IHasPrecedence
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [InfixExpression](./albatross.expression.infix.infixexpression.md) → [ComparisonInfixOperation](./albatross.expression.infix.comparisoninfixoperation.md) → [GreaterThan](./albatross.expression.infix.greaterthan.md)<br>
Implements [IInfixExpression](./albatross.expression.nodes.iinfixexpression.md), [IExpression](./albatross.expression.nodes.iexpression.md), [IToken](./albatross.expression.nodes.itoken.md), [IHasPrecedence](./albatross.expression.nodes.ihasprecedence.md)

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

[IExpression](./albatross.expression.nodes.iexpression.md)<br>

### **Right**

The right operand of the infix operation.

```csharp
public IExpression Right { get; set; }
```

#### Property Value

[IExpression](./albatross.expression.nodes.iexpression.md)<br>

### **RequiredLeft**

Gets the required left operand, throwing an exception if it's null.

```csharp
public IExpression RequiredLeft { get; }
```

#### Property Value

[IExpression](./albatross.expression.nodes.iexpression.md)<br>

### **RequiredRight**

Gets the required right operand, throwing an exception if it's null.

```csharp
public IExpression RequiredRight { get; }
```

#### Property Value

[IExpression](./albatross.expression.nodes.iexpression.md)<br>

## Constructors

### **GreaterThan()**

```csharp
public GreaterThan()
```

## Methods

### **Interpret(Int32)**

```csharp
public bool Interpret(int comparisonResult)
```

#### Parameters

`comparisonResult` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
