[`< Back`](../../../)

---

# CircularReferenceException

Namespace: Albatross.Expression.Exceptions

Exception thrown when a circular reference is detected in variable dependencies.

```csharp
public class CircularReferenceException : System.Exception, System.Runtime.Serialization.ISerializable
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception) → [CircularReferenceException](./albatross/expression/exceptions/circularreferenceexception)<br>
Implements [ISerializable](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.iserializable)

## Properties

### **TargetSite**

```csharp
public MethodBase TargetSite { get; }
```

#### Property Value

[MethodBase](https://docs.microsoft.com/en-us/dotnet/api/system.reflection.methodbase)<br>

### **Message**

```csharp
public string Message { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Data**

```csharp
public IDictionary Data { get; }
```

#### Property Value

[IDictionary](https://docs.microsoft.com/en-us/dotnet/api/system.collections.idictionary)<br>

### **InnerException**

```csharp
public Exception InnerException { get; }
```

#### Property Value

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **HelpLink**

```csharp
public string HelpLink { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Source**

```csharp
public string Source { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **HResult**

```csharp
public int HResult { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **StackTrace**

```csharp
public string StackTrace { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Constructors

### **CircularReferenceException(String, String)**

Initializes a new instance of the [CircularReferenceException](./albatross/expression/exceptions/circularreferenceexception) class.

```csharp
public CircularReferenceException(string from, string to)
```

#### Parameters

`from` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The source variable that causes the circular reference.

`to` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The target variable that completes the circular reference.

## Events

### **SerializeObjectState**

#### Caution

BinaryFormatter serialization is obsolete and should not be used. See https://aka.ms/binaryformatter for more information.

---

```csharp
protected event EventHandler<SafeSerializationEventArgs> SerializeObjectState;
```

---

[`< Back`](../../../)
