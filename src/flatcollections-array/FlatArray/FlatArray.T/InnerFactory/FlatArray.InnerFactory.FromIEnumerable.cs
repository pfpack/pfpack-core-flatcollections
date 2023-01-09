using System.Collections.Generic;
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

            var array = new T[InnerAllocHelper.EnsurePositiveCapacity(estimatedCapacity)];
            array[0] = enumerator.Current;
            int actualCount = 1;

            while (enumerator.MoveNext())
            {
                if (actualCount == array.Length)
                {
                    int newCapacity = array.Length < Array.MaxLength
                        ? InnerAllocHelper.IncreaseCapacity(array.Length, Array.MaxLength)
                        : throw InnerExceptionFactory.SourceTooLarge();

                    InnerArrayHelper.ExtendUnchecked(ref array, newCapacity);
                }

                array[actualCount++] = enumerator.Current;
            }

            if (actualCount < array.Length)
            {
                InnerArrayHelper.TruncateUnchecked(ref array, actualCount);
            }

            return new(array, default);
        }
    }
}
