# UnaryExpression

Namespace: Albatross.Expression.Unary

Base implementation for unary operation expressions that operate on a single operand.

```csharp
public class UnaryExpression : Albatross.Expression.Nodes.IUnaryExpression, Albatross.Expression.Nodes.IExpression, Albatross.Expression.Nodes.IToken, Albatross.Expression.Nodes.IHasPrecedence
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [UnaryExpression](./albatross.expression.unary.unaryexpression.md)<br>
Implements [IUnaryExpression](./albatross.expression.nodes.iunaryexpression.md), [IExpression](./albatross.expression.nodes.iexpression.md), [IToken](./albatross.expression.nodes.itoken.md), [IHasPrecedence](./albatross.expression.nodes.ihasprecedence.md)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

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

### **UnaryExpression(String, Int32)**

Initializes a new instance of the [UnaryExpression](./albatross.expression.unary.unaryexpression.md) class.

```csharp
public UnaryExpression(string operatorOperator, int precedence)
```

#### Parameters

`operatorOperator` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The operator symbol.

`precedence` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The precedence level for this operation.

## Methods

### **Text()**

```csharp
public string Text()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Eval(Func&lt;String, Object&gt;)**

```csharp
public object Eval(Func<string, object> context)
```

#### Parameters

`context` [Func&lt;String, Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **EvalAsync(Func&lt;String, Task&lt;Object&gt;&gt;)**

```csharp
public Task<object> EvalAsync(Func<string, Task<object>> context)
```

#### Parameters

`context` [Func&lt;String, Task&lt;Object&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>

#### Returns

[Task&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **Run(Object)**

```csharp
protected object Run(object operand)
```

#### Parameters

`operand` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
