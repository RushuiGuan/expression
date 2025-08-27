# IExpressionFactory&lt;T&gt;

Namespace: Albatross.Expression.Parsing

Factory interface for parsing tokens from expression text.

```csharp
public interface IExpressionFactory<T>
```

#### Type Parameters

`T`<br>
The type of token this factory produces.

Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute)

## Methods

### **Parse(String, Int32, Int32&)**

Attempts to parse a token from the given text starting at the specified position.

```csharp
T Parse(string text, int start, Int32& next)
```

#### Parameters

`text` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The expression text to parse.

`start` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The starting position in the text to begin parsing.

`next` [Int32&](https://docs.microsoft.com/en-us/dotnet/api/system.int32&)<br>
When this method returns, contains the position after the parsed token, or the original start position if parsing failed.

#### Returns

T<br>
The parsed token if successful; otherwise, null.
