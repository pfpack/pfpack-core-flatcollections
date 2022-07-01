using System.Collections.Immutable;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    internal static FlatArray<T> InternalFromImmutableArray(ImmutableArray<T> source)
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
