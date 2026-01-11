# Parser

The @Albatross.Expression.Parsing.Parser class is the core component that processes, evaluates, and generates expressions. It implements the @Albatross.Expression.Parsing.IParser interface and transforms text-based expressions into executable code.

## Overview

The Parser provides comprehensive expression processing capabilities including:
- **Tokenization**: Breaking down expression text into individual tokens
- **Tree Building**: Creating an abstract syntax tree (AST) from tokens
- **Evaluation**: Computing expression results with optional variables
- **Regeneration**: Converting expressions back to text format

## Getting Started

### Basic Usage

The easiest way to create a parser is using the @Albatross.Expression.Parsing.ParserBuilder:

```csharp
using Albatross.Expression.Parsing;

var parser = new ParserBuilder().BuildDefault();
var result = parser.Eval("2 + 3 * 4", null); // Returns: 14
```

### Compiling vs Direct Evaluation

For expressions that will be evaluated multiple times, compile them first for better performance:

```csharp
// Direct evaluation (good for one-time use)
var result1 = parser.Eval("x + y", variableResolver);

// Compiled expression (better for repeated use)
var compiledExpression = parser.Compile("x + y");
var result2 = compiledExpression.EvalValue(variableResolver);
var result3 = compiledExpression.EvalValue(variableResolver); // Reuse compiled expression
```

## Architecture

The Parser processes expressions through a three-step pipeline:

### 1. Tokenization
Converts expression text into individual tokens (numbers, operators, functions, variables)

### 2. Stack Building  
Uses the Shunting-yard algorithm to convert tokens into a postfix stack

### 3. Tree Creation
Builds an Abstract Syntax Tree (AST) from the postfix stack for evaluation

This design enables:
- **Performance**: Expressions are compiled once and can be evaluated multiple times
- **Flexibility**: Support for complex nested expressions with proper operator precedence
- **Extensibility**: Easy to add new operations and functions

## Supported Expression Types

The parser supports a rich variety of expression elements:

### Literals
- **Numeric**: `123`, `45.67`, `-89.1` (all converted to `double`)
- **String**: `"hello"`, `'world'` (single or double quotes)
- **Boolean**: `true`, `false`

### Variables
- **Simple**: `x`, `userName`, `totalAmount`
- **Case-sensitive**: Variables are case-sensitive by default

### Operators
- **Arithmetic**: `+`, `-`, `*`, `/`, `^` (power), `%` (modulo)
- **Comparison**: `>`, `<`, `>=`, `<=`, `=`, `<>` (not equal)
- **Logical**: `and`, `or`, `not`
- **Unary**: `-x` (negative), `+x` (positive)

### Functions
- **Built-in**: `max(1,2,3)`, `if(condition, true_value, false_value)`, `now()`, `upper("text")`
- **Unlimited Parameters**: Functions can accept variable numbers of arguments

### Arrays
- **Creation**: `@(1, 2, 3, 4, 5)` creates an array
- **Access**: Array elements can be accessed through array functions

### Parentheses
- **Grouping**: `(a + b) * c` controls evaluation order
- **Function Calls**: `max(1, 2)`, `left("text", 3)`


## Processing Pipeline Details

### Tokenization

Tokenization reads the expression from left to right, recognizing individual components (tokens). This step validates syntax and throws @Albatross.Expression.Exceptions.TokenParsingException for invalid expressions.

**Example**: `4 + 5 * 6 - max(7, 1)`

Tokens produced:
- `4` (numeric literal)
- `+` (operator) 
- `5` (numeric literal)
- `*` (operator)
- `6` (numeric literal)
- `-` (operator)
- `max` (function)
- `(` (open parenthesis)
- `7` (numeric literal)
- `,` (comma separator)
- `1` (numeric literal)
- `)` (close parenthesis)

**String Handling**: String boundaries (quotes) are part of the token and are processed by @Albatross.Expression.Nodes.StringLiteral during evaluation.

### Stack Building (Shunting-yard Algorithm)

Converts the tokenized queue into a postfix stack using the [Shunting-yard algorithm](https://en.wikipedia.org/wiki/Shunting-yard_algorithm), creating a [Reverse Polish Notation](https://en.wikipedia.org/wiki/Reverse_Polish_notation) representation.

**Example**: `4 + 5 * 6 - max(7, 1)`

Postfix stack (top to bottom):
```
-
max
1
7
$
+
*
6
5
4
```

The special `$` token marks the end of function parameters, enabling support for functions with variable argument counts.

### Tree Creation

Converts the postfix stack into an Abstract Syntax Tree (AST) for efficient evaluation and reuse.

**Example Tree**: `4 + 5 * 6 - max(7, 1)`
```
    -
   / \
  +   max
 / \   |
4   *  7,1
   / \
  5   6
```

## Expression Evaluation

### Basic Evaluation

Once the AST is built, evaluation is performed through recursive calls to the @Albatross.Expression.Nodes.IExpression interface:

```csharp
var parser = new ParserBuilder().BuildDefault();

// Simple evaluation
var result1 = parser.Eval("2 + 3", null); // Returns: 5

// With parentheses
var result2 = parser.Eval("(2 + 3) * 4", null); // Returns: 20

// String operations
var result3 = parser.Eval("upper('hello')", null); // Returns: "HELLO"
```

### Using Variables

Variables are resolved through a function delegate that provides variable values:

```csharp
var parser = new ParserBuilder().BuildDefault();

// Define variable resolver
Func<string, object> variableResolver = variableName => {
    return variableName.ToLower() switch {
        "x" => 10,
        "y" => 20,
        "name" => "World",
        _ => null
    };
};

// Evaluate with variables
var result1 = parser.Eval("x + y", variableResolver); // Returns: 30
var result2 = parser.Eval("'Hello ' + name", variableResolver); // Returns: "Hello World"
```

### Advanced Variable Usage

```csharp
public class CalculatorTest
{
    [TestCase("a + b * c", ExpectedResult = 7)]
    [TestCase("a + b + c", ExpectedResult = 6)]
    [TestCase("max(a, b, c)", ExpectedResult = 3)]
    public object Run(string expression) 
    {
        var parser = new ParserBuilder().BuildDefault();
        
        Func<string, object> variableResolver = name => {
            return name.ToLower() switch {
                "a" => 1,
                "b" => 2, 
                "c" => 3,
                _ => throw new ArgumentException($"Unknown variable: {name}")
            };
        };
        
        return parser.Eval(expression, variableResolver);
    }
}
```

## Expression Regeneration

The parser can convert expressions back to text format, applying consistent formatting and minimal parentheses:

```csharp
var parser = new ParserBuilder().BuildDefault();
var compiled = parser.Compile("1+(2*3)");

// Regenerate with clean formatting
var regenerated = compiled.EvalText(null); // Returns: "1 + 2 * 3"
```

### Use Cases for Regeneration
- **Formatting**: Clean up user-entered expressions
- **Validation**: Verify expression parsing by round-trip conversion
- **Translation**: Convert between different expression formats
- **Optimization**: Remove unnecessary parentheses while preserving logic

## Error Handling

The parser provides detailed error information for invalid expressions:

```csharp
try 
{
    var parser = new ParserBuilder().BuildDefault();
    var result = parser.Eval("2 + + 3", null); // Invalid syntax
}
catch (TokenParsingException ex)
{
    Console.WriteLine($"Syntax error: {ex.Message}");
    Console.WriteLine($"Position: {ex.Position}");
}
catch (OperandException ex)
{
    Console.WriteLine($"Operand error: {ex.Message}");
}
```

## Performance Considerations

### Compilation Strategy
```csharp
// For single use - direct evaluation
var oneTimeResult = parser.Eval("x + y", resolver);

// For repeated use - compile once, evaluate many times
var compiled = parser.Compile("x + y");
for (int i = 0; i < 1000; i++)
{
    var result = compiled.EvalValue(GetResolver(i));
}
```

### Best Practices
- **Compile once**: For expressions used multiple times, compile once and reuse
- **Cache compiled expressions**: Store compiled expressions for frequently used formulas
- **Validate early**: Compile expressions during application startup to catch errors early
- **Use appropriate types**: The parser converts all numbers to `double` - consider this for precision requirements

## Integration with ExecutionContext

For complex scenarios with multiple variables and dependencies, consider using ExecutionContext:

```csharp
var parser = new ParserBuilder().BuildDefault();
var context = new DefaultExecutionContext<MyDataModel>(parser);

// Define variables that reference model properties
context.Set(new ExternalContextValue<MyDataModel>("revenue", m => m.Revenue));
context.Set(new ExternalContextValue<MyDataModel>("expenses", m => m.Expenses));
context.Set(new ExpressionContextValue<MyDataModel>("profit", "revenue - expenses", parser));

// Evaluate with model data
var model = new MyDataModel { Revenue = 100000, Expenses = 75000 };
var profit = context.GetValue("profit", model); // Returns: 25000
```
