using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    partial class InternalFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FlatArray<T> InnerFrom_ICollection(ICollection<T> source)
        {
            var count = source.Count;
            if (count is not > 0)
            {
                return InnerEmptyFlatArray.Value;
            }

            var array = new T[count];
            source.CopyTo(array, 0);

            // Make a defensive copy:
            // Cannot trust that any collection implementation (e.g., not as trusted as List or ImmutableArray)
            // does not keep a reference to the array passed in CopyTo and does not mutate it

            return new(InnerArrayHelper.Clone(array), default);
        }
    }
}
