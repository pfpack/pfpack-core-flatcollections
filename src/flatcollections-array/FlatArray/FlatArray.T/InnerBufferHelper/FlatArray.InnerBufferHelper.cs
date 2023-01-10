using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    internal static class InnerBufferHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void GrowBuffer(ref T[] array)
        {
            int newCapacity = array.Length < Array.MaxLength
                ? InnerAllocHelper.IncreaseCapacity(array.Length, Array.MaxLength)
                : checked(array.Length + 1); // Delegate throwing an exception to the runtime
                                             // when either a new array is being allocated
                                             // or a new capacity is being computed

            InnerArrayHelper.ExtendUnchecked(ref array, newCapacity);
        }
    }
}
