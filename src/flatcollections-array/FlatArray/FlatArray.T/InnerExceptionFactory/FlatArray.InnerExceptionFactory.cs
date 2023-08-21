using static System.FormattableString;

namespace System;

partial struct FlatArray<T>
{
    private static class InnerExceptionFactory
    {
        internal static ArgumentOutOfRangeException StartSegmentIsNotWithinArray(string paramName, int segmentLength, int arrayLength)
            =>
            new(paramName, Invariant($"Start segment length must be within the array length. Start segment length was {segmentLength}. Array length was {arrayLength}."));

        internal static ArgumentOutOfRangeException SegmentIsNotWithinArray(int segmentStart, int segmentLength, int arrayLength)
            =>
            new(null, Invariant($"Segment must be within array. Segment start was {segmentStart}. Segment length was {segmentLength}. Array length was {arrayLength}."));

        internal static IndexOutOfRangeException IndexOutOfRange(int index, int length)
            =>
            new(Invariant($"Index must be greater than or equal to zero and less than the array length. Index was {index}. Array length was {length}."));

        internal static InvalidOperationException EnumerationEitherNotStartedOrFinished()
            =>
            new("Enumeration has either not started or has already finished.");
    }
}
