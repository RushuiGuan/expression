# IHasPrecedence

Namespace: Albatross.Expression.Nodes

Interface for tokens that have operator precedence to determine order of evaluation.

```csharp
public interface IHasPrecedence
```

## Properties

### **Precedence**

The precedence level of this operation. Higher values indicate higher precedence.

```csharp
public abstract int Precedence { get; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
