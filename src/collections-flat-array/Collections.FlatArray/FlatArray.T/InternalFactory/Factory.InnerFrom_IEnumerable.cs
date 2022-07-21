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

            if (enumerator.MoveNext() is false)
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
                else if (actualCount < InnerMaxLength.Value)
                {
                    int newCapacity = InnerComputeNewCapacity(array.Length, InnerMaxLength.Value);
                    InnerArrayHelper.ExtendUnchecked(ref array, newCapacity);
                    array[actualCount++] = enumerator.Current;
                }
                else
                {
                    throw new OutOfMemoryException(InnerExceptionMessages.SourceTooLarge);
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
        private static int InnerComputeNewCapacity(int currentSize, int maxCapacity)
        {
            int newCapacity = unchecked(currentSize * 2);

            return unchecked((uint)newCapacity) <= (uint)maxCapacity
                ? newCapacity
                : maxCapacity;
        }
    }
}
