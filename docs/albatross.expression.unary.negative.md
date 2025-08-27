# Negative

Namespace: Albatross.Expression.Unary

Represents the unary negation operator that converts positive numbers to negative and vice versa.

```csharp
public class Negative : UnaryExpression, Albatross.Expression.Nodes.IUnaryExpression, Albatross.Expression.Nodes.IExpression, Albatross.Expression.Nodes.IToken, Albatross.Expression.Nodes.IHasPrecedence
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [UnaryExpression](./albatross.expression.unary.unaryexpression.md) → [Negative](./albatross.expression.unary.negative.md)<br>
Implements [IUnaryExpression](./albatross.expression.nodes.iunaryexpression.md), [IExpression](./albatross.expression.nodes.iexpression.md), [IToken](./albatross.expression.nodes.itoken.md), [IHasPrecedence](./albatross.expression.nodes.ihasprecedence.md)

## Properties

### **Precedence**

The precedence level of this operation for proper evaluation order.

```csharp
public int Precedence { get; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **Operator**

The operator symbol for this unary operation.

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

### **Operand**

The operand that this unary operation applies to.

```csharp
public IExpression Operand { get; set; }
```

#### Property Value

[IExpression](./albatross.expression.nodes.iexpression.md)<br>

### **RequiredOperand**

Gets the required operand, throwing an exception if it's null.

```csharp
public IExpression RequiredOperand { get; }
```

#### Property Value

[IExpression](./albatross.expression.nodes.iexpression.md)<br>

## Constructors

### **Negative()**

Initializes a new instance of the [Negative](./albatross.expression.unary.negative.md) class.

```csharp
public Negative()
```

## Methods

### **Run(Object)**

```csharp
protected object Run(object operand)
```

#### Parameters

`operand` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
