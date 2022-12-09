using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

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

        // The caller MUST ensure the size and the max capacity are GREATER than zero
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int InnerEstimateCapacity(int size, int maxCapacity)
        {
            Debug.Assert(size > 0);
            Debug.Assert(maxCapacity > 0);

            int capacity = unchecked(size * 2);

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
