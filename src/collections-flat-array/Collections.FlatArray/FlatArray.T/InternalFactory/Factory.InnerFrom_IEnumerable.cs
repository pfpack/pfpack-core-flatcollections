using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    partial class InternalFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FlatArray<T> InnerFrom_IEnumerable(IEnumerable<T> source, int estimatedCapacity = default)
        {
            using var enumerator = source.GetEnumerator();

            if (enumerator.MoveNext() is not true)
            {
                return InnerEmptyFlatArray.Value;
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int InnerEstimateCapacity(int size, int maxCapacity)
        {
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
