# Infix Operations

## What is an Infix Operation?

An infix operation is a math expression with an operator in the middle and two operands, one on each side of the operator. Here are some examples:

1. `1 + 2`
2. `1 + 2 + 3`
3. `2 + 5 * 4`
4. `1 > 2 or 3 > 2`
5. `(1 + 2) * 3`
6. `1 * -1`

Infix operations can be chained as the examples shown above. When chained, the precedence of the operator decides which gets executed first. If two operators have the same precedence, they are executed from left to right. For example, `2 + 5 * 4` will execute `5 * 4` first because the `*` operator has a precedence of 200 which is larger than the precedence of the `+` operator (100). The `+` operator will then execute `2 + 20`. The second operand `20` comes from the output of the `*` operator.

**Parentheses** can be used to override the precedence of the operators as shown in example #5.

A **unary operator** such as the negative sign in example #6 will always have precedence over any infix operators.

## Precedence Table

| Operation | Precedence |
|---|---|
| `or` | 20 |
| `and` | 30 |
| `=`, `<>`, `<`, `<=`, `>`, `>=` | 50 |
| `+`, `-` | 100 |
| `*`, `/`, `%` | 200 |
| `^` | 300 |

---

## Arithmetic Operations

### Plus (+)
Performs addition of two numeric values.

**Operator:** `+`
**Precedence:** 100
**Operands:** 2 (required)
- Left operand: Numeric value
- Right operand: Numeric value

**Output Type:** `double`

**Usage:**
```
1 + 2  // returns 3.0
3.5 + 2.5  // returns 6.0
```

---

### Minus (-)
Performs subtraction of two numeric values.

**Operator:** `-`
**Precedence:** 100
**Operands:** 2 (required)
- Left operand: Numeric value (minuend)
- Right operand: Numeric value (subtrahend)

**Output Type:** `double`

**Usage:**
```
5 - 3  // returns 2.0
10 - 15  // returns -5.0
```

---

### Multiply (*)
Performs multiplication of two numeric values.

**Operator:** `*`
**Precedence:** 200
**Operands:** 2 (required)
- Left operand: Numeric value
- Right operand: Numeric value

**Output Type:** `double`

**Usage:**
```
3 * 4  // returns 12.0
2.5 * 4  // returns 10.0
```

---

### Divide (/)
Performs division of two numeric values.

**Operator:** `/`
**Precedence:** 200
**Operands:** 2 (required)
- Left operand: Numeric value (dividend)
- Right operand: Numeric value (divisor)

**Output Type:** `double`

**Usage:**
```
10 / 2  // returns 5.0
7 / 2  // returns 3.5
```

**Notes:** Division by zero returns `Infinity` or `-Infinity` (following IEEE 754 floating-point behavior).

---

### Mod (%)
Performs modulo (remainder) operation on two numeric values.

**Operator:** `%`
**Precedence:** 200
**Operands:** 2 (required)
- Left operand: Numeric value (dividend)
- Right operand: Numeric value (divisor)

**Output Type:** `double`

**Usage:**
```
10 % 3  // returns 1.0
15 % 4  // returns 3.0
```

---

### Power (^)
Raises a base number to a specified power (exponentiation).

**Operator:** `^`
**Precedence:** 300
**Operands:** 2 (required)
- Left operand: Numeric value (base)
- Right operand: Numeric value (exponent)

**Output Type:** `double`

**Usage:**
```
2 ^ 3  // returns 8.0
9 ^ 0.5  // returns 3.0 (square root)
```

---

## Comparison Operations

All comparison operations require both operands to be of the same type. Supported types are: `double`, `DateTime`, `string`, and `bool`.

### Equal (=)
Checks if two values are equal.

**Operator:** `=`
**Precedence:** 50
**Operands:** 2 (required)
- Left operand: Any comparable value
- Right operand: Any comparable value (same type as left)

**Output Type:** `bool`

**Usage:**
```
5 = 5  // returns true
"abc" = "abc"  // returns true
5 = 3  // returns false
```

---

### NotEqual (<>)
Checks if two values are not equal.

**Operator:** `<>`
**Precedence:** 50
**Operands:** 2 (required)
- Left operand: Any comparable value
- Right operand: Any comparable value (same type as left)

**Output Type:** `bool`

**Usage:**
```
5 <> 3  // returns true
"abc" <> "xyz"  // returns true
5 <> 5  // returns false
```

---

### LessThan (<)
Checks if the left operand is less than the right operand.

**Operator:** `<`
**Precedence:** 50
**Operands:** 2 (required)
- Left operand: Any comparable value
- Right operand: Any comparable value (same type as left)

**Output Type:** `bool`

**Usage:**
```
3 < 5  // returns true
5 < 3  // returns false
"abc" < "xyz"  // returns true (lexicographic comparison)
```

---

### LessEqual (<=)
Checks if the left operand is less than or equal to the right operand.

**Operator:** `<=`
**Precedence:** 50
**Operands:** 2 (required)
- Left operand: Any comparable value
- Right operand: Any comparable value (same type as left)

**Output Type:** `bool`

**Usage:**
```
3 <= 5  // returns true
5 <= 5  // returns true
5 <= 3  // returns false
```

---

### GreaterThan (>)
Checks if the left operand is greater than the right operand.

**Operator:** `>`
**Precedence:** 50
**Operands:** 2 (required)
- Left operand: Any comparable value
- Right operand: Any comparable value (same type as left)

**Output Type:** `bool`

**Usage:**
```
5 > 3  // returns true
3 > 5  // returns false
```

---

### GreaterEqual (>=)
Checks if the left operand is greater than or equal to the right operand.

**Operator:** `>=`
**Precedence:** 50
**Operands:** 2 (required)
- Left operand: Any comparable value
- Right operand: Any comparable value (same type as left)

**Output Type:** `bool`

**Usage:**
```
5 >= 3  // returns true
5 >= 5  // returns true
3 >= 5  // returns false
```

---

## Logical Operations

### And
Performs logical AND operation. Returns true only when both operands are true.

**Operator:** `and`
**Precedence:** 30
**Operands:** 2 (required)
- Left operand: Boolean value
- Right operand: Boolean value

**Output Type:** `bool`

**Usage:**
```
true and true  // returns true
true and false  // returns false
1 > 0 and 2 > 1  // returns true
```

---

### Or
Performs logical OR operation. Returns true when at least one operand is true.

**Operator:** `or`
**Precedence:** 20
**Operands:** 2 (required)
- Left operand: Boolean value
- Right operand: Boolean value

**Output Type:** `bool`

**Usage:**
```
true or false  // returns true
false or false  // returns false
1 > 2 or 3 > 2  // returns true
```
