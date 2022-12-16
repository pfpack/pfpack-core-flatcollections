using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class InnerFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static FlatArray<T> FromIEnumerable(IEnumerable<T> source, int estimatedCapacity = default)
        {
            using var enumerator = source.GetEnumerator();

            if (enumerator.MoveNext() is not true)
            {
                return default;
            }

            const int defaultCapacity = 4;

            int actualCount = 0;
            var array = new T[estimatedCapacity > 0 ? estimatedCapacity : defaultCapacity];

            do
            {
                if (actualCount < array.Length)
                {
                    array[actualCount++] = enumerator.Current;
                }
                else if (actualCount < Array.MaxLength)
                {
                    int newCapacity = InnerEstimateCapacity(array.Length, Array.MaxLength);
                    InnerArrayHelper.ExtendUnchecked(ref array, newCapacity);
                    array[actualCount++] = enumerator.Current;
                }
                else
                {
                    throw InnerExceptionFactory.SourceTooLarge();
                }
            }
            while (enumerator.MoveNext());

            if (actualCount < array.Length)
            {
                InnerArrayHelper.TruncateUnchecked(ref array, actualCount);
            }

            return new(array, default);
        }

        // The caller MUST ensure the length is GREATER than zero
        // and the max capacity is NOT LESS than the length
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int InnerEstimateCapacity(int length, int maxCapacity)
        {
            Debug.Assert(length > 0);
            Debug.Assert(maxCapacity >= length);

            int capacity = unchecked(length * 2);

            if (capacity < 0) // handle the overflow case
            {
                return maxCapacity;
            }

            if (capacity > maxCapacity)
            {
                return maxCapacity;
            }

            return capacity;
        }
    }
}
