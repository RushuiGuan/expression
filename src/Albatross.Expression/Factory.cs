using Albatross.Expression.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Albatross.Expression {
	/// <summary>
	/// <para>
	/// The default parser factory class.  This class can be accessed using its lazy static instance <see cref="Albatross.Expression.Factory.Instance"/> or by creating a new instance.
	/// The factory class by default will register any class with the <see cref="Albatross.Expression.ParserOperationAttribute"/> attribute within this assembly.  Additional assemblies
	/// can be registered using the <see cref="Albatross.Expression.Factory.Register(Assembly)"/> function.  
	/// </para>
	/// 
	/// <para>By default, the factory will use <see cref="Albatross.Expression.Tokens.SingleDoubleQuoteStringLiteralToken"/> for string literal token and 
	/// <see cref="Albatross.Expression.Tokens.VariableToken"/> for variable token.  These defaults can be changed for the factory instance object.</para>
	/// 
	/// </summary>
	public class Factory : IEnumerable<IToken> {

		IStringLiteralToken defaultStringLiteralToken = new SingleDoubleQuoteStringLiteralToken();
		public Factory DefaultStringLiteralToken(IStringLiteralToken token) {
			if (token == null) {
				throw new ArgumentNullException();
			}
			defaultStringLiteralToken = token;
			return this;
		}

		IVariableToken defaultVariableToken = new VariableToken();
		public Factory DefaultVariableToken(IVariableToken variableToken) {
			if (variableToken == null) {
				throw new ArgumentNullException();
			}
			this.defaultVariableToken = variableToken;
			return this;
		}

		Dictionary<Type, IToken> operations = new Dictionary<Type, IToken>();

		internal Dictionary<Type, IToken> Operations => operations;

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
			return new Parser(operations.Values, variableToken ?? this.defaultVariableToken, stringLiteralToken?? this.defaultStringLiteralToken);
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
