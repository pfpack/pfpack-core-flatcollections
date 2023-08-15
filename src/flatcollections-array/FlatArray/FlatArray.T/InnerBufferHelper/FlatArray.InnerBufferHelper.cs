using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    internal static class InnerBufferHelper
    {
        // The caller MUST ensure the array length is GREATER than zero
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void EnlargeBuffer(ref T[] array)
        {
            Debug.Assert(array.Length > 0);

            int newLength = InnerEnlargeLength(array.Length);
            Array.Resize(ref array, newLength);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int InnerEnlargeLength(int length)
        {
            Debug.Assert(length > 0);

            if (length < Array.MaxLength)
            {
                return InnerAllocHelper.EnlargeCapacity(length, Array.MaxLength);
            }

            if (length != int.MaxValue)
            {
                // Delegate throwing OutOfMemoryException to the runtime when a new array is being allocated
                return length + 1;
            }

            throw new InvalidOperationException("The buffer has the maximum size and cannot be enlarged.");
        }
    }
}
