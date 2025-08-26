using Albatross.Expression.Parsing;
using Xunit;

namespace Albatross.Expression.Test.Parsing {
	public class TestPostfixStack {
		[Theory]
		[InlineData("1+2", "+ 2 1")]
		[InlineData("1+2*3", "+ * 3 2 1")]
		[InlineData("1+test(2)", "+ test 2 $ 1")]
		[InlineData("1+test(2, 3)", "+ test 3 2 $ 1")]

		//Arithmetic & Precedence
		[InlineData("1 + 2", "+ 2 1")]
		[InlineData("1 - 2 - 3", "- 3 - 2 1")]
		[InlineData("1 * 2 + 3", "+ 3 * 2 1")]
		[InlineData("1 + 2 * 3", "+ * 3 2 1")]
		[InlineData("(1 + 2) * 3", "* 3 + 2 1")]
		[InlineData("1 * (2 + 3)", "* + 3 2 1")]
		[InlineData("10 / 5 % 3", "% 3 / 5 10")]
		[InlineData("10 % 5 / 3", "/ 3 % 5 10")]

		// comparison
		[InlineData("a = b", "= b a")]
		[InlineData("a <> b", "<> b a")]
		[InlineData("a < b + c", "< + c b a")]
		[InlineData("a + b = c * d", "= * d c + b a")]
		[InlineData("(a + b) <> (c * d)", "<> * d c + b a")]

		// logical
		[InlineData("a and b", "and b a")]
		[InlineData("a or b", "or b a")]
		[InlineData("a or b and c", "or and c b a")]
		[InlineData("(a or b) and c", "and c or b a")]
		[InlineData("a and b or c and d", "or and d c and b a")]
		[InlineData("a = b and c = d", "and = d c = b a")]
		[InlineData("a = b or c = d and e = f", "or and = f e = d c = b a")]
		[InlineData("(a = b or c = d) and e = f", "and = f e or = d c = b a")]
		[InlineData("a < b or c and d < e", "or and < e d c < b a")]

		// Single-arg prefix
		[InlineData("not(a)", "not a $")]
		[InlineData("isnull(a)", "isnull a $")]
		[InlineData("_pre(x)", "_pre x $")]

		// Multi-arg prefix
		[InlineData("f(a,b,c)", "f c b a $")]
		[InlineData("sum(1,2,3,4)", "sum 4 3 2 1 $")]
		[InlineData("_pre(x, y)", "_pre y x $")]

		// Prefix with arithmetic inside args
		[InlineData("isnull(a + b)", "isnull + b a $")]
		[InlineData("max(a, b + c, d)", "max d + c b a $")]
		[InlineData("wrap((a+b), (c*d), e^(f+g))", "wrap ^ + g f e * d c + b a $")]
		[InlineData("f(a, b * c ^ d, e % 5)", "f % 5 e * ^ d c b a $")]

		// Prefix nested in prefix
		[InlineData("g(h(a), b)", "g b h a $ $")]
		[InlineData("outer(inner(1,2), 3)", "outer 3 inner 2 1 $ $")]
		[InlineData("f(g(a,b), h(c, d+e))", "f h + e d c $ g b a $ $")]
		[InlineData("p(q(r(s(t))))", "p q r s t $ $ $ $")]

		// Prefix combined with comparisons/logical
		[InlineData("not(a = b)", "not = b a $")]
		[InlineData("not(a and b)", "not and b a $")]
		[InlineData("not(a) and b", "and b not a $")]
		[InlineData("not(a) or b and not(c)", "or and not c $ b not a $")]
		[InlineData("isnull(a) or not(b * c <> d / e)", "or not <> / e d * c b $ isnull a $")]
		[InlineData("not(a = b) and c", "and c not = b a $")]

		// Heavier mixed nesting
		[InlineData("calc(a-b, x<y or p(q), r*s + u)", "calc + u * s r or p q $ < y x - b a $")]
		[InlineData("not(isnull(a) and f(b,c,d))", "not and f d c b $ isnull a $ $")]
		[InlineData("max(f(a, b), g(c, h(d)))", "max g h d $ c $ f b a $ $")]

		// no parameters
		[InlineData("test()", "test $")]

		//unary
		[InlineData("-1", "- 1 $")]
		[InlineData("+1", "+ 1 $")]
		[InlineData("2--1", "- - 1 $ 2")]

