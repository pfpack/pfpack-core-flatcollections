using static System.FormattableString;

namespace System;

partial struct FlatArray<T>
{
    private static class InnerExceptionFactory
    {
        internal static ArgumentOutOfRangeException StartSegmentLengthOutOfArrayLength(string paramName, int actualValue, int length)
            =>
            new(paramName, Invariant($"Start segment length must be within the array length. Actual value was {actualValue}. Array length was {length}."));

        internal static IndexOutOfRangeException IndexOutOfRange(int actualValue, int length)
            =>
            new(Invariant($"Index must be greater than or equal to zero and less than the array length. Actual value was {actualValue}. Length was {length}."));

        internal static InvalidOperationException EnumerationEitherNotStartedOrFinished()
            =>
            new("Enumeration has either not started or has already finished.");
    }
}
