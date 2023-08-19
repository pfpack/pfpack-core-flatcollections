using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    private static class InnerArrayHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T[] Copy(T[] source)
            =>
            new ReadOnlySpan<T>(source).ToArray();

        // The caller MUST ensure the length is within the source length
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T[] Copy(T[] source, int length)
        {
            Debug.Assert(length >= 0 && length <= source.Length);

            return new ReadOnlySpan<T>(source, 0, length).ToArray();
        }

        // The caller MUST ensure the lengths are within the arrays actual lengths
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T[] Concat(T[] array1, int length1, T[] array2, int length2)
        {
            Debug.Assert(length1 >= 0 && length1 <= array1.Length);
            Debug.Assert(length2 >= 0 && length2 <= array2.Length);

            var result = new T[length1 + length2];
            new ReadOnlySpan<T>(array1, 0, length1).CopyTo(new Span<T>(result, 0, length1));
            new ReadOnlySpan<T>(array2, 0, length2).CopyTo(new Span<T>(result, length1, length2));
            return result;
        }
    }
}