		// Zero-arg & identifier edge cases
		[InlineData("now()", "now $")]
		[InlineData("empty()", "empty $")]
		[InlineData("F1_2(_x, y3)", "F1_2 y3 _x $")]
		[InlineData("f ( a , b )", "f b a $")] // whitespace-insensitive call

// Functions + nested ops
		[InlineData("pow(add(a,b), 2)", "pow 2 add b a $ $")]
		[InlineData("isnull(a = b, c)", "isnull c = b a $")]
		[InlineData("not(f(a) and g(b,c))", "not and g c b $ f a $ $")]
		[InlineData("isnull(f(), g())", "isnull g $ f $ $")]
		[InlineData("f(a + g(b), h(c) * d)", "f * d h c $ + g b $ a $")]
		[InlineData("f(a, g(b, h(c, d + e)), i + j, k)", "f k + j i g h + e d c $ b $ a $")]

// Deep nesting ($ placement)
		[InlineData("outer(inner1(a, b + c), inner2(d ^ e, f, g(h(i))))", "outer inner2 g h i $ $ f ^ e d $ inner1 + c b a $ $")]

// Function names that collide with operators (function-call vs infix)
		[InlineData("and(a,b)", "and b a $")] // function 'and'
		[InlineData("and(a,b) and and(c,d)", "and and d c $ and b a $")] // mix function + infix
		[InlineData("or(and(a,b), c)", "or c and b a $ $")] // function 'or' + nested function

// Mix with mult/div, comparisons, logical
		[InlineData("max( a, b + c, d*e )", "max * e d + c b a $")]
		[InlineData("f(a,b,c) = 0", "= 0 f c b a $")]
		[InlineData("if(a < b, c, d)", "if d c < b a $")]
		[InlineData("not(f(a)) and h(c)", "and h c $ not f a $ $")]

// Unary basics (unary treated as prefix with single operand + "$")
		[InlineData("-a", "- a $")]
		[InlineData("+a", "+ a $")]
		[InlineData("-(a)", "- a $")]
		[InlineData("+(a)", "+ a $")]
		[InlineData("--a", "- - a $ $")]
		[InlineData("++a", "+ + a $ $")]
		[InlineData("-+a", "- + a $ $")]
		[InlineData("+-a", "+ - a $ $")]

// Unary with multiplicative
		[InlineData("a * -b", "* - b $ a")]
		[InlineData("-a * b", "* b - a $")]
		[InlineData("a / -b", "/ - b $ a")]
		[InlineData("-a / b", "/ b - a $")]
		[InlineData("a % -b", "% - b $ a")]
		[InlineData("-a % b", "% b - a $")]
		[InlineData("a / -b % +c", "% + c $ / - b $ a")]

// Unary with additive
		[InlineData("a + -b", "+ - b $ a")]
		[InlineData("-a + b", "+ b - a $")]
		[InlineData("a - -b", "- - b $ a")]
		[InlineData("-a - -b", "- - b $ - a $")]
		[InlineData("+a - +b", "- + b $ + a $")]
		[InlineData("-(a + b)", "- + b a $")]
		[InlineData("-(a - b)", "- - b a $")]

// Unary with comparisons
		[InlineData("-a = +b", "= + b $ - a $")]
		[InlineData("-a <> +b", "<> + b $ - a $")]
		[InlineData("-a < +b", "< + b $ - a $")]
		[InlineData("-a <= +b", "<= + b $ - a $")]
		[InlineData("-a > +b", "> + b $ - a $")]
		[InlineData("-a >= +b", ">= + b $ - a $")]
		[InlineData("a * -b = c + -d", "= + - d $ c * - b $ a")]
		[InlineData("-(a) = -(b)", "= - b $ - a $")]

// Unary with logical
		[InlineData("-a < b and c < -d", "and < - d $ c < b - a $")]
		[InlineData("+x = -y or -m = +n", "or = + n $ - m $ = - y $ + x $")]
		[InlineData("(-a = b) and (c = -d)", "and = - d $ c = b - a $")]
		[InlineData("-(a = b) or c", "or c - = b a $")]

// Unary with parentheses & mixing
		[InlineData("-(a + b) * c", "* c - + b a $")]
		[InlineData("-a * (b + c)", "* + c b - a $")]
		[InlineData("(-a) * (b - +c)", "* - + c $ b - a $")]
		[InlineData("(+a) / (-(b % c))", "/ - % c b $ + a $")]
		[InlineData("(-a) % (b * -c)", "% * - c $ b - a $")]

// Functions mixed with unary (functions use "$")
		[InlineData("f(-a, +b)", "f + b $ - a $ $")]
		[InlineData("-f(a, b)", "- f b a $ $")]
		[InlineData("+f()", "+ f $ $")]
		[InlineData("h(-(a+b), +c)", "h + c $ - + b a $ $")]
		[InlineData("-(f(a, -b))", "- f - b $ a $ $")]
		[InlineData("f(--a, +-b)", "f + - b $ $ - - a $ $ $")]
		[InlineData("not(-a)", "not - a $ $")]
		[InlineData("not(-a) and +b", "and + b $ not - a $ $")]
		[InlineData("isnull(+a) or -f(b,c)", "or - f c b $ $ isnull + a $ $")]

// Heavier mixed combos
		[InlineData("a + -b * c ^ -d - +e % -f", "- % - f $ + e $ + * ^ - d $ c - b $ a")]
		[InlineData("(-a ^ b) and (c / -d = +e)", "and = + e $ / - d $ c - ^ b a $")]
		[InlineData("not(-a + b ^ -c) or -d <= +(e - f)", "or <= + - f e $ - d $ not + ^ - c $ b - a $ $")]
		[InlineData("-((a / -b) and (c + +d))", "- and + + d $ c / - b $ a $")]

