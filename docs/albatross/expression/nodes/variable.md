[`< Back`](../../../)

---

# Variable

Namespace: Albatross.Expression.Nodes

Represents a variable reference in an expression that gets resolved during evaluation.
 Variable names follow C# naming conventions and support dot notation for nested property access (e.g., "field.property").

```csharp
public class Variable : ValueToken, IValueToken, IToken, IExpression
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ValueToken](./albatross/expression/nodes/valuetoken) → [Variable](./albatross/expression/nodes/variable)<br>
Implements [IValueToken](./albatross/expression/nodes/ivaluetoken), [IToken](./albatross/expression/nodes/itoken), [IExpression](./albatross/expression/nodes/iexpression)

## Properties

### **Value**

The string value contained by this token.

```csharp
public string Value { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Token**

The token representation, which is the same as the Value for basic value tokens.

```csharp
public string Token { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Constructors

### **Variable(String)**

Initializes a new instance of the [Variable](./albatross/expression/nodes/variable) class.

```csharp
public Variable(string value)
```

#### Parameters

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The variable name.

## Methods

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

---

[`< Back`](../../../)
