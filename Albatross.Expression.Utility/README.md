# Albatross.Expression.Utility

A command-line interface (CLI) tool for evaluating mathematical and logical expressions with support for variable management. Built on the powerful [Albatross.Expression](../Albatross.Expression) library, this utility provides an interactive way to work with expressions and store reusable variables.

## Features

- **Expression Evaluation**: Evaluate complex mathematical, logical, and string expressions
- **Variable Management**: Store, retrieve, list, and remove named variables for reuse
- **Persistent Storage**: Variables are automatically saved to local application data directory
- **Rich Expression Support**: Leverage all capabilities of the Albatross.Expression library including:
  - Mathematical operations (arithmetic, trigonometric, statistical)
  - String manipulation functions
  - Date/time operations
  - Logical operations and comparisons
  - Array operations
  - Regular expression support
- **Command Aliases**: Short aliases for faster command execution
- **Cross-platform**: Works on Windows, macOS, and Linux

## Prerequisites

- .NET 8.0 SDK or later
- Command-line interface (Terminal, PowerShell, etc.)

## Installation

### Option 1: Install as Global .NET Tool (Recommended)

```bash
dotnet tool install -g Albatross.Expression.Utility
```

### Option 2: Build from Source

```bash
git clone https://github.com/RushuiGuan/expression.git
cd expression
dotnet restore
dotnet build
dotnet pack Albatross.Expression.Utility
dotnet tool install -g --add-source ./Albatross.Expression.Utility/bin/Debug Albatross.Expression.Utility
```

## Usage

The tool is invoked using the `ex` command followed by subcommands:

```bash
ex <command> [parameters] [arguments]
```

### Commands

#### `eval` - Evaluate an Expression
Evaluate a mathematical, logical, or string expression.

**Syntax:**
```bash
ex eval <expression>
ex e <expression>    # Short alias
```

**Examples:**
```bash
# Mathematical expressions
ex eval "2 + 3 * 4"
# Output: 14

ex eval "sqrt(16) + power(2, 3)"
# Output: 12

# String operations
ex eval "concat('Hello', ' ', 'World')"
# Output: Hello World

# Date operations
ex eval "year(now())"
# Output: 2024

# Logical expressions
ex eval "5 > 3 and 2 < 10"
# Output: True
```

#### `set` - Set a Variable
Store a variable with a name and expression value.

**Syntax:**
```bash
ex set -n <name> -v <expression>
ex s -n <name> -v <expression>    # Short alias
```

**Examples:**
```bash
# Set numeric variables
ex set -n pi -v 3.14159
ex set -n radius -v 5

# Set expression variables
ex set -n area -v "pi * power(radius, 2)"

# Set string variables
ex set -n greeting -v "concat('Hello, ', 'World!')"
```

#### `list` - List All Variables
Display all stored variables with their values.

**Syntax:**
```bash
ex list
ex l    # Short alias
```

**Example:**
```bash
ex list
```
**Output:**
```
Name     Value
----     -----
pi       3.14159
radius   5
area     pi * power(radius, 2)
greeting concat('Hello, ', 'World!')
```

#### `read` - Read a Variable
Read and evaluate a stored variable.

**Syntax:**
```bash
ex read <variable_name>
ex r <variable_name>    # Short alias
```

**Examples:**
```bash
ex read pi
# Output: 3.14159

ex read area
# Output: 78.53975 (calculated using stored pi and radius values)
```

#### `remove` - Remove a Variable
Delete a stored variable.

**Syntax:**
```bash
ex remove <variable_name>
```

**Examples:**
```bash
ex remove pi
ex remove area
```

### Working with Variables

Variables are automatically resolved when evaluating expressions. This allows you to build complex calculations step by step:

```bash
# Step 1: Set base values
ex set -n length -v 10
ex set -n width -v 5
ex set -n height -v 3

# Step 2: Calculate intermediate values
ex set -n area -v "length * width"
ex set -n volume -v "area * height"

# Step 3: Use in expressions
ex eval "volume * 2"
# Output: 300

# Step 4: View all variables
ex list
```

### Advanced Expression Examples

```bash
# Complex mathematical expressions
ex eval "sin(pi/2) + cos(0)"
# Output: 2

# String manipulation
ex eval "upper(left('hello world', 5))"
# Output: HELLO

# Conditional logic
ex eval "if(5 > 3, 'yes', 'no')"
# Output: yes

# Date calculations
ex eval "dayOfWeek(today())"
# Output: Monday (example)

# Array operations
ex eval "array(1, 2, 3, 4, 5)"
# Output: [1, 2, 3, 4, 5]
```

## Data Storage

Variables are stored as text files in your local application data directory:
- **Windows**: `%LOCALAPPDATA%\Albatross.Expression.Utility\`
- **macOS**: `~/.local/share/Albatross.Expression.Utility/`
- **Linux**: `~/.local/share/Albatross.Expression.Utility/`

Each variable is stored as a separate `.txt` file containing the expression definition.

## Error Handling

The tool provides clear error messages for common issues:
- Invalid expression syntax
- Undefined variables
- Invalid variable names
- Mathematical errors (division by zero, etc.)

## Documentation

For Api Reference, visit: https://rushuiguan.github.io/expression/

## License

This project is licensed under the MIT License - see the [LICENSE](../LICENSE) file for details.

## Related Projects

- [Albatross.Expression](../Albatross.Expression) - The core expression parsing and evaluation library
- [Albatross.CommandLine](https://github.com/RushuiGuan/framework) - Command-line framework used by this utility

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request or open an Issue for bugs, features, or questions.