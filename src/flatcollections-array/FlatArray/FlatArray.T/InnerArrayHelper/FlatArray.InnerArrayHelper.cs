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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T[] Copy(T[] array, int length)
        {
            Debug.Assert(length >= 0 && length <= array.Length);

            ReadOnlySpan<T> sourceSpan = length == array.Length
                ? new(array)
                : new(array, 0, length);
            return sourceSpan.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T[] CopySegment(T[] array, int start, int length)
        {
            Debug.Assert(InnerAllocHelper.IsSegmentWithinBounds(start, length, array.Length));

            ReadOnlySpan<T> sourceSpan = start == default && length == array.Length
                ? new(array)
                : new(array, start, length);
            return sourceSpan.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T[] Concat(T[] array1, int length1, T[] array2, int length2)
        {
            Debug.Assert(length1 >= 0 && length1 <= array1.Length);
            Debug.Assert(length2 >= 0 && length2 <= array2.Length);

            ReadOnlySpan<T> sourceSpan1 = length1 == array1.Length
                ? new(array1)
                : new(array1, 0, length1);

            ReadOnlySpan<T> sourceSpan2 = length2 == array2.Length
                ? new(array2)
                : new(array2, 0, length2);

            var result = new T[unchecked(length1 + length2)];

            sourceSpan1.CopyTo(new Span<T>(result, 0, length1));
            sourceSpan2.CopyTo(new Span<T>(result, length1, length2));

            return result;
        }
    }
}
