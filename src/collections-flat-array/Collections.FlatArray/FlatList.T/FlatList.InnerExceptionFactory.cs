using static System.FormattableString;

namespace System.Collections.Generic;

partial class FlatList<T>
{
    private static class InnerExceptionFactory
    {
        internal static ArgumentOutOfRangeException IndexOutOfRange(string paramName, int actualValue)
            =>
            new(paramName, InnerBuildOutOfRangeMessage("Index must be greater than or equal to zero and less than the array length.", actualValue));

        internal static InvalidOperationException EnumerationEitherNotStartedOrFinished()
            =>
            new("Enumeration has either not started or has already finished.");

        internal static NotSupportedException NotSupportedOnReadOnlyCollection()
            =>
            new("The operation is not supported on read-only collection.");

        private static string InnerBuildOutOfRangeMessage<TValue>(string message, TValue actualValue)
        {
            var separator = message.TrimEnd().EndsWith('.') ? null : ".";

            return Invariant($"{message}{separator} Actual value was {actualValue}.");
        }
    }
}
