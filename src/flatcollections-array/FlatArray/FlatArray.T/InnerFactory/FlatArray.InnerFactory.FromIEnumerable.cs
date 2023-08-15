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

            var initialCapacity = InnerAllocHelper.EnsurePositiveCapacity(estimatedCapacity);

            var array = new T[initialCapacity];
            array[0] = enumerator.Current;
            var actualCount = 1;

            while (enumerator.MoveNext())
            {
                if (actualCount == array.Length)
                {
                    InnerBufferHelper.EnlargeBuffer(ref array);
                }

                array[actualCount++] = enumerator.Current;
            }

            return new(actualCount, array);
        }
    }
}