		// Power-only chains (RIGHT-associative)
		[InlineData("2 ^ 3 ^ 4", "^ ^ 4 3 2")]
		[InlineData("(2 ^ 3) ^ 4", "^ 4 ^ 3 2")]
		[InlineData("a ^ b ^ c", "^ ^ c b a")]
		[InlineData("(a ^ b) ^ c", "^ c ^ b a")]
		[InlineData("a ^ (b ^ c)", "^ ^ c b a")]

// Parentheses override with numbers
		[InlineData("(-2) ^ 2", "^ 2 - 2 $")]
		[InlineData("-2 ^ 2", "- ^ 2 2 $")] // = -(2^2)

// Unary (treated as prefix with "$") + power (RIGHT-assoc; ^ tighter than unary)
		[InlineData("-a ^ b", "- ^ b a $")] // -(a ^ b)
		[InlineData("(-a) ^ b", "^ b - a $")]
		[InlineData("-(a ^ b)", "- ^ b a $")]
		[InlineData("a ^ -b", "^ - b $ a")] // a ^ (-b)
		[InlineData("(-a) ^ (-b)", "^ - b $ - a $")]
		[InlineData("-a ^ b ^ c", "- ^ ^ c b a $")] // -(a ^ (b ^ c))
		[InlineData("(-a) ^ b ^ c", "^ ^ c b - a $")] // (-a) ^ (b ^ c)
		[InlineData("a ^ (-b) ^ c", "^ ^ c - b $ a")] // a ^ ((-b) ^ c)
		[InlineData("a ^ -b ^ c", "^ - ^ c b $ a")] // a ^ (-(b ^ c))
		[InlineData("( -a ) ^ ( b ^ c )", "^ ^ c b - a $")]

// Power mixed with multiplicative/additive
		[InlineData("a * b ^ c ^ d", "* ^ ^ d c b a")] // a * (b ^ (c ^ d))
		[InlineData("a ^ b * c ^ d", "* ^ d c ^ b a")] // (a ^ b) * (c ^ d)
		[InlineData("a + b ^ c ^ d", "+ ^ ^ d c b a")] // a + (b ^ (c ^ d))
		[InlineData("a ^ b ^ c + d", "+ d ^ ^ c b a")] // (a ^ (b ^ c)) + d

// Functions (calls use "$") with power RIGHT-assoc
		[InlineData("f(a, b ^ c ^ d)", "f ^ ^ d c b a $")] // f(a, b ^ (c ^ d))
		[InlineData("f(a, (b ^ c) ^ d)", "f ^ d ^ c b a $")]
		[InlineData("f(a,b) ^ g(c) ^ h(d,e)", "^ ^ h e d $ g c $ f b a $")]
		[InlineData("(f(a,b) ^ g(c)) ^ h(d,e)", "^ h e d $ ^ g c $ f b a $")]
		[InlineData("f(a) ^ (g(b) ^ h(c))", "^ ^ h c $ g b $ f a $")]

// Unary + functions + power
		[InlineData("-f(a,b) ^ g(c)", "- ^ g c $ f b a $ $")]
		[InlineData("f(-a, +b ^ c)", "f + ^ c b $ - a $ $")]
		[InlineData("g(-a^b, c*-d)", "g * - d $ c - ^ b a $ $")]
		[InlineData("h(-(a+b), +c^d)", "h + ^ d c $ - + b a $ $")]

// Comparisons/logical around power
		[InlineData("a ^ b ^ c = d", "= d ^ ^ c b a")]
		[InlineData("a = b ^ c ^ d", "= ^ ^ d c b a")]
		[InlineData("a ^ b ^ c and d", "and d ^ ^ c b a")]
		[InlineData("(a ^ b ^ c) and (d + e * f = g)", "and = g + * f e d ^ ^ c b a")]

// Extra unary chains (prefix with "$")
		[InlineData("--a ^ b", "- - ^ b a $ $")]
		[InlineData("a ^ ++b", "^ + + b $ $ a")]
		[InlineData("-(a) ^ +(+b)", "- ^ + + b $ $ a $")] // -( a ^ +(+b) )
		[InlineData("(-a) ^ +(+b)", "^ + + b $ $ - a $")] // (-a) ^ (+(+b))

