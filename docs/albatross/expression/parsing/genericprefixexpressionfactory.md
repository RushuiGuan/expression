[`< Back`](../../../)

---

# GenericPrefixExpressionFactory

Namespace: Albatross.Expression.Parsing

Factory for parsing generic prefix expressions by name lookup from a registered collection.

```csharp
public class GenericPrefixExpressionFactory : IExpressionFactory`1
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [GenericPrefixExpressionFactory](./albatross/expression/parsing/genericprefixexpressionfactory)<br>
Implements [IExpressionFactory&lt;IPrefixExpression&gt;](./albatross/expression/parsing/iexpressionfactory-1)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **RegisteredExpressions**

Gets the collection of registered prefix expressions by name.

```csharp
public IReadOnlyDictionary<string, IPrefixExpression> RegisteredExpressions { get; }
```

#### Property Value

[IReadOnlyDictionary&lt;String, IPrefixExpression&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2)<br>

## Constructors

### **GenericPrefixExpressionFactory(Boolean)**

Initializes a new instance of the [GenericPrefixExpressionFactory](./albatross/expression/parsing/genericprefixexpressionfactory) class.

```csharp
public GenericPrefixExpressionFactory(bool caseSensitive)
```

#### Parameters

`caseSensitive` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Whether prefix expression names should be matched case-sensitively.

## Methods

### **Add&lt;T&gt;(T)**

Adds a prefix expression to the factory's registered collection.

```csharp
public void Add<T>(T t)
```

#### Type Parameters

`T`<br>
The type of prefix expression to add.

#### Parameters

`t` T<br>
The prefix expression instance to register.

### **Parse(String, Int32, Int32&)**

```csharp
public IPrefixExpression Parse(string text, int start, Int32& next)
```

#### Parameters

`text` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`start` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`next` [Int32&](https://docs.microsoft.com/en-us/dotnet/api/system.int32&)<br>

#### Returns

[IPrefixExpression](./albatross/expression/nodes/iprefixexpression)<br>

---

[`< Back`](../../../)
