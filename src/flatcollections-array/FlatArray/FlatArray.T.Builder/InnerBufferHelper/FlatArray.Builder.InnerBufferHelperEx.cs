using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        private static class InnerBufferHelperEx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static void EnsureBufferCapacity(
                ref T[] array,
                int length,
                int lengthIncrease)
            {
                Debug.Assert(length >= 0);
                Debug.Assert(lengthIncrease >= 0);

                int newLength = unchecked(length + lengthIncrease);
                int doubleLength = InnerAllocHelper.DoubleUnchecked(length);
                int newCapacity = InnerAllocHelper.IsWithinCapacityUnchecked(doubleLength, newLength)
                    ? newLength
                    : doubleLength;

                if (newCapacity < 0)
                {
                    throw new InvalidOperationException(
                        "The required capacity exceeds the maximum size and the buffer cannot be enlarged.");
                }

                if (newCapacity < array.Length)
                {
                    return;
                }

                Array.Resize(ref array, newCapacity);
            }
        }
    }
}
