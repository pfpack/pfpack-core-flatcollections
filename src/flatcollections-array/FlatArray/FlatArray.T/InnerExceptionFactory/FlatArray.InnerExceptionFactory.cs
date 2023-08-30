using static System.FormattableString;

namespace System;

partial struct FlatArray<T>
{
    private static class InnerExceptionFactory
    {
        internal static ArgumentOutOfRangeException StartSegmentOutsideBounds(string paramName, int segmentLength, int arrayLength)
            =>
            new(paramName, Invariant($"Start segment must be within the array bounds. Start segment length was {segmentLength}. Array length was {arrayLength}."));

        internal static ArgumentOutOfRangeException SegmentOutsideBounds(int segmentStart, int segmentLength, int arrayLength)
            =>
            new(null, Invariant($"Segment must be within the array bounds. Segment start was {segmentStart}. Segment length was {segmentLength}. Array length was {arrayLength}."));

        internal static IndexOutOfRangeException IndexOutOfRange(int index, int length)
            =>
            new(Invariant($"Index must be greater than or equal to zero and less than the array length. Index was {index}. Array length was {length}."));

        internal static InvalidOperationException EnumerationEitherNotStartedOrFinished()
            =>
            new("Enumeration has either not started or has already finished.");
    }
}
