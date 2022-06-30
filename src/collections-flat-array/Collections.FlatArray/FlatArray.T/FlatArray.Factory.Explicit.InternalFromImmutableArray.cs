using System.Collections.Immutable;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    internal static FlatArray<T> InternalFromImmutableArray(ImmutableArray<T> source)
    {
        if (source.IsDefault)
        {
            return InnerEmptyFlatArray.Value;
        }

        var count = source.Length;
        if (count is not > 0)
        {
            return InnerEmptyFlatArray.Value;
        }

        var array = new T[count];
        source.CopyTo(array, 0);

        // Clone for the safety purposes
        return new(InnerCloneArray(array), default);
    }
}
