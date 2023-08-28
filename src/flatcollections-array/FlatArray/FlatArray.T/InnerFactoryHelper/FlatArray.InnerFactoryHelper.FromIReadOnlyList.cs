using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class InnerFactoryHelper
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
            var actualCount = 1;

            while (actualCount < (count = source.Count))
            {
                if (actualCount == array.Length)
                {
                    Array.Resize(ref array, count);
                }

                array[actualCount] = source[actualCount];
                actualCount++;
            }

            return new(actualCount, array);
        }
    }
}
