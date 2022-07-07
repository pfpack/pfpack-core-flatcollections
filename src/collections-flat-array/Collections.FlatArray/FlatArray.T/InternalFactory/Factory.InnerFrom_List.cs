using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    partial class InternalFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FlatArray<T> InnerFrom_List(List<T> source)
        {
            var count = source.Count;
            if (count is not > 0)
            {
                return InnerEmptyFlatArray.Value;
            }

            var array = new T[count];
            source.CopyTo(array, 0);

            return new(array, default);
        }
    }
}
