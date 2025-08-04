using Albatross.Expression.Nodes;
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
	/// <para>By default, the factory will use <see cref="SingleDoubleQuoteStringLiteral"/> for string literal token and 
	/// <see cref="Variable"/> for variable token.  These defaults can be changed for the factory instance object.</para>
	/// 
	/// </summary>
	public class Factory : IEnumerable<INode> {

		IStringLiteral defaultStringLiteralToken = new SingleDoubleQuoteStringLiteral();
		public Factory DefaultStringLiteralToken(IStringLiteral token) {
			if (token == null) {
				throw new ArgumentNullException();
			}
			defaultStringLiteralToken = token;
			return this;
		}

		IVariable defaultVariable = new Variable();
		public Factory DefaultVariableToken(IVariable variable) {
			if (variable == null) {
				throw new ArgumentNullException();
			}
			this.defaultVariable = variable;
			return this;
		}

		Dictionary<Type, INode> operations = new Dictionary<Type, INode>();

		public Factory Register(Assembly asm) {
			foreach (Type type in asm.GetTypes()) {
				if (type.GetCustomAttribute<ParserOperationAttribute>() != null) {
					if (typeof(INode).IsAssignableFrom(type)) {
						operations[type] = (INode)Activator.CreateInstance(type);
					}
				}
			}
			return this;
		}

		/// <summary>
		/// Register instances of tokens/operations
		/// </summary>
		/// <param name="tokens">Token/operations instances to register</param>
		/// <returns></returns>
		public Factory Register(IEnumerable<INode> tokens) {
			foreach (var token in tokens) {
				operations[token.GetType()] = token;
			}

			return this;
		}

		public Factory Replace<T, K>() where T : INode where K : INode, new() {
			operations.Remove(typeof(T));
			operations[typeof(K)] = new K();
			return this;
		}
		public IParser Create(IStringLiteral? stringLiteralToken = null, IVariable? variableToken = null) {
			return new Parser(operations.Values, variableToken ?? this.defaultVariable, stringLiteralToken ?? this.defaultStringLiteralToken);
		}

		public IEnumerator<INode> GetEnumerator() {
			return operations.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return operations.Values.GetEnumerator();
		}

		public Factory() {
			Register(this.GetType().Assembly);
		}

		#region singleton
		private static readonly Lazy<Factory> lazy = new Lazy<Factory>(() => new Factory());
		public static Factory Instance { get { return lazy.Value; } }
		#endregion
	}
}
