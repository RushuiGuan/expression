[`< Back`](../../../)

---

# ExpressionConfig

Namespace: Albatross.Expression.Utility

Configuration class for the Expression Utility application that provides application-specific settings and directory paths.

```csharp
public class ExpressionConfig : Albatross.Config.ConfigBase
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ConfigBase → [ExpressionConfig](./albatross/expression/utility/expressionconfig)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **AppDirectory**

Gets the application directory path where variables and data files are stored.
 Located in the user's local application data directory under "Albatross.Expression.Utility".

```csharp
public string AppDirectory { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Constructors

### **ExpressionConfig(IConfiguration)**

Initializes a new instance of the ExpressionConfig class.

```csharp
public ExpressionConfig(IConfiguration configuration)
```

#### Parameters

`configuration` IConfiguration<br>
The configuration instance to use for reading settings.

---

[`< Back`](../../../)
