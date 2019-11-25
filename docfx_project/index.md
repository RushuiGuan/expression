# Albatross Expression Api

## Summary
Albatross.Expression api is created to process and evaluate text based expression strings.  

## Description
The api tokenizes the expression text and create a tree model from the tokens.  Using the model, it can evaluate the expression or convert it to a expression of different format.  Some applications revert the process by creating the model first and use it to generate certain expression such as a sql query statement.  The api also contains a useful ExecutionContext class that allows evaluation of expressions with variables.  The variables can be read internally or directly from external objects.

## Release
* 2.0.4
	* No breaking changes.
	* License change from GNU GPLv3 to MIT.
	* Allow direct registration of IToken instances in the [Factory](xref:Albatross.Expression.Factory) class.
* 2.0.3
	* Breaking Changes
		* The Add method of the [IParser](xref:Albatross.Expression.IParser) interface has been removed.  Adding new operations to the instance of [Parser](xref:Albatross.Expression.Parser) class will alter its state.  This change will make the [Parser](xref:Albatross.Expression.Parser) class immutable.
		* The Compile method of the [IParser](xref:Albatross.Expression.IParser) interface has been removed.  It is replaced by a extension method - [Compile](xref:Albatross.Expression.Extensions.Compile(Albatross.Expression.IParser,System.String)).  The Compile method is a short hand for the Tokenize, BuildStack and CreateTree process.  It doesn't introduce any functionality therefore it doesn't belong in the interface.
    * New StringTokenLiteral - [SingleDoubleQuoteStringLiteralToken](xref:Albatross.Expression.Tokens.SingleDoubleQuoteStringLiteralToken) class has been created to accept single quote or double quote strings.
    * New ExecutionContextFactory - [ReflectionExecutionContextFactory<T>](xref:Albatross.Expression.ReflectionExecutionContextFactory`1) class has been created to supply variable value from the public instance properties of the input object (of class T) using reflection.  The execution context created by this factory is always case sensitive.
* 2.0.2
    * Breaking Changes
        * Mininum target framework has been changed from net40 to net45.
        * Precedence for ``and, or`` operations has been set to the lowest (30, 20) among all infix operations.  As the result of this change, the following expression will now return true: ``2 > 1 and 3 > 1``.
        * [IParser](xref:Albatross.Expression.IParser) interface no longer has the ``SetVariableToken`` and ``SetStringLiteralToken`` methods.  That means Variabletoken or StringLiteralToken types can no longer be changed after the parser has been created.
        * Change to the constructor of the [Parser](xref:Albatross.Expression.Parser) class to require two additional parameter [IVariableToken](xref:Albatross.Expression.Tokens.IVariableToken) and [IStringLiteralToken](xref:Albatross.Expression.Tokens.IVariableToken).
        * [IExecutionContextFactory](xref:Albatross.Expression.IExecutionContextFactory`1) is now a generic interface.  It requires a type to specify the input data type.
        * [IExecutionContext](xref:Albatross.Expression.IExecutionContext`1) interface is now a generic interface as well.  It has been redefined and reduced so that it is easier to use.
    * [ParserOperationAttribute](xref:Albatross.Expression.ParserOperationAttribute) (new)
        * A custom attribute used to mark the operations so that it will be used by the Factory class when constructing a parser object.
    * [Factory](xref:Albatross.Expression.Factory) class (new)
        * Allow quick creation of a Parser instance.
        * The class can scan an assembly and register any parser operation class with the [ParserOperationAttribute](xref:Albatross.Expression.ParserOperationAttribute) attribute.
    * [DataRowExecutionContextFactory](xref:Albatross.Expression.DataRowExecutionContextFactory) class (new)
        * A prewired execution context factory that works with the external data type System.Data.DataRow.
    * [DictionaryExecutionContextFactory](xref:Albatross.Expression.DictionaryExecutionContextFactory) class (new)
        * A prewired execution context factory that works with the external data type System.Collection.Generic.IDictionary<string, object>
    * [ExpressionBuilder](xref:Albatross.Expression.ExpressionBuilder) is marked as Obsolete.
    * Add additional target framework netstandard2.0
    * Strengthen Unit testing.
    * Add lots of documentation.
* 1.3.6218.36673 - Orignal release
    * Created: 1/10/2017