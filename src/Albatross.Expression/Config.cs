using System;

namespace Albatross.Expression
{
    public static class Config
    {
        public static class NowFunction
        {
            public static DateTimeKind DateTimeKind { get; set; } = DateTimeKind.Local;

            public static Func<DateTime, DateTime> Normalizer { get; set; } = (d) => d;

            public static int SecoundInterval { get; set; } = 1;

            public static int MinuteInterval { get; set; } = 1;

            public static int HourInterval { get; set; } = 1;
        }

        public static class NumericLiteral
        {
            public static string Culture { get; set; } = "en-US";
        }
    }
}
