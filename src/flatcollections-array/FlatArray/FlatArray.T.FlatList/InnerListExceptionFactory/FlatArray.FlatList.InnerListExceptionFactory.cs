using static System.FormattableString;

namespace System;

partial struct FlatArray<T>
{
    partial class FlatList
    {
        private static class InnerListExceptionFactory
        {
            internal static NotSupportedException NotSupportedOnReadOnlyArray()
                =>
                new("The operation is not supported on read-only array.");

            internal static ArgumentOutOfRangeException CopyTo_ArrayIndexLessThanZero(string paramName, int actualValue)
                =>
                new(paramName, Invariant($"Array index must be greater than or equal to zero. Actual value was {actualValue}."));

            internal static ArgumentException CopyTo_SourceOutsideDestBounds(int sourceLength, int destStartIndex, int destLength)
                =>
                new(null, Invariant($"The number of elements in the source array must be less than or equal to the available space from the array index to the end of the destination array. Source length was {sourceLength}. Destination start index was {destStartIndex}. Destination length was {destLength}."));
        }
    }
}
