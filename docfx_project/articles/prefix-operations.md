# Prefix Operations

Prefix operations are function-style expressions that take operands within parentheses. For example: `Max(1, 2, 3)` or `Left("hello", 2)`.

## Array Operations

### Array (@)
Creates an object array from the provided operands.

**Operands:** 0 to unlimited
**Operand Types:** Any
**Output Type:** `List<object>`

**Usage:**
```
@(1, 2, 3, 4, 5)
```

---

### ArrayItem
Returns the value of an array item at the specified index.

**Operands:** 2 (required)
1. `array` - The source array, list, or JSON array
2. `index` - The zero-based index (integer)

**Output Type:** The type of the array element

**Usage:**
```
ArrayItem(@(1, 2, 3), 1)  // returns 2
```

**Exceptions:**
- `ArgumentException` when index is out of bounds
- `ArgumentException` when the first operand is not a collection

---

## String Operations

### Concat
Concatenates multiple operands into a single string.

**Operands:** 1 to unlimited
**Operand Types:** Any (converted to string)
**Output Type:** `string`

**Usage:**
```
Concat("Hello", " ", "World")  // returns "Hello World"
```

---

### Left
Returns a substring from the beginning of a string with the specified length.

**Operands:** 2 (required)
1. `input` - The source string
2. `count` - Number of characters to extract (positive integer)

**Output Type:** `string`

**Usage:**
```
Left("test", 1)  // returns "t"
Left("hello", 3)  // returns "hel"
```

**Exceptions:**
- `OperandException` when count is negative

---

### Right
Extracts a specified number of characters from the right side of a string.

**Operands:** 2 (required)
1. `input` - The source string
2. `count` - Number of characters to extract (positive integer)

**Output Type:** `string`

**Usage:**
```
Right("test", 2)  // returns "st"
Right("hello", 3)  // returns "llo"
```

**Notes:** If the requested count exceeds the string length, returns the entire string.

**Exceptions:**
- `OperandException` when count is negative

---

### Len
Returns the length of a string, collection, or JSON array.

**Operands:** 1 (required)
1. `input` - A string, collection, or JSON array

**Output Type:** `int`

**Usage:**
```
Len("hello")  // returns 5
Len(@(1, 2, 3))  // returns 3
```

**Exceptions:**
- `FormatException` when input is not a string, collection, or JSON array

---

### PadLeft
Pads a string to a specified total length by adding characters to the left.

**Operands:** 2-3
1. `input` - The source string
2. `totalWidth` - The target total width (integer)
3. `paddingChar` (optional) - The padding character (defaults to space)

**Output Type:** `string`

**Usage:**
```
PadLeft("5", 3)  // returns "  5"
PadLeft("5", 3, "0")  // returns "005"
```

---

### PadRight
Pads a string to a specified total length by adding characters to the right.

**Operands:** 2-3
1. `input` - The source string
2. `totalWidth` - The target total width (integer)
3. `paddingChar` (optional) - The padding character (defaults to space)

**Output Type:** `string`

**Usage:**
```
PadRight("5", 3)  // returns "5  "
PadRight("5", 3, "0")  // returns "500"
```

---

### Lower
Converts a string to lowercase using invariant culture.

**Operands:** 1 (required)
1. `input` - The source string

**Output Type:** `string`

**Usage:**
```
Lower("HELLO")  // returns "hello"
```

---

### Upper
Converts a string to uppercase using invariant culture.

**Operands:** 1 (required)
1. `input` - The source string

**Output Type:** `string`

**Usage:**
```
Upper("hello")  // returns "HELLO"
```

---

### Text
Converts any operand to its string representation.

**Operands:** 1 (required)
1. `input` - Any value to convert

**Output Type:** `string`

**Usage:**
```
Text(123)  // returns "123"
Text(true)  // returns "True"
```

---

### Regex
Uses a regular expression to capture a part of the input text.

**Operands:** 2-3
1. `text` - The text to parse
2. `pattern` - A regex pattern
3. `groupIndex` (optional) - Captured group index (defaults to 0)

**Output Type:** `string`

**Usage:**
```
Regex("hello123world", "\\d+")  // returns "123"
Regex("test@email.com", "(.+)@(.+)", 1)  // returns "test"
```