		[InlineData("'hello'", "'hello'")]
		[InlineData("\"hello\"", "\"hello\"")]
		[InlineData("'a' + 'b'", "+ 'b' 'a'")]
		[InlineData("'a' + \"b\"", "+ \"b\" 'a'")]
		[InlineData("(\"a\" + 'b') = \"ab\"", "= \"ab\" + 'b' \"a\"")]
		[InlineData("'ab' = 'a' + 'b'", "= + 'b' 'a' 'ab'")]
		[InlineData("'a' <> \"a\"", "<> \"a\" 'a'")]
		[InlineData("\"a\" < \"b\" or \"c\" <= \"d\"", "or <= \"d\" \"c\" < \"b\" \"a\"")]
		[InlineData("name = \"\"", "= \"\" name")]
		[InlineData("name = ''", "= '' name")]
		[InlineData("'It\\'s ok'", "'It\\'s ok'")]
		[InlineData("\"He said \\\"Hi\\\"\"", "\"He said \\\"Hi\\\"\"")]
		[InlineData("path = \"C:\\\\Temp\\\\file.txt\"", "= \"C:\\\\Temp\\\\file.txt\" path")]
		[InlineData("msg = 'C:\\\\temp\\\\log'", "= 'C:\\\\temp\\\\log' msg")]
		[InlineData("text = \"line1\\nline2\"", "= \"line1\\nline2\" text")]
		[InlineData("tab = 'col1\\tcol2'", "= 'col1\\tcol2' tab")]
		[InlineData("'O\\'Brien' = \"O'Brien\"", "= \"O'Brien\" 'O\\'Brien'")]
		[InlineData("\"A \\\"quote\\\"\" = 'A \"quote\"'", "= 'A \"quote\"' \"A \\\"quote\\\"\"")]
		[InlineData("contains(\"hello\",\"he\")", "contains \"he\" \"hello\" $")]
		[InlineData("startsWith(\"hello\",\"he\") and endsWith('world','ld')", "and endsWith 'ld' 'world' $ startsWith \"he\" \"hello\" $")]
		[InlineData("len(\"abc\") = 3", "= 3 len \"abc\" $")]
		[InlineData("concat('a',\"b\",'c')", "concat 'c' \"b\" 'a' $")]
		[InlineData("substr(\"hello\",1,2)", "substr 2 1 \"hello\" $")]
		[InlineData("contains(\"a\\\"b\",\"\\\"b\")", "contains \"\\\"b\" \"a\\\"b\" $")]
		[InlineData("replace(\"a\\\\b\",\"\\\\\",\"/\")", "replace \"/\" \"\\\\\" \"a\\\\b\" $")]
		[InlineData("not(\"x\" = \"y\")", "not = \"y\" \"x\" $")]
		[InlineData("contains(\"hello\",\"he\") and not(\"x\" = \"y\")", "and not = \"y\" \"x\" $ contains \"he\" \"hello\" $")]
		public void Run(string text, string expected) {
			var parser = new ParserBuilder().BuildDefault(true);
			var tokens = parser.Tokenize(text);
			var stack = parser.BuildPostfixStack(tokens);
			Assert.Equal(expected, string.Join(' ', stack.Select(x => x.Token)));
		}
	}
}