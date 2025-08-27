[`< Back`](../../../)

---

# StringLiteral

Namespace: Albatross.Expression.Nodes

Represents a string literal enclosed by quotes with support for escape sequences.

```csharp
public class StringLiteral : ValueToken, IValueToken, IToken, IStringLiteral, IExpression
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ValueToken](./albatross/expression/nodes/valuetoken) → [StringLiteral](./albatross/expression/nodes/stringliteral)<br>
Implements [IValueToken](./albatross/expression/nodes/ivaluetoken), [IToken](./albatross/expression/nodes/itoken), [IStringLiteral](./albatross/expression/nodes/istringliteral), [IExpression](./albatross/expression/nodes/iexpression)

## Fields

### **EscapeChar**

The character used to escape special characters within the string literal.

```csharp
public static char EscapeChar;
```

## Properties

### **Boundary**

The boundary character (quote type) that delimits this string literal.

```csharp
public char Boundary { get; }
```

#### Property Value

[Char](https://docs.microsoft.com/en-us/dotnet/api/system.char)<br>

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

### **StringLiteral(Char, String)**

Initializes a new instance of the [StringLiteral](./albatross/expression/nodes/stringliteral) class.

```csharp
public StringLiteral(char boundary, string value)
```

#### Parameters

`boundary` [Char](https://docs.microsoft.com/en-us/dotnet/api/system.char)<br>
The boundary character used to delimit the string.

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The raw string value including boundary characters.

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