**Exceptions:**
- `ArgumentException` when pattern doesn't match
- `ArgumentException` when group index is out of range

---

## Numeric Operations

### Avg
Calculates the arithmetic average of multiple numeric operands.

**Operands:** 0 to unlimited
**Operand Types:** Numeric (converted to double)
**Output Type:** `double`

**Usage:**
```
Avg(1, 2, 3, 4, 5)  // returns 3.0
```

**Notes:** Returns NaN if no operands are provided.

---

### Max
Finds the maximum value among multiple numeric operands.

**Operands:** 1 to unlimited
**Operand Types:** Numeric (converted to double)
**Output Type:** `double`

**Usage:**
```
Max(1, 5, 3)  // returns 5.0
```

---

### Min
Finds the minimum value among multiple numeric operands.

**Operands:** 0 to unlimited
**Operand Types:** Numeric (converted to double)
**Output Type:** `double`

**Usage:**
```
Min(1, 5, 3)  // returns 1.0
```

**Notes:** Returns `double.MaxValue` if no operands are provided.

---

### Number
Converts an operand to a numeric (double) value.

**Operands:** 1 (required)
1. `input` - Value to convert to number

**Output Type:** `double`

**Usage:**
```
Number("123.45")  // returns 123.45
```

**Exceptions:**
- `FormatException` when input cannot be converted to a number

---

### Floor
Rounds a number down to the nearest integer, removing all decimals.

**Operands:** 1 (required)
1. `input` - Numeric value to floor

**Output Type:** `double`

**Usage:**
```
Floor(3.7)  // returns 3.0
Floor(-2.3)  // returns -3.0
```

---

### Round
Performs midpoint rounding away from zero.

**Operands:** 2 (required)
1. `input` - Numeric value to round
2. `digits` - Number of decimal digits

**Output Type:** `double`

**Usage:**
```
Round(3.456, 2)  // returns 3.46
Round(2.5, 0)  // returns 3.0
```

---

### Random
Generates a random integer within a specified range.

**Operands:** 2 (required)
1. `min` - Minimum value (inclusive)
2. `max` - Maximum value (exclusive)

**Output Type:** `int`

**Usage:**
```
Random(1, 10)  // returns a random integer from 1 to 9
```

**Exceptions:**
- `ArgumentOutOfRangeException` when min is greater than max

---

## Date/Time Operations

### DateTime
Converts an input value to a DateTime object.

**Operands:** 1 (required)
1. `input` - Any value that can be converted to DateTime (string, number, etc.)

**Output Type:** `DateTime`

**Usage:**
```
DateTime("2024-01-15")
DateTime("January 15, 2024")
```

---

### Now
Returns the current local date and time.

**Operands:** 0
**Output Type:** `DateTime`

**Usage:**
```
Now()
```

---

### Today
Returns the current date at midnight (start of day).

**Operands:** 0
**Output Type:** `DateTime`

**Usage:**
```
Today()
```

---

### UtcNow
Returns the current Coordinated Universal Time (UTC).

**Operands:** 0
**Output Type:** `DateTime`

**Usage:**
```
UtcNow()
```

---

### Utc
Converts a DateTime value to UTC.

**Operands:** 1 (required)
1. `input` - DateTime value or string to convert

**Output Type:** `DateTime`

**Usage:**
```
Utc(Now())
```

---

### CreateDate
Creates a DateTime from year, month, and day components.

**Operands:** 3 (required)
1. `year` - The year (integer)
2. `month` - The month 1-12 (integer)
3. `day` - The day 1-31 (integer)

**Output Type:** `DateTime`

**Usage:**
```
CreateDate(2024, 1, 31)
```

---

### Year
Extracts the year component from a DateTime value.

**Operands:** 1 (required)
1. `input` - DateTime value

**Output Type:** `int`

**Usage:**
```
Year(Today())  // returns current year, e.g., 2024
```

---

### Month
Extracts the month component from a DateTime value.

**Operands:** 1 (required)
1. `input` - DateTime value

**Output Type:** `int` (1-12)

**Usage:**
```
Month(Today())  // returns current month (1 for January, 12 for December)
```

---

### MonthName
Returns the full month name from a DateTime value using current culture.

**Operands:** 1 (required)
1. `input` - DateTime value

**Output Type:** `string`

**Usage:**
```
MonthName(CreateDate(2024, 1, 15))  // returns "January"
```

---

### ShortMonthName
Returns the abbreviated month name from a DateTime value using current culture.

**Operands:** 1 (required)
1. `input` - DateTime value

**Output Type:** `string`

**Usage:**
```
ShortMonthName(CreateDate(2024, 1, 15))  // returns "Jan"
```

---

### DayOfWeek
Extracts the day of the week from a DateTime value.

**Operands:** 1 (required)
1. `input` - DateTime value

**Output Type:** `double` (0=Sunday, 1=Monday, ... 6=Saturday)

**Usage:**
```
DayOfWeek(Today())
```

---

### NextWeekDay
Finds the next weekday (Monday-Friday) from a given date.

**Operands:** 1-2
1. `date` - The starting date
2. `count` (optional) - Number of weekdays to advance (defaults to 1)

**Output Type:** `DateTime`

**Usage:**
```
NextWeekDay(Today())  // returns next business day
NextWeekDay(Today(), 5)  // returns 5 business days ahead
```

---

### PreviousWeekDay
Finds the previous weekday (Monday-Friday) from a given date.

**Operands:** 1-2
1. `date` - The starting date
2. `count` (optional) - Number of weekdays to go back (defaults to 1)

**Output Type:** `DateTime`

**Usage:**
```
PreviousWeekDay(Today())  // returns previous business day
PreviousWeekDay(Today(), 5)  // returns 5 business days ago
```

---

### UnixTimestamp
Converts a DateTime to Unix timestamp (seconds since 1970-01-01T00:00:00Z).

**Operands:** 1 (required)
1. `input` - DateTime value or string to convert

**Output Type:** `double`

**Usage:**
```
UnixTimestamp(Now())
```

---

## Logical Operations

### If
Conditional expression that returns different values based on a boolean condition.

**Operands:** 3 (required)
1. `condition` - Boolean expression
2. `trueValue` - Value to return if condition is true
3. `falseValue` - Value to return if condition is false

**Output Type:** Type of the selected value

**Usage:**
```
If(1 > 0, "yes", "no")  // returns "yes"
If(x = 0, "zero", "non-zero")
```

---

### Not
Inverts a boolean value (logical NOT).

**Operands:** 1 (required)
1. `input` - Boolean value

**Output Type:** `bool`

**Usage:**
```
Not(true)  // returns false
Not(1 > 2)  // returns true
```

---

## Formatting Operations

### Format
Formats a value using a C# format string.

**Operands:** 2 (required)
1. `value` - The value to format
2. `formatString` - C# format specifier

**Output Type:** `string`

**Usage:**
```
Format(1234.5, "N2")  // returns "1,234.50"
Format(Now(), "yyyy-MM-dd")  // returns "2024-01-15"
Format(0.15, "P0")  // returns "15%"
```

---

## System Operations

### CurrentApp
Returns the current application domain's friendly name.

**Operands:** 0
**Output Type:** `string`

**Usage:**
```
CurrentApp()
```

---

### CurrentMachine
Returns the current machine's host name.

**Operands:** 0
**Output Type:** `string`

**Usage:**
```
CurrentMachine()
```

---

## JSON Operations

### JsonProperty
Returns a JSON property value using a JSON Pointer path.

**Operands:** 2-3
1. `json` - JSON element or text to parse
2. `pointer` - JSON Pointer path (e.g., "/property/nested")
3. `fallback` (optional) - Default value if property is null

**Output Type:** The type of the JSON value

**Usage:**
```
JsonProperty('{"name":"John"}', "/name")  // returns "John"
JsonProperty('{"a":{"b":1}}', "/a/b")  // returns 1
```

**Exceptions:**
- `ArgumentException` when the path is not found
- `ArgumentNullException` when value is null and no fallback provided

---

## File System Operations

### JoinPath
Combines multiple path segments into a single file system path.

**Operands:** 1 to unlimited
**Operand Types:** String (path segments)
**Output Type:** `string`

**Usage:**
```
JoinPath("folder", "subfolder", "file.txt")  // returns "folder/subfolder/file.txt" (or with backslashes on Windows)
```
