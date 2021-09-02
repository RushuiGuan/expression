using System;

namespace Albatross.Expression
{
    public static class ExpressionMode
    {
        public static bool IsValidationMode { get; private set; } = false;

        public static IDisposable BeginValidationMode()
        {
            IsValidationMode = true;

            return new DisposeAction(() => IsValidationMode = false);
        }
    }
}
