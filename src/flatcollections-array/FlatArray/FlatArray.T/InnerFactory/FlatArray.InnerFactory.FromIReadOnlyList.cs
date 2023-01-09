using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class InnerFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static FlatArray<T> FromIReadOnlyList(IReadOnlyList<T> source)
        {
            var count = source.Count;
            if (count is not > 0)
            {
                return default;
            }

            var array = new T[count];
            array[0] = source[0];
            int actualCount = 1;

            while (actualCount < (count = source.Count))
            {
                if (actualCount == array.Length)
                {
                    InnerArrayHelper.ExtendUnchecked(ref array, count);
                }

                array[actualCount] = source[actualCount];
                actualCount++;
            }

            if (actualCount < array.Length)
            {
                InnerArrayHelper.TruncateUnchecked(ref array, actualCount);
            }

            return new(array, default);
        }
    }
}
