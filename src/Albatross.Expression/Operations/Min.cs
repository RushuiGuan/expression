﻿using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Exceptions;
using Albatross.Expression.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Albatross.Expression.Operations
{
    [OperationDoc(Group.Boolean, "{token}( , )", @"### Returns the smallest of the given numbers.")]
    [ParserOperation]
    public class Min : PrefixOperationToken
    {

        public override string Name { get { return "Min"; } }
        public override int MinOperandCount { get { return 0; } }
        public override int MaxOperandCount { get { return int.MaxValue; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            System.Type type;
            IEnumerable items = GetParamsOperands(context, out type);

            if (type == null)
            {
                return null;
            }
            else if (type == typeof(double))
            {
                return GetMin<double>(items);
            }
            else if (type == typeof(DateTime))
            {
                return GetMin<DateTime>(items);
            }
            else if (type == typeof(string))
            {
                return GetMinString(items);
            }
            else
            {
                throw new UnexpectedTypeException(type);
            }
        }

        public static object GetMin<T>(IEnumerable list) where T : struct
        {
            T? t = null;
            try
            {
                foreach (T? item in list)
                {
                    if (item != null)
                    {
                        if (t.HasValue)
                        {
                            if (Comparer<T>.Default.Compare(item.Value, t.Value) < 0)
                            {
                                t = item.Value;
                            }
                        }
                        else
                        {
                            t = item.Value;
                        }
                    }
                }
            }
            catch (InvalidCastException)
            {
                throw new UnexpectedTypeException();
            }
            if (t.HasValue)
            {
                return t.Value;
            }
            else
            {
                return null;
            }
        }

        public static object GetMinString(IEnumerable list)
        {
            string max = null, item;
            foreach (object obj in list)
            {
                item = Convert.ToString(obj);
                if (item != null)
                {
                    if (max == null)
                    {
                        max = item;
                    }
                    else if (string.Compare(item, max) < 0)
                    {
                        max = item;
                    }
                }
            }
            return max;
        }
    }
}
