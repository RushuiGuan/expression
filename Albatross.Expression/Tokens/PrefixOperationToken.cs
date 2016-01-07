using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;
using Albatross.Expression.Exceptions;

namespace Albatross.Expression.Tokens {
	public abstract class PrefixOperationToken : IToken {
		const char LeftParenthesis = '(';

		public PrefixOperationToken() {
			Operands = new List<IToken>();
		}
		
		public abstract string Name { get; }
		public abstract bool Symbolic { get; }
		public abstract int MinOperandCount { get; }
		public abstract int MaxOperandCount {get;}
		public string Group { get; protected set; }
		public string ClassName { get; protected set; }
		public string Definition { get; protected set; }
		public string Example { get; protected set; }

		public List<IToken> Operands { get; private set; }

		public bool Match(string expression, int start, out int next) {
			next = expression.Length;
			if (start < expression.Length) {
				while (start < expression.Length && char.IsWhiteSpace(expression[start])) {
					start++;
				}
				if (expression.IndexOf(Name, start, StringComparison.InvariantCultureIgnoreCase) == start) {
					if (Symbolic) {
						next = start + Name.Length;
						return true;
					} else {
						char c;
						//look for a left Parenthesis, but don't consume it
						for (int i = start + Name.Length; i < expression.Length; i++) {
							c = expression[i];
							if (char.IsWhiteSpace(c)) {
								continue;
							} else if (c == LeftParenthesis) {
								next = start + Name.Length;
								return true;
							} else {
								return false;
							}
						}
					}
				}
			}
			return false;
		}
		public virtual string EvalText(string format) {
			if (Operands.Count < MinOperandCount || Operands.Count > MaxOperandCount) {
				throw new OperandException(Name);
			}
			StringBuilder sb = new StringBuilder();
			if (Symbolic) {
				sb.Append(Name);
				if (Operands.Count == 0) {
					sb.Append("[Missing]");
				} else {
					sb.Append(Operands.First().EvalText(format));
				}
			} else {
				sb.Append(Name);
				sb.Append(ControlToken.LeftParenthesis);
				sb.Append(string.Join(ControlToken.Comma.ToString(), from token in Operands select token.EvalText(format)));
				sb.Append(ControlToken.RightParenthesis);
			}
			return sb.ToString();
		}
		public override string ToString() {
			return Name;
		}
		//make a copy of the token without the operands data
		public virtual IToken Clone() {
			Type type = this.GetType();
			return (IToken)Activator.CreateInstance(type);
		}

		public virtual object EvalValue(Func<string, object> context) {
			return null;
		}
		protected List<Object> GetOperands(Func<string, object> context) {
			List<object> list = new List<object>();
			object value;
			foreach (IToken token in Operands) {
				value = token.EvalValue(context);
				list.Add(value);
			}
			if (list.Count < MinOperandCount || list.Count > MaxOperandCount) { throw new OperandException(Name); }
			return list;
		}
		//return operands of the same type
		protected List<Object> GetOperands(Func<string, object> context, out Type type) {
			List<object> list = new List<object>();
			type = null;
			object value;
			foreach (IToken token in Operands) {
				value = token.EvalValue(context);
				list.Add(value);
				if (type == null) {
					if (value != null) {
						type = value.GetType();
					}
				} else if (value != null && type != value.GetType()) {
					throw new UnexpectedTypeException(type, value.GetType());
				}
			}
			if (list.Count < MinOperandCount || list.Count > MaxOperandCount) { throw new OperandException(Name); }
			return list;
		}
		protected List<T> GetOperands<T>(Func<string, object> context) {
			List<T> list = new List<T>();
			object value;
			foreach (IToken token in Operands) {
				value = token.EvalValue(context);
				if (value != null && !(value is T)) {
					throw new UnexpectedTypeException(typeof(T), value.GetType());
				}else if(value == null){
					list.Add(default(T));
				} else {
					list.Add((T)value);
				}
			}
			if (list.Count < MinOperandCount || list.Count > MaxOperandCount) { throw new OperandException(Name); }
			return list;
		}
		protected string[] GetOperandText(object args, int count, string format) {
			string[] text = new string[count];
			for (int i = 0; i < count; i++) {
				if (Operands.Count > i) {
					text[i] = Operands[i].EvalText(format);
				} else {
					text[i] = "Missing";
				}
			}
			return text;
		}
		public bool IsVariable { get { return false; } }
	}
}