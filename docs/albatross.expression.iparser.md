# IParser

Namespace: Albatross.Expression

The interface contains functionalities to process an expression string.

```csharp
public interface IParser
```

Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute)

## Properties

### **CaseSensitive**

```csharp
public abstract bool CaseSensitive { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

## Methods

### **Tokenize(String)**

Parse a text expression from left to right and generate a token Queue

```csharp
Queue<IToken> Tokenize(string expression)
```

#### Parameters

`expression` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Queue&lt;IToken&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.queue-1)<br>

### **BuildPostfixStack(Queue&lt;IToken&gt;)**

Convert a token queue to stack

```csharp
Stack<IToken> BuildPostfixStack(Queue<IToken> queue)
```

#### Parameters

`queue` [Queue&lt;IToken&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.queue-1)<br>

#### Returns

Stack&lt;IToken&gt;<br>

### **CreateTree(Stack&lt;IToken&gt;)**

Using the token stack to build a token tree

```csharp
IExpression CreateTree(Stack<IToken> postfix)
```

#### Parameters

`postfix` Stack&lt;IToken&gt;<br>

#### Returns

[IExpression](./albatross.expression.nodes.iexpression.md)<br>
