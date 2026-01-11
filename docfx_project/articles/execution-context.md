# Execution Context

The ExecutionContext is the cornerstone of dynamic expression evaluation in Albatross.Expression. While parsing and evaluating literal expressions is useful, the real power comes from using variables and external data sources within expressions. ExecutionContext enables the creation of user-defined formulas that can reference variables, making expressions truly dynamic and reusable.

## Overview

ExecutionContext transforms expressions from simple calculations into powerful formulas by:
- Managing variables that can be referenced in expressions
- Supporting different types of context values (expressions, external data, local values)
- Providing both synchronous and asynchronous evaluation
- Enabling dependency resolution between variables
- Supporting type-safe external data integration

## Core Concepts

### Context Values

There are several types of context values that can be stored in an ExecutionContext:

1. **ExpressionContextValue**: Variables defined by expressions that can reference other variables
2. **ExternalContextValue**: Variables that pull data from external objects
3. **LocalContextValue**: Variables with direct static values
4. **AsyncExternalContextValue**: Variables that asynchronously fetch external data

### DefaultExecutionContext

The `DefaultExecutionContext<T>` is the primary implementation that manages variable resolution and evaluation. The generic type `T` represents the data model your expressions will work with:

```csharp
using Albatross.Expression.Context;
using Albatross.Expression.Parsing;

public class Employee
{
    public string Name { get; set; }
    public double BaseSalary { get; set; }
    public int YearsOfService { get; set; }
    public string Department { get; set; }
    public bool IsManager { get; set; }
}

var parser = new ParserBuilder().BuildDefault();
var context = new DefaultExecutionContext<Employee>(parser);
```

## Basic Usage

### Setting Up Variables

#### Expression Variables
Variables defined by expressions that can reference other variables:

```csharp
var parser = new ParserBuilder().BuildDefault();
var context = new DefaultExecutionContext<Employee>(parser);

// Define salary calculation rules
context.Set(new ExternalContextValue<Employee>("base_salary", emp => emp.BaseSalary));
context.Set(new ExternalContextValue<Employee>("years_service", emp => emp.YearsOfService));
context.Set(new ExternalContextValue<Employee>("is_manager", emp => emp.IsManager));

// Define calculated variables using expressions
context.Set(new ExpressionContextValue<Employee>("seniority_bonus", "years_service * 1000", parser));
context.Set(new ExpressionContextValue<Employee>("management_bonus", "if(is_manager, base_salary * 0.15, 0)", parser));
context.Set(new ExpressionContextValue<Employee>("total_salary", "base_salary + seniority_bonus + management_bonus", parser));

// Evaluate for a specific employee
var employee = new Employee { BaseSalary = 50000, YearsOfService = 5, IsManager = true };
var totalSalary = context.GetValue("total_salary", employee); // Returns: 62500
```

#### Local Variables
Variables with direct values (constants or configuration):

```csharp
public class Product
{
    public double Price { get; set; }
    public double Radius { get; set; }
    public string Category { get; set; }
}

var parser = new ParserBuilder().BuildDefault();
var context = new DefaultExecutionContext<Product>(parser);

// Set configuration constants
context.Set(new LocalContextValue<Product>("pi", 3.14159));
context.Set(new LocalContextValue<Product>("tax_rate", 0.08));
context.Set(new LocalContextValue<Product>("shipping_rate", 15.0));

// Use external product data
context.Set(new ExternalContextValue<Product>("price", p => p.Price));
context.Set(new ExternalContextValue<Product>("radius", p => p.Radius));

// Calculate derived values
context.Set(new ExpressionContextValue<Product>("circumference", "pi * 2 * radius", parser));
context.Set(new ExpressionContextValue<Product>("total_cost", "price * (1 + tax_rate) + shipping_rate", parser));

var product = new Product { Price = 100, Radius = 5 };
var cost = context.GetValue("total_cost", product); // Returns: 123
```

### External Data Integration

#### Synchronous External Values
Access properties or data from external objects:

```csharp
var parser = new ParserBuilder().BuildDefault();
var context = new DefaultExecutionContext<Dictionary<string, object>>(parser);

// Set up expressions that reference external data
context.Set(new ExpressionContextValue<Dictionary<string, object>>("total", "price + tax + shipping", parser));
context.Set(new ExternalContextValue<Dictionary<string, object>>("price", dict => dict["price"]));
context.Set(new ExternalContextValue<Dictionary<string, object>>("tax", dict => (double)dict["price"] * 0.085));
context.Set(new ExternalContextValue<Dictionary<string, object>>("shipping", dict => dict["shipping"]));

// Provide external data
var orderData = new Dictionary<string, object> {
    { "price", 100.0 },
    { "shipping", 15.0 }
};

var total = context.GetValue("total", orderData); // Returns: 123.5
```

#### Complex External Data Example
Working with custom objects:

