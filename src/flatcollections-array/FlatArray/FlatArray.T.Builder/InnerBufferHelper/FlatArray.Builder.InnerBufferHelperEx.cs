using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        private static class InnerBufferHelperEx
        {
            // The caller MUST ensure the length and the length increase are GREATER than zero
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static void EnsureBufferCapacity(
                ref T[] array,
                int length,
                int lengthIncrease)
            {
                Debug.Assert(length >= 0);
                Debug.Assert(lengthIncrease >= 0);

                int newLength = unchecked(length + lengthIncrease);
                int doubleLength = length << 1; // unchecked(length * 2);
                int newCapacity = unchecked((uint)newLength) > unchecked((uint)doubleLength)
                    ? newLength
                    : doubleLength;

                if (newCapacity < 0)
                {
                    throw new InvalidOperationException();
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
