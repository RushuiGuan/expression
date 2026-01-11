# Introduction

Albatross.Expression is a powerful .NET library for parsing and evaluating text-based expressions. It tokenizes expression strings, creates tree models from tokens, and evaluates expressions or converts them to different formats. The library supports variables through ExecutionContext, enabling dynamic calculations with internal or external data sources.

**Key Features:**
- Expression parsing and evaluation for mathematical, logical, and string operations
- Rich built-in function library (math, string, date/time, arrays, regex)
- Variable support with ExecutionContext
- External data integration and async evaluation
- Support for .NET 8.0+

# Getting Started
## Installation

```bash
dotnet add package Albatross.Expression
```

## Basic Usage

The simplest way to use the parser is through the ParserBuilder:

```csharp
using Albatross.Expression.Parsing;

var parser = new ParserBuilder().BuildDefault();
var result = parser.Eval("1 + 5 * 2", null); // Returns: 11
```

## Working with Variables

Use DefaultExecutionContext to manage variables in expressions:

```csharp
using Albatross.Expression.Context;
using Albatross.Expression.Parsing;

var parser = new ParserBuilder().BuildDefault();
var context = new DefaultExecutionContext<object>(parser);

// Set variables using expressions
context.Set(new ExpressionContextValue<object>("a", "10", parser));
context.Set(new ExpressionContextValue<object>("b", "20", parser));
context.Set(new ExpressionContextValue<object>("sum", "a + b", parser));

// Evaluate expressions with variables
var result = context.GetValue("sum", new object()); // Returns: 30
```

## External Data Integration

Access external data sources during expression evaluation:

```csharp
var parser = new ParserBuilder().BuildDefault();
var context = new DefaultExecutionContext<Dictionary<string, object>>(parser);

// Set up expressions that reference external data
context.Set(new ExpressionContextValue<Dictionary<string, object>>("total", "price + tax", parser));
context.Set(new ExternalContextValue<Dictionary<string, object>>("price", dict => dict["price"]));
context.Set(new ExternalContextValue<Dictionary<string, object>>("tax", dict => dict["tax"]));

// Provide external data and evaluate
var data = new Dictionary<string, object> { 
    { "price", 100.0 }, 
    { "tax", 8.5 } 
};
var result = context.GetValue("total", data); // Returns: 108.5
```

## Asynchronous Operations

Support for async operations within expressions:

```csharp
var parser = new ParserBuilder().BuildDefault();
var context = new DefaultExecutionContext<object>(parser);

// Set up async external value
context.Set(new AsyncExternalContextValue<object>("api_data", async _ => await FetchDataAsync()));
context.Set(new ExpressionContextValue<object>("result", "upper(api_data)", parser));

// Evaluate asynchronously
var result = await context.GetValueAsync("result", new object());
```

# Supported Operations

The library supports three types of operations:

## Infix Operations
Binary operations between two operands:
- Arithmetic: `1 + 2`, `5 * 3`, `10 / 2`, `8 - 4`, `2 ^ 3`
- Comparison: `5 > 3`, `2 < 7`, `4 >= 4`, `6 <= 10`, `3 == 3`, `5 != 2`
- Logical: `true and false`, `true or false`
- Complex: `1 + 3 * 7 > 4 and 1 - 4 < 8`

## Prefix Operations
Function-style operations with parentheses:
- Conditional: `if(true, "Yes", "No")`
- Math functions: `max(1, 2, 3)`, `min(5, 10)`, `round(3.14159, 2)`
- String functions: `left("hello", 3)`, `upper("world")`, `concat("a", "b")`
- Date functions: `today()`, `now()`, `year(date)`
- Constants: `pi()`, `e()`

## Unary Operations
Single operand operations:
- Negative numbers: `-5`
- Positive numbers: `+10`
- Logical negation: `not true`

## Data Types
The library supports multiple data types:
- **Numeric**: All numbers are treated as `double` (e.g., `123`, `45.67`, `-89.1`)
- **String**: Text literals in quotes (e.g., `"hello"`, `'world'`)
- **Boolean**: Logical values (`true`, `false`)
- **Arrays**: Collections of values for array operations

For a complete list of built-in operations and functions, see the [operations reference](operations.md).