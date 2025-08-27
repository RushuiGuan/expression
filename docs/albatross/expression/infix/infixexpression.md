[`< Back`](../../../)

---

# InfixExpression

Namespace: Albatross.Expression.Infix

Base implementation for infix binary operation expressions.

```csharp
public class InfixExpression : Albatross.Expression.Nodes.IInfixExpression, Albatross.Expression.Nodes.IExpression, Albatross.Expression.Nodes.IToken, Albatross.Expression.Nodes.IHasPrecedence
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [InfixExpression](./albatross/expression/infix/infixexpression)<br>
Implements [IInfixExpression](./albatross/expression/nodes/iinfixexpression), [IExpression](./albatross/expression/nodes/iexpression), [IToken](./albatross/expression/nodes/itoken), [IHasPrecedence](./albatross/expression/nodes/ihasprecedence)<br>
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

### **InfixExpression(String, Int32)**

Initializes a new instance of the [InfixExpression](./albatross/expression/infix/infixexpression) class.

```csharp
public InfixExpression(string operatorText, int precedence)
```

#### Parameters

`operatorText` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
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

### **Run(Object, Object)**

```csharp
protected object Run(object left, object right)
```

#### Parameters

`left` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`right` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

---

[`< Back`](../../../)
