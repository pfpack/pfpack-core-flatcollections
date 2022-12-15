using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        // TODO: Make public when dynamic builder is implemented
        internal static Builder OfLength(int length, int capacity)
            =>
            InternalOfLength(length, capacity, nameof(length), nameof(capacity));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Builder InternalOfLength(
            int length, int capacity, string lengthParamName, string capacityParamName)
        {
            if (length is not >= 0)
            {
                throw InnerExceptionFactory.LengthOutOfRange(lengthParamName, length);
            }

            if (capacity >= length is not true)
            {
                throw InnerExceptionFactory.CapacityOutOfRange_MustBeGreaterThanOrEqualToLength(
                    capacityParamName, capacity, length: length);
            }

            return new(length, capacity: capacity);
        }
    }
}
