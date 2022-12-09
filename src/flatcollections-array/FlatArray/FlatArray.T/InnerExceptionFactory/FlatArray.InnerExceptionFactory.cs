using static System.FormattableString;

namespace System;

partial struct FlatArray<T>
{
    private static class InnerExceptionFactory
    {
        internal static ArgumentOutOfRangeException LengthOutOfRange(string paramName, int actualValue)
            =>
            new(paramName, Invariant($"Array length must be greater than or equal to zero. Actual value was {actualValue}."));

        internal static ArgumentOutOfRangeException CapacityOutOfRange_MustBeGreaterThanOrEqualToZero(string paramName, int actualValue)
            =>
            new(paramName, Invariant($"Capacity must be greater than or equal to zero. Actual value was {actualValue}."));

        internal static ArgumentOutOfRangeException CapacityOutOfRange_MustBeGreaterThanOrEqualToLength(string paramName, int actualValue, int length)
            =>
            new(paramName, Invariant($"Capacity must be greater than or equal to the array length. Actual value was {actualValue}. Length was {length}."));

        internal static IndexOutOfRangeException IndexOutOfRange(int actualValue, int length)
            =>
            new(Invariant($"Index must be greater than or equal to zero and less than the array length. Actual value was {actualValue}. Length was {length}."));

        internal static InvalidOperationException EnumerationEitherNotStartedOrFinished()
            =>
            new("Enumeration has either not started or has already finished.");

        internal static OutOfMemoryException SourceTooLarge()
            =>
            new("The source is too large to allocate.");

        internal static NotSupportedException NotSupportedOnReadOnlyArray()
            =>
            new("The operation is not supported on read-only array.");
    }
}
