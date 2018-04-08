using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Albatross.Expression.Exceptions;

namespace Albatross.Expression.Tokens {
	public abstract class InfixOperationToken : IToken {
		public abstract string Name { get; }
		public abstract bool Symbolic { get;}
		public abstract int Precedence { get;}

		public virtual bool Match(string expression, int start, out int next) {
			next = expression.Length;
			if (start < expression.Length) {
				while (start < expression.Length && char.IsWhiteSpace(expression[start])) {
					start++;
				}
				if (expression.IndexOf(Name, start,StringComparison.InvariantCultureIgnoreCase) == start) {
					next = start + Name.Length;
					return true;
				}
			}
			return false;
		}
		public IToken Operand1 { get; set; }
		public IToken Operand2 { get; set; }
		public override string ToString() {
			return Name;
		}
		public virtual string EvalText(string format) {
			if (Operand1 == null || Operand2 == null) { throw new OperandException(Name); }
			StringBuilder sb = new StringBuilder();
			if (Operand1 != null) {
				if (Operand1 is InfixOperationToken && ((InfixOperationToken)Operand1).Precedence < Precedence) {
					sb.AppendFormat("({0})", Operand1.EvalText(format));
				} else {
					sb.Append(Operand1.EvalText(format));
				}
			} else {
				sb.Append("[Missing]");
			}
			sb.Append(' ').Append(Name).Append(' ');
			if (Operand2 != null) {
				if (Operand2 is InfixOperationToken && ((InfixOperationToken)Operand2).Precedence <= Precedence) {
					sb.AppendFormat("({0})", Operand2.EvalText(format));
				} else {
					sb.Append(Operand2.EvalText(format));
				}
			} else {
				sb.Append("[Missing]");
			}
			return sb.ToString();
		}
		//make a copy of the token without the operands data
		public virtual IToken Clone() {
			Type type = this.GetType();
			return (IToken)Activator.CreateInstance(type);
		}

		public virtual object EvalValue(Func<string, object> context) {
			return null;
		}

	}
}
