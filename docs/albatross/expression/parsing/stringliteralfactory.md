[`< Back`](../../../)

---

# StringLiteralFactory

Namespace: Albatross.Expression.Parsing

Factory for parsing string literal tokens with support for different quote characters.

```csharp
public class StringLiteralFactory : IExpressionFactory`1
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [StringLiteralFactory](./albatross/expression/parsing/stringliteralfactory)<br>
Implements [IExpressionFactory&lt;StringLiteral&gt;](./albatross/expression/parsing/iexpressionfactory-1)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Fields

### **DoubleQuote**

Singleton factory instance for double-quoted string literals.

```csharp
public static StringLiteralFactory DoubleQuote;
```

### **SingleQuote**

Singleton factory instance for single-quoted string literals.

```csharp
public static StringLiteralFactory SingleQuote;
```

## Constructors

### **StringLiteralFactory(Char)**

Initializes a new instance of the [StringLiteralFactory](./albatross/expression/parsing/stringliteralfactory) class.

```csharp
public StringLiteralFactory(char boundary)
```

#### Parameters

`boundary` [Char](https://docs.microsoft.com/en-us/dotnet/api/system.char)<br>
The quote character used to delimit string literals.

## Methods

### **Parse(String, Int32, Int32&)**

```csharp
public StringLiteral Parse(string text, int start, Int32& next)
```

#### Parameters

`text` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`start` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`next` [Int32&](https://docs.microsoft.com/en-us/dotnet/api/system.int32&)<br>

#### Returns

[StringLiteral](./albatross/expression/nodes/stringliteral)<br>

---

[`< Back`](../../../)
