# Minus

Namespace: Albatross.Expression.Infix

```csharp
public class Minus : InfixExpression, Albatross.Expression.Nodes.IInfixExpression, Albatross.Expression.Nodes.IExpression, Albatross.Expression.Nodes.IToken, Albatross.Expression.Nodes.IHasPrecedence
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [InfixExpression](./albatross.expression.infix.infixexpression.md) → [Minus](./albatross.expression.infix.minus.md)<br>
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

### **Minus()**

```csharp
public Minus()
```

## Methods

### **Run(Object, Object)**

```csharp
protected object Run(object left, object right)
```

#### Parameters

`left` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`right` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
