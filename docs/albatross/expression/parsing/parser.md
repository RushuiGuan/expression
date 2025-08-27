[`< Back`](../../../)

---

# Parser

Namespace: Albatross.Expression.Parsing

An immutable implementation of the [IParser](./albatross/expression/iparser) interface.

```csharp
public class Parser : Albatross.Expression.IParser
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Parser](./albatross/expression/parsing/parser)<br>
Implements [IParser](./albatross/expression/iparser)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **CaseSensitive**

```csharp
public bool CaseSensitive { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

## Constructors

### **Parser(IEnumerable&lt;IExpressionFactory&lt;IToken&gt;&gt;, Boolean)**

```csharp
public Parser(IEnumerable<IExpressionFactory<IToken>> factories, bool caseSensitive)
```

#### Parameters

`factories` [IEnumerable&lt;IExpressionFactory&lt;IToken&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

`caseSensitive` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

## Methods

### **Tokenize(String)**

```csharp
public Queue<IToken> Tokenize(string expression)
```

#### Parameters

`expression` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Queue&lt;IToken&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.queue-1)<br>

### **BuildPostfixStack(Queue&lt;IToken&gt;)**

```csharp
public Stack<IToken> BuildPostfixStack(Queue<IToken> queue)
```

#### Parameters

`queue` [Queue&lt;IToken&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.queue-1)<br>

#### Returns

Stack&lt;IToken&gt;<br>

### **CreateTree(Stack&lt;IToken&gt;)**

```csharp
public IExpression CreateTree(Stack<IToken> postfix)
```

#### Parameters

`postfix` Stack&lt;IToken&gt;<br>

#### Returns

[IExpression](./albatross/expression/nodes/iexpression)<br>

---

[`< Back`](../../../)
