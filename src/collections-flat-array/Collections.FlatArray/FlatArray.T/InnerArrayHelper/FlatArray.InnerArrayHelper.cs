using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    private static class InnerArrayHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T[] Clone(T[] source)
        {
            var dest = new T[source.Length];
            Array.Copy(source, dest, source.Length);
            return dest;
        }

        // The caller MUST ensure the new size is GREATER than the source size
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ExtendUnchecked(ref T[] array, int newSize)
        {
            Debug.Assert(newSize > array.Length);

            var newArray = new T[newSize];
            Array.Copy(array, newArray, array.Length);
            array = newArray;
        }

        // The caller MUST ensure the new size is LESS than the source size
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void TruncateUnchecked(ref T[] array, int newSize)
        {
            Debug.Assert(newSize >= 0 && newSize < array.Length);

            var newArray = new T[newSize];
            Array.Copy(array, newArray, newArray.Length);
            array = newArray;
        }
    }
}
