using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Tokens;
using System;

namespace Albatross.Expression.Operations
{
    /// <summary>
    /// <para>Prefix operation that returns the current app domain friendly name</para>
    /// <para>Operand Count: 0</para>
    /// <para>Output Type: string</para>
    /// </summary>
    [FunctionDoc(Group.Environment, "{token}()",
        @"
		### Current application name
		"
    )]
    [ParserOperation]
    public class CurrentApp : PrefixOperationToken
    {

        public override string Name { get { return "CurrentApp"; } }
        public override int MinOperandCount { get { return 0; } }
        public override int MaxOperandCount { get { return 0; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            return AppDomain.CurrentDomain.FriendlyName;
        }
    }
}
