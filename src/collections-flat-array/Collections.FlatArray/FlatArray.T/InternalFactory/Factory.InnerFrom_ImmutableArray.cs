using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    partial class InternalFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FlatArray<T> InnerFrom_ImmutableArray(ImmutableArray<T> source)
        {
            if (source.IsDefault || source.Length is not > 0)
            {
                return InnerEmptyFlatArray.Value;
            }

            var array = new T[source.Length];
            source.CopyTo(array, 0);

            return new(array, default);
        }
    }
}
