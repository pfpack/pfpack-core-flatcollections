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
                : throw InnerExceptionFactory.SourceTooLarge();
                //: array.Length + 1; // Delegate throwing an exception to CLR

            InnerArrayHelper.ExtendUnchecked(ref array, newCapacity);
        }
    }
}
