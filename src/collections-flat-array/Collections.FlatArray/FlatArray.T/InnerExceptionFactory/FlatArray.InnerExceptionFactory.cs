using static System.FormattableString;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    private static class InnerExceptionFactory
    {
        internal static InvalidOperationException AlreadyBuilt()
            =>
            new("The array is already built.");

        internal static ArgumentOutOfRangeException LengthOutOfRange(string paramName, int actualValue)
            =>
            new(paramName, InnerBuildOutOfRangeMessage("Array length must be greater than or equal to zero.", actualValue));

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