```csharp
public class Order
{
    public double Price { get; set; }
    public double DiscountPercent { get; set; }
    public bool IsPremiumCustomer { get; set; }
    public string Region { get; set; }
}

var parser = new ParserBuilder().BuildDefault();
var context = new DefaultExecutionContext<Order>(parser);

// Define business rules as expressions
context.Set(new ExternalContextValue<Order>("base_price", order => order.Price));
context.Set(new ExternalContextValue<Order>("discount_rate", order => order.DiscountPercent / 100));
context.Set(new ExternalContextValue<Order>("is_premium", order => order.IsPremiumCustomer));
context.Set(new ExternalContextValue<Order>("region", order => order.Region));

// Complex pricing formula
context.Set(new ExpressionContextValue<Order>("discount_amount", "base_price * discount_rate", parser));
context.Set(new ExpressionContextValue<Order>("premium_bonus", "if(is_premium, base_price * 0.05, 0)", parser));
context.Set(new ExpressionContextValue<Order>("regional_tax", "if(region == 'CA', base_price * 0.08, base_price * 0.06)", parser));
context.Set(new ExpressionContextValue<Order>("final_price", "base_price - discount_amount - premium_bonus + regional_tax", parser));

var order = new Order 
{ 
    Price = 200.0, 
    DiscountPercent = 10, 
    IsPremiumCustomer = true, 
    Region = "CA" 
};

var finalPrice = context.GetValue("final_price", order); // Calculated based on all rules
```

## Asynchronous Operations

### Async External Values
For data that needs to be fetched asynchronously:

```csharp
public class UserAccount
{
    public string UserId { get; set; }
    public string Currency { get; set; }
    public string AccountType { get; set; }
}

var parser = new ParserBuilder().BuildDefault();
var context = new DefaultExecutionContext<UserAccount>(parser);

// Set up async external values
context.Set(new AsyncExternalContextValue<UserAccount>("exchange_rate", async account => 
    await FetchExchangeRateAsync(account.Currency)));
context.Set(new AsyncExternalContextValue<UserAccount>("current_balance", async account => 
    await GetUserBalanceAsync(account.UserId)));
context.Set(new AsyncExternalContextValue<UserAccount>("credit_limit", async account => 
    await GetCreditLimitAsync(account.UserId, account.AccountType)));

// Expression that uses async values
context.Set(new ExpressionContextValue<UserAccount>("balance_usd", "current_balance * exchange_rate", parser));
context.Set(new ExpressionContextValue<UserAccount>("available_credit", "credit_limit - current_balance", parser));

// Evaluate asynchronously
var account = new UserAccount { UserId = "user123", Currency = "EUR", AccountType = "Premium" };
var balanceInUsd = await context.GetValueAsync("balance_usd", account);
```

## Advanced Features

### Error Handling

```csharp
try 
{
    var result = context.GetValue("undefined_variable", data);
}
catch (MissingVariableException ex)
{
    Console.WriteLine($"Variable '{ex.VariableName}' is not defined");
}
catch (CircularReferenceException ex)
{
    Console.WriteLine($"Circular reference detected: {ex.Message}");
}
```

## Best Practices

### 1. Use Appropriate Context Value Types
- Use `ExpressionContextValue` for calculated fields that depend on other variables
- Use `ExternalContextValue` for data that comes from external objects
- Use `LocalContextValue` for constants or configuration values
- Use `AsyncExternalContextValue` for data that requires async operations

### 2. Organize Variable Dependencies
```csharp
public class OrderLine
{
    public double UnitPrice { get; set; }
    public int Quantity { get; set; }
    public string ProductCategory { get; set; }
    public bool IsDiscountEligible { get; set; }
}

// Group related variables logically
// Base data from external object
context.Set(new ExternalContextValue<OrderLine>("unit_price", o => o.UnitPrice));
context.Set(new ExternalContextValue<OrderLine>("quantity", o => o.Quantity));
context.Set(new ExternalContextValue<OrderLine>("category", o => o.ProductCategory));
context.Set(new ExternalContextValue<OrderLine>("discount_eligible", o => o.IsDiscountEligible));

// Configuration constants
context.Set(new LocalContextValue<OrderLine>("tax_rate", 0.08));
context.Set(new LocalContextValue<OrderLine>("electronics_discount", 0.10));

// Calculated values with dependencies
context.Set(new ExpressionContextValue<OrderLine>("subtotal", "unit_price * quantity", parser));
context.Set(new ExpressionContextValue<OrderLine>("discount", "if(discount_eligible and category == 'Electronics', subtotal * electronics_discount, 0)", parser));
context.Set(new ExpressionContextValue<OrderLine>("discounted_subtotal", "subtotal - discount", parser));
context.Set(new ExpressionContextValue<OrderLine>("tax", "discounted_subtotal * tax_rate", parser));
context.Set(new ExpressionContextValue<OrderLine>("total", "discounted_subtotal + tax", parser));
```

### 3. Handle Async Operations Consistently
```csharp
public class Account
{
    public string AccountId { get; set; }
    public string AccountType { get; set; }
}

// Always use async methods when any context value is async
var context = new DefaultExecutionContext<Account>(parser);

// Check if context has async values before deciding evaluation method
if (context.HasAsyncValues)
{
    var result = await context.GetValueAsync("risk_score", account);
}
else
{
    var result = context.GetValue("risk_score", account);
}
```

### 4. Validate Expressions Early
```csharp
public class Configuration
{
    public string RuleName { get; set; }
    public string Formula { get; set; }
}

try 
{
    // Validate business rule expressions during setup
    var config = new Configuration { RuleName = "pricing_rule", Formula = "base_price * markup_rate" };
    context.Set(new ExpressionContextValue<Configuration>("calculated_price", config.Formula, parser));
}
catch (TokenParsingException ex)
{
    Console.WriteLine($"Invalid formula in rule '{config.RuleName}': {ex.Message}");
}
```
