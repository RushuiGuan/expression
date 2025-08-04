using Albatross.Expression.Nodes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Albatross.Expression.Test
{
	[TestFixture]
    public class GenerateDocumentation
    {
		[TestCase(@"c:\temp\operation.printout.txt")]
		public void PrintOperations(string file) {
			using (FileStream stream = new FileStream(file, FileMode.OpenOrCreate)) {
				using (StreamWriter writer = new StreamWriter(stream)) {
					foreach (var token in from item in new Factory() orderby item.Name select item) {
						writer.WriteLine($"{token.Name} | [{token.GetType().FullName}](xref:{token.GetType().FullName}) | {GetOperationType(token)}");
					}
					writer.Flush();
					stream.SetLength(stream.Position);
				}
			}
		}
		string GetOperationType(INode token) {
			if (token is PrefixExpression) {
				if (((PrefixExpression)token).Symbolic) {
					return "Unary";
				} else {
					return "prefix";
				}
			} else if (token is InfixExpression) {
				return "infix";
			} else {
				throw new NotSupportedException();
			}
		}


		[TestCase(@"c:\temp\precedence.printout.txt")]
		public void PrintAllInfixOperations(string file) {
			var tokens = from token in Factory.Instance where token is InfixExpression orderby ((InfixExpression)token).Precedence ascending select token;
			using (FileStream stream = new FileStream(file, FileMode.OpenOrCreate)) {
				using (StreamWriter writer = new StreamWriter(stream)) {
					foreach (InfixExpression token in tokens) {
						writer.WriteLine($"{token.Operator} | [{token.GetType().FullName}](xref:{token.GetType().FullName}) | {token.Precedence}");
					}
					writer.Flush();
					stream.SetLength(stream.Position);
				}
			}
		}

		[TestCase("4 + 5 * 6 - max(7, 1)", @"c:\temp\stack1.txt")]
		[TestCase("if (a > b, \"Yes\", \"No\")", @"c:\temp\stack2.txt")]
		[TestCase("Format(Today(), \"yyyy-MM-DD\")", @"c:\temp\stack3.txt")]
		public void PrintStack(string expression, string file) {
			var parser = Factory.Instance.Create();
			var queue = parser.Tokenize(expression);
			var stack = parser.BuildStack(queue);
			using (FileStream stream = new FileStream(file, FileMode.OpenOrCreate)) {
				using (StreamWriter writer = new StreamWriter(stream)) {
					while (stack.Count > 0) {
						INode token = stack.Pop();
						writer.WriteLine("\t* `{0}`", token.Name);
					}
					writer.Flush();
					stream.SetLength(stream.Position);
				}
			}
		}

		[TestCase("4 + 5 * 6 - max(7, 1)", @"c:\temp\tree1.txt")]
		[TestCase("if (a > b, \"Yes\", \"No\")", @"c:\temp\tree2.txt")]
		[TestCase("Format(Today(), \"yyyy-MM-DD\")", @"c:\temp\tree3.txt")]
		public void PrintTree(string expression, string file) {
			var parser = Factory.Instance.Create();
			var queue = parser.Tokenize(expression);
			var stack = parser.BuildStack(queue);
			var token = parser.CreateTree(stack);
			using (FileStream stream = new FileStream(file, FileMode.OpenOrCreate)) {
				using (StreamWriter writer = new StreamWriter(stream)) {
					PrintToken(writer, token, 1);
					writer.Flush();
					stream.SetLength(stream.Position);
				}
			}
		}
		void PrintToken(StreamWriter writer, INode token, int level) {
			writer.Write("".PadRight(level, '\t'));
			writer.WriteLine("* `{0}`", token.Name);
			level++;
			if (token is InfixExpression) {
				PrintToken(writer, ((InfixExpression)token).Operand1, level);
				PrintToken(writer, ((InfixExpression)token).Operand2, level);
			} else if (token is PrefixExpression) {
				foreach (var child in ((PrefixExpression)token).Operands) {
					PrintToken(writer, child, level);
				}
			}
		}
	}
}
