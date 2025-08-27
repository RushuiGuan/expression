[`< Back`](../../../)

---

# MySetup

Namespace: Albatross.Expression.Utility

Application setup class that configures dependency injection services for the Expression Utility.
 Registers command handlers, parsers, execution context, and configuration services.

```csharp
public class MySetup : Albatross.CommandLine.Setup
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → Setup → [MySetup](./albatross/expression/utility/mysetup)

## Properties

### **RootCommandDescription**

```csharp
protected string RootCommandDescription { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **RootCommand**

```csharp
public RootCommand RootCommand { get; }
```

#### Property Value

RootCommand<br>

### **CommandBuilder**

```csharp
public CommandLineBuilder CommandBuilder { get; }
```

#### Property Value

CommandLineBuilder<br>

## Constructors

### **MySetup()**

```csharp
public MySetup()
```

## Methods

### **RegisterServices(InvocationContext, IConfiguration, EnvironmentSetting, IServiceCollection)**

Configures the dependency injection container with application-specific services.
 Registers expression parser, custom execution context, configuration, and command handlers.

```csharp
public void RegisterServices(InvocationContext context, IConfiguration configuration, EnvironmentSetting envSetting, IServiceCollection services)
```

#### Parameters

`context` InvocationContext<br>
The invocation context from the command line.

`configuration` IConfiguration<br>
Application configuration instance.

`envSetting` EnvironmentSetting<br>
Environment-specific settings.

`services` IServiceCollection<br>
Service collection to register dependencies into.

---

[`< Back`](../../../)
