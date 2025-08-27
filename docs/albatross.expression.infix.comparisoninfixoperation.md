# ComparisonInfixOperation

Namespace: Albatross.Expression.Infix

Base class for infix operations that perform comparison between two operands of the same type.

```csharp
public abstract class ComparisonInfixOperation : InfixExpression, Albatross.Expression.Nodes.IInfixExpression, Albatross.Expression.Nodes.IExpression, Albatross.Expression.Nodes.IToken, Albatross.Expression.Nodes.IHasPrecedence
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [InfixExpression](./albatross.expression.infix.infixexpression.md) → [ComparisonInfixOperation](./albatross.expression.infix.comparisoninfixoperation.md)<br>
Implements [IInfixExpression](./albatross.expression.nodes.iinfixexpression.md), [IExpression](./albatross.expression.nodes.iexpression.md), [IToken](./albatross.expression.nodes.itoken.md), [IHasPrecedence](./albatross.expression.nodes.ihasprecedence.md)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

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

### **ComparisonInfixOperation(String, Int32)**

Initializes a new instance of the [ComparisonInfixOperation](./albatross.expression.infix.comparisoninfixoperation.md) class.

```csharp
protected ComparisonInfixOperation(string operatorSymbol, int precedence)
```

#### Parameters

`operatorSymbol` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The operator symbol for this comparison.

`precedence` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The precedence level for this operation.

## Methods

### **Interpret(Int32)**

Interprets the result of the comparison operation.

```csharp
public abstract bool Interpret(int comparisonResult)
```

#### Parameters

`comparisonResult` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The result from the comparison (-1, 0, or 1).

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
True if the comparison satisfies the operation's condition; otherwise, false.

### **Run(Object, Object)**

```csharp
protected object Run(object left, object right)
```

#### Parameters

`left` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`right` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
