using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    partial class InternalFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FlatArray<T> InnerFrom_IReadOnlyList(IReadOnlyList<T> source)
        {
            var count = source.Count;
            if (count is not > 0)
            {
                return InnerEmptyFlatArray.Value;
            }

            int actualCount = 0;
            var array = new T[count];

            do
            {
                if (actualCount < array.Length)
                {
                    array[actualCount] = source[actualCount];
                }
                else
                {
                    InnerArrayHelper.ExtendUnchecked(ref array, count);
                    array[actualCount] = source[actualCount];
                }
            }
            while (++actualCount < (count = source.Count));

            if (actualCount < array.Length)
            {
                InnerArrayHelper.TruncateUnchecked(ref array, actualCount);
            }

            return new(array, default);
        }
    }
}
