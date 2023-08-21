using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    private static class InnerBufferHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void EnlargeBuffer(ref T[] array)
        {
            int newLength = InnerEnlargeLength(array.Length);
            Array.Resize(ref array, newLength);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int InnerEnlargeLength(int length)
        {
            if (length == default)
            {
                return InnerAllocHelper.DefaultPositiveCapacity;
            }

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
