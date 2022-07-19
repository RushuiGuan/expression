using System;

namespace Albatross.Expression
{
    public static class Config
    {
        public const string DefaultVariableNamePattern = @"^\s*([a-zA-Z_][a-zA-Z0-9_]*(\.[a-zA-Z_][a-zA-Z0-9_]+)?) \b (?!\s*\() ";

        public static class NowFunction
        {
            public static DateTimeKind DateTimeKind { get; set; } = DateTimeKind.Local;

            public static int HourInterval { get; set; } = 1;

            public static int MinuteInterval { get; set; } = 1;

            public static int SecoundInterval { get; set; } = 1;
        }

        public static class NumericLiteral
        {
            public static string Culture { get; set; } = "en-US";
        }
    }
}
