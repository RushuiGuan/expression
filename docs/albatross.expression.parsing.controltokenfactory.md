# ControlTokenFactory

Namespace: Albatross.Expression.Parsing

Factory for creating control tokens used in expression parsing (parentheses, commas, etc.).

```csharp
public class ControlTokenFactory : IExpressionFactory`1
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ControlTokenFactory](./albatross.expression.parsing.controltokenfactory.md)<br>
Implements [IExpressionFactory&lt;ControlToken&gt;](./albatross.expression.parsing.iexpressionfactory-1.md)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Fields

### **LeftParenthesis**

Singleton factory instance for left parenthesis tokens.

```csharp
public static ControlTokenFactory LeftParenthesis;
```

### **RightParenthesis**

Singleton factory instance for right parenthesis tokens.

```csharp
public static ControlTokenFactory RightParenthesis;
```

### **Comma**

Singleton factory instance for comma tokens.

```csharp
public static ControlTokenFactory Comma;
```

### **FuncParamStart**

Singleton factory instance for function parameter start tokens.

```csharp
public static ControlTokenFactory FuncParamStart;
```

### **LeftParenthesisChar**

Character constant for left parenthesis.

```csharp
public static char LeftParenthesisChar;
```

### **RightParenthesisChar**

Character constant for right parenthesis.

```csharp
public static char RightParenthesisChar;
```

### **CommaChar**

Character constant for comma separator.

```csharp
public static char CommaChar;
```

### **FuncParamStartChar**

Special character marking the beginning of function parameters in the parsing process.

```csharp
public static char FuncParamStartChar;
```

## Properties

### **TokenText**

The string representation of the token character.

```csharp
public string TokenText { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Token**

The control token instance created by this factory.

```csharp
public ControlToken Token { get; }
```

#### Property Value

[ControlToken](./albatross.expression.nodes.controltoken.md)<br>

## Constructors

### **ControlTokenFactory(Char)**

Initializes a new instance of the [ControlTokenFactory](./albatross.expression.parsing.controltokenfactory.md) class.

```csharp
public ControlTokenFactory(char tokenChar)
```

#### Parameters

`tokenChar` [Char](https://docs.microsoft.com/en-us/dotnet/api/system.char)<br>
The character this factory will recognize and create tokens for.

## Methods

### **Parse(String, Int32, Int32&)**

```csharp
public ControlToken Parse(string text, int start, Int32& next)
```

#### Parameters

`text` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`start` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`next` [Int32&](https://docs.microsoft.com/en-us/dotnet/api/system.int32&)<br>

#### Returns

[ControlToken](./albatross.expression.nodes.controltoken.md)<br>
