using static System.FormattableString;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    private static class InnerExceptionFactory
    {
        internal static ArgumentOutOfRangeException UnexpectedCloneMode(string paramName, FlatArrayCloneMode actualValue)
            =>
            new(paramName, InnerBuildOutOfRangeMessage("An unexpected value of the clone mode.", actualValue));

        internal static ArgumentOutOfRangeException IndexOutOfRange(string paramName, int actualValue)
            =>
            new(paramName, InnerBuildOutOfRangeMessage("Index must be greater than or equal to zero and less than the array length.", actualValue));

        internal static InvalidOperationException EnumerationEitherNotStartedOrFinished()
            =>
            new("Enumeration has either not started or has already finished.");

        internal static OutOfMemoryException SourceTooLarge()
            =>
            new("The source is too large to allocate.");

        private static string InnerBuildOutOfRangeMessage<TValue>(string message, TValue actualValue)
        {
            var separator = message.TrimEnd().EndsWith('.') ? null : ".";

            return Invariant($"{message}{separator} Actual value was {actualValue}.");
        }
    }
}
