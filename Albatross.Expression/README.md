# Albatross.Expression
A .NET library for parsing and evaluating text-based expressions with support for variables, external data sources, and asynchronous operations.

## Features

- Parse and evaluate mathematical, logical, and string expressions
- Rich built-in function library (math, string, date/time, arrays, regex)
- Variable support with ExecutionContext
- External data integration and async evaluation
- Supports .NET 8.0+

## Installation

```bash
dotnet add package Albatross.Expression
```

## Quick Start

```csharp
using Albatross.Expression.Parsing;

var parser = new ParserBuilder().BuildDefault();

// Basic evaluation
var result = parser.Eval("1 + 5 * 2", null); // Returns: 11

// With variables
var context = new DefaultExecutionContext<object>(parser);
context.Set(new ExpressionContextValue<object>("x", "10", parser));
var result2 = parser.Eval("x * 2", context); // Returns: 20

// Built-in functions
var result3 = parser.Eval("upper('hello')", null); // Returns: "HELLO"
```

## CLI Tool
Install globally for command-line usage:

```bash
dotnet tool install -g Albatross.Expression.Utility
ex eval "2 + 3 * 4"  # Returns: 14
```

## Documentation

- [API Reference](https://rushuiguan.github.io/expression/)
- [Source Code](https://github.com/RushuiGuan/expression)

## License

MIT License - Copyright (c) 2017 Rushui Guan
