using Albatross.Expression.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Albatross.Expression {
	public class Factory : IEnumerable<IToken> {

		IStringLiteralToken stringLiteralToken = new DoubleQuoteStringLiteralToken();
		public Factory DefaultStringLiteralToken(IStringLiteralToken token) {
			if (token == null) {
				throw new ArgumentNullException();
			}
			stringLiteralToken = token;
			return this;
		}

		IVariableToken variableToken = new VariableToken();
		public Factory DefaultVariableToken(IVariableToken variableToken) {
			if (variableToken == null) {
				throw new ArgumentNullException();
			}
			this.variableToken = variableToken;
			return this;
		}

		Dictionary<Type, IToken> operations = new Dictionary<Type, IToken>();

		public Factory Register(Assembly asm) {
			foreach (Type type in asm.GetTypes()) {
				if (type.GetCustomAttribute<ParserOperationAttribute>() != null) {
					if (typeof(IToken).IsAssignableFrom(type)) { 
						operations[type] = (IToken)Activator.CreateInstance(type);
					}
				}
			}
			return this;
		}
		public Factory Replace<T, K>() where T : IToken where K : IToken, new() {
			operations.Remove(typeof(T));
			operations[typeof(K)] = new K();
			return this;
		}
		public IParser Create(IStringLiteralToken stringLiteralToken = null, IVariableToken variableToken = null) {
			return new Parser(operations.Values, variableToken ?? this.variableToken, stringLiteralToken?? this.stringLiteralToken);
		}

		public IEnumerator<IToken> GetEnumerator() {
			return operations.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return operations.Values.GetEnumerator();
		}

		public Factory() {
			Register(this.GetType().Assembly);
		}

		#region singleton
		private static readonly Lazy<Factory> lazy = new Lazy<Factory>(()=>new Factory());
		public static Factory Instance { get { return lazy.Value; } }
		#endregion
	}
}
