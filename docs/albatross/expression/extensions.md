[`< Back`](../../)

---

# Extensions

Namespace: Albatross.Expression

Provides extension methods for type conversion and object manipulation within the Expression framework.

```csharp
public static class Extensions
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Extensions](./albatross/expression/extensions)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute), [ExtensionAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.extensionattribute)

## Methods

### **ConvertToString(Object)**

Converts an object to its string representation, handling JsonElement and other types.

```csharp
public static string ConvertToString(object obj)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The object to convert to string.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
A string representation of the object, or an empty string if the object is null.

### **ConvertToBoolean(Object)**

Converts an object to a boolean value with support for various input types.

```csharp
public static bool ConvertToBoolean(object obj)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The object to convert to boolean.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
The boolean representation of the object.

#### Exceptions

[FormatException](https://docs.microsoft.com/en-us/dotnet/api/system.formatexception)<br>
Thrown when the object cannot be converted to boolean.

### **ConvertToDouble(Object)**

Converts an object to a double value with support for various numeric types.

```csharp
public static double ConvertToDouble(object obj)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The object to convert to double.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The double representation of the object.

#### Exceptions

[FormatException](https://docs.microsoft.com/en-us/dotnet/api/system.formatexception)<br>
Thrown when the object cannot be converted to double.

### **ConvertToDateTime(Object)**

Converts an object to a DateTime value with support for various date types.

```csharp
public static DateTime ConvertToDateTime(object obj)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The object to convert to DateTime.

#### Returns

[DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)<br>
The DateTime representation of the object.

#### Exceptions

[FormatException](https://docs.microsoft.com/en-us/dotnet/api/system.formatexception)<br>
Thrown when the object cannot be converted to DateTime.

### **ConvertToInt(Object)**

Converts an object to an integer value with rounding for double values.

```csharp
public static int ConvertToInt(object obj)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The object to convert to int.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The integer representation of the object.

#### Exceptions

[FormatException](https://docs.microsoft.com/en-us/dotnet/api/system.formatexception)<br>
Thrown when the object cannot be converted to int.

### **ConvertToJsonElement(Object)**

Converts an object to a JsonElement by parsing string content or returning existing JsonElement.

```csharp
public static JsonElement ConvertToJsonElement(object obj)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The object to convert to JsonElement.

#### Returns

JsonElement<br>
A JsonElement representation of the object.

#### Exceptions

[FormatException](https://docs.microsoft.com/en-us/dotnet/api/system.formatexception)<br>
Thrown when the object cannot be converted to JsonElement.

### **GetJsonValue(JsonElement)**

Extracts the underlying value from a JsonElement into appropriate .NET types.

```csharp
public static object GetJsonValue(JsonElement elem)
```

#### Parameters

`elem` JsonElement<br>
The JsonElement to extract value from.

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The underlying value as a .NET object, or null for null/undefined JSON values.

---

[`< Back`](../../)
