# Albatross.Expression

A powerful .NET expression parsing and evaluation library that processes and evaluates text-based expression strings. The library tokenizes expression text, creates a tree model from the tokens, and can evaluate expressions or convert them to different formats. It includes a comprehensive ExecutionContext class that allows evaluation of expressions with variables that can be read internally or directly from external objects.

## Features

- **Expression Parsing**: Tokenize and parse complex mathematical and logical expressions
- **Multiple Operation Types**: Support for infix, prefix, and unary operations
- **Variable Support**: Evaluate expressions with variables using ExecutionContext
- **External Data Integration**: Access external data sources during expression evaluation  
- **Asynchronous Evaluation**: Support for async operations within expressions
- **Type Conversion**: Built-in support for string, boolean, and numeric literals
- **Rich Function Library**: Comprehensive set of built-in functions including:
  - Mathematical operations (Add, Subtract, Multiply, Divide, Power, Floor, Round, etc.)
  - String operations (Concat, Left, Right, Upper, Lower, PadLeft, PadRight, etc.)
  - Date/Time operations (Now, Today, Year, Month, DayOfWeek, etc.)
  - Logical operations (And, Or, Not, comparison operators)
  - Array operations (Array creation, GetJsonArrayItem)
  - Regex operations (RegexCapture)
  - Utility functions (Format, If, Random, etc.)
- **Command Line Utility**: CLI tool for expression evaluation and variable management

## Prerequisites

- .NET 8.0 SDK or later
- C# 12.0 language features support

## Installation

### NuGet Package

Install the main library via NuGet Package Manager:

```bash
dotnet add package Albatross.Expression
```

Or via Package Manager Console:

```powershell
Install-Package Albatross.Expression
```

### CLI Tool

Install the command-line utility globally:

```bash
dotnet tool install -g Albatross.Expression.Utility
```

### Build from Source

```bash
git clone https://github.com/RushuiGuan/expression.git
cd expression
dotnet restore
dotnet build
```

## Usage Examples

### Basic Expression Evaluation

```csharp
using Albatross.Expression.Parsing;

// Create parser instance
var parser = new ParserBuilder().BuildDefault();

// Evaluate simple expressions
var result1 = parser.Eval("1 + 5", null); // Returns: 6
var result2 = parser.Eval("10 * (2 + 3)", null); // Returns: 50
var result3 = parser.Eval("upper('hello world')", null); // Returns: "HELLO WORLD"
```

### Using ExecutionContext with Variables

```csharp
using Albatross.Expression.Context;
using Albatross.Expression.Parsing;

var parser = new ParserBuilder().BuildDefault();
var context = new DefaultExecutionContext<object>(parser);

// Set variables
context.Set(new ExpressionContextValue<object>("a", "10", parser));
context.Set(new ExpressionContextValue<object>("b", "20", parser)); 
context.Set(new ExpressionContextValue<object>("sum", "a + b", parser));

// Evaluate expression with variables
var result = context.GetValue("sum", new object()); // Returns: 30
```

### External Data Integration

```csharp
var parser = new ParserBuilder().BuildDefault();
var context = new DefaultExecutionContext<Dictionary<string, object>>(parser);

// Set up expression that references external data
context.Set(new ExpressionContextValue<Dictionary<string, object>>("total", "price + tax", parser));
context.Set(new ExternalContextValue<Dictionary<string, object>>("price", dict => dict["price"]));
context.Set(new ExternalContextValue<Dictionary<string, object>>("tax", dict => dict["tax"]));

// Provide external data
var data = new Dictionary<string, object> { { "price", 100.0 }, { "tax", 8.5 } };
var result = context.GetValue("total", data); // Returns: 108.5
```

### Asynchronous Operations

```csharp
var parser = new ParserBuilder().BuildDefault();
var context = new DefaultExecutionContext<object>(parser);

// Set up async external value
context.Set(new AsyncExternalContextValue<object>("api_data", async _ => await FetchDataAsync()));
context.Set(new ExpressionContextValue<object>("result", "upper(api_data)", parser));

// Evaluate asynchronously
var result = await context.GetValueAsync("result", new object());
```

### Command Line Usage

After installing the CLI tool:

```bash
# Evaluate expressions
ex eval "2 + 3 * 4"

# Set variables
ex set -n myvar "10 + 5" 

# List all variables
ex list

# Evaluate with variables
ex eval "myvar * 2"
```

## Project Structure

```
src/
├── Albatross.Expression/              # Main expression library
│   ├── Context/                       # ExecutionContext implementations
│   ├── Exceptions/                    # Custom exception classes
│   ├── Infix/                        # Infix operations (+, -, *, /, etc.)
│   ├── Nodes/                        # Expression tree node types
│   ├── Parsing/                      # Core parsing logic
│   ├── Prefix/                       # Prefix functions (if, max, concat, etc.)
│   └── Unary/                        # Unary operations (-, +)
├── Albatross.Expression.Test/         # Unit tests
└── Albatross.Expression.Utility/      # CLI utility tool
docfx_project/                         # Documentation source
docs/                                  # Generated documentation
```

## Running Tests

To run the unit tests:

```bash
# Run all tests
dotnet test

# Run tests with detailed output
dotnet test --logger "console;verbosity=detailed"

# Run specific test project
dotnet test src/Albatross.Expression.Test/
```

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add or update tests as needed
5. Ensure all tests pass
6. Submit a pull request

## Documentation

For detailed documentation, visit: https://rushuiguan.github.io/expression/

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

Copyright (c) 2019 Rushui Guan
