[`< Back`](../../../)

---

# ParserBuilder

Namespace: Albatross.Expression.Parsing

Builder class for creating Parser instances with customizable token factories.
 Provides fluent interface for configuring different types of expression parsing capabilities.

```csharp
public class ParserBuilder
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ParserBuilder](./albatross/expression/parsing/parserbuilder)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **Factories**

Return a read-only list of the currently registered expression factories.

```csharp
public IReadOnlyList<IExpressionFactory<IToken>> Factories { get; }
```

#### Property Value

[IReadOnlyList&lt;IExpressionFactory&lt;IToken&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1)<br>

## Constructors

### **ParserBuilder()**

```csharp
public ParserBuilder()
```

## Methods

### **AddFactory(IExpressionFactory&lt;IToken&gt;)**

Adds a custom expression factory to the parser configuration.

```csharp
public ParserBuilder AddFactory(IExpressionFactory<IToken> factory)
```

#### Parameters

`factory` [IExpressionFactory&lt;IToken&gt;](./albatross/expression/parsing/iexpressionfactory-1)<br>
The factory to add for parsing specific token types.

#### Returns

[ParserBuilder](./albatross/expression/parsing/parserbuilder)<br>
This ParserBuilder instance for method chaining.

### **AddValueNodeFactories(Boolean)**

Adds standard value node factories (literals and variables) to the parser.

```csharp
public ParserBuilder AddValueNodeFactories(bool caseSensitive)
```

#### Parameters

`caseSensitive` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Whether parsing should be case-sensitive.

#### Returns

[ParserBuilder](./albatross/expression/parsing/parserbuilder)<br>
This ParserBuilder instance for method chaining.

### **AddInfixFactories(Boolean)**

Adds infix operation factories (binary operators like +, -, *, etc.) to the parser.

```csharp
public ParserBuilder AddInfixFactories(bool caseSensitive)
```

#### Parameters

`caseSensitive` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Whether parsing should be case-sensitive.

#### Returns

[ParserBuilder](./albatross/expression/parsing/parserbuilder)<br>
This ParserBuilder instance for method chaining.

### **AddUnaryFactories()**

Adds unary operation factories (unary operators like +x, -x) to the parser.

```csharp
public ParserBuilder AddUnaryFactories()
```

#### Returns

[ParserBuilder](./albatross/expression/parsing/parserbuilder)<br>
This ParserBuilder instance for method chaining.

### **AddGenericPrefixFactory(Boolean)**

Adds a comprehensive set of built-in prefix functions to the parser.

```csharp
public ParserBuilder AddGenericPrefixFactory(bool caseSensitive)
```

#### Parameters

`caseSensitive` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Whether parsing should be case-sensitive.

#### Returns

[ParserBuilder](./albatross/expression/parsing/parserbuilder)<br>
This ParserBuilder instance for method chaining.

### **AddNamedPrefixFactories(Boolean)**

Adds named prefix expression factories that require specific syntax.

```csharp
public ParserBuilder AddNamedPrefixFactories(bool caseSensitive)
```

#### Parameters

`caseSensitive` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Whether parsing should be case-sensitive.

#### Returns

[ParserBuilder](./albatross/expression/parsing/parserbuilder)<br>
This ParserBuilder instance for method chaining.

### **AddDefault(Boolean)**

Adds all standard expression parsing capabilities (values, infix, unary, and prefix operations).

```csharp
public ParserBuilder AddDefault(bool caseSensitive)
```

#### Parameters

`caseSensitive` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Whether parsing should be case-sensitive.

#### Returns

[ParserBuilder](./albatross/expression/parsing/parserbuilder)<br>
This ParserBuilder instance for method chaining.

### **BuildDefault(Boolean)**

Creates a Parser instance with all default parsing capabilities enabled.

```csharp
public Parser BuildDefault(bool caseSensitive)
```

#### Parameters

`caseSensitive` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Whether parsing should be case-sensitive.

#### Returns

[Parser](./albatross/expression/parsing/parser)<br>
A fully configured Parser instance.

---

[`< Back`](../../../)
