# VariableFactory

Namespace: Albatross.Expression.Parsing

Factory for parsing variable name tokens from expression text.

```csharp
public class VariableFactory : IExpressionFactory`1
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [VariableFactory](./albatross.expression.parsing.variablefactory.md)<br>
Implements [IExpressionFactory&lt;Variable&gt;](./albatross.expression.parsing.iexpressionfactory-1.md)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Fields

### **VariableNameRegex**

Compiled regex pattern for matching variable names (supports dot notation like "obj.prop").

```csharp
public static Regex VariableNameRegex;
```

## Constructors

### **VariableFactory()**

```csharp
public VariableFactory()
```

## Methods

### **Parse(String, Int32, Int32&)**

```csharp
public Variable Parse(string expression, int start, Int32& next)
```

#### Parameters

`expression` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`start` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`next` [Int32&](https://docs.microsoft.com/en-us/dotnet/api/system.int32&)<br>

#### Returns

[Variable](./albatross.expression.nodes.variable.md)<br>
