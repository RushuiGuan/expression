[`< Back`](../../../)

---

# ExpressionContextValue&lt;T&gt;

Namespace: Albatross.Expression.Context

Context value that represents a variable defined by an expression.
 Parses the expression into an abstract syntax tree and evaluates it dynamically when requested.

```csharp
public class ExpressionContextValue<T> : IContextValue`1
```

#### Type Parameters

`T`<br>
The type of the root context object.

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ExpressionContextValue&lt;T&gt;](./albatross/expression/context/expressioncontextvalue-1)<br>
Implements IContextValue&lt;T&gt;<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **Name**

Gets the name of this context value.

```csharp
public string Name { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Expression**

Gets the original expression string used to create this context value.

```csharp
public string Expression { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Tree**

Gets the parsed expression tree ready for evaluation.

```csharp
public IExpression Tree { get; }
```

#### Property Value

[IExpression](./albatross/expression/nodes/iexpression)<br>

### **Dependees**

Gets the set of variable names that this expression depends on.
 Used for dependency tracking and circular reference detection.

```csharp
public ISet<string> Dependees { get; }
```

#### Property Value

[ISet&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.iset-1)<br>

## Constructors

### **ExpressionContextValue(String, String, IParser)**

Initializes a new instance of the ExpressionContextValue class.
 Parses the expression, identifies variable dependencies, and builds the evaluation tree.

```csharp
public ExpressionContextValue(string name, string expression, IParser parser)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of this context value.

`expression` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The expression string to parse and evaluate.

`parser` [IParser](./albatross/expression/iparser)<br>
The parser to use for tokenizing and building the expression tree.

## Methods

### **GetValue(T, Func&lt;String, T, Object&gt;)**

Evaluates the expression tree to get the current value.
 Uses the provided function to resolve variable references during evaluation.

```csharp
public object GetValue(T input, Func<string, T, object> func)
```

#### Parameters

`input` T<br>
The root context object.

`func` Func&lt;String, T, Object&gt;<br>
Function to resolve variable values during evaluation.

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The result of evaluating the expression.

### **GetValueAsync(T, Func&lt;String, T, Task&lt;Object&gt;&gt;)**

Asynchronously evaluates the expression tree to get the current value.
 Uses the provided async function to resolve variable references during evaluation.

```csharp
public Task<object> GetValueAsync(T input, Func<string, T, Task<object>> func)
```

#### Parameters

`input` T<br>
The root context object.

`func` Func&lt;String, T, Task&lt;Object&gt;&gt;<br>
Async function to resolve variable values during evaluation.

#### Returns

[Task&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task representing the asynchronous evaluation operation.

---

[`< Back`](../../../)
