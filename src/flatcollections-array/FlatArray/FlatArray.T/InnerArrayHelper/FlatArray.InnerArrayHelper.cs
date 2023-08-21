using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    private static class InnerArrayHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T[] Copy(T[] array)
            =>
            new ReadOnlySpan<T>(array).ToArray();

        // The caller MUST ensure the length is within the array length
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T[] Copy(T[] array, int length)
        {
            Debug.Assert(length >= 0 && length <= array.Length);

            var sourceSpan = length == array.Length
                ? new ReadOnlySpan<T>(array)
                : new ReadOnlySpan<T>(array, 0, length);
            return sourceSpan.ToArray();
        }

        // The caller MUST ensure the segment is within the array
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T[] CopySegment(T[] array, int start, int length)
        {
            Debug.Assert(InnerAllocHelper.IsSegmentWithin(start, length, array.Length));

            var sourceSpan = start == default && length == array.Length
                ? new ReadOnlySpan<T>(array)
                : new ReadOnlySpan<T>(array, start, length);
            return sourceSpan.ToArray();
        }

        // The caller MUST ensure the lengths are within the arrays actual lengths
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T[] Concat(T[] array1, int length1, T[] array2, int length2)
        {
            Debug.Assert(length1 >= 0 && length1 <= array1.Length);
            Debug.Assert(length2 >= 0 && length2 <= array2.Length);

            var sourceSpan1 = length1 == array1.Length
                ? new ReadOnlySpan<T>(array1)
                : new ReadOnlySpan<T>(array1, 0, length1);

            var sourceSpan2 = length2 == array2.Length
                ? new ReadOnlySpan<T>(array2)
                : new ReadOnlySpan<T>(array2, 0, length2);

            var result = new T[length1 + length2];
            sourceSpan1.CopyTo(new Span<T>(result, 0, length1));
            sourceSpan2.CopyTo(new Span<T>(result, length1, length2));
            return result;
        }
    }
}
