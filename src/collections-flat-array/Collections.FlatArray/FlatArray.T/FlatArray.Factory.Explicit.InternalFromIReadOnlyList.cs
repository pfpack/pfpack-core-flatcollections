using System.Collections.Immutable;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    internal static FlatArray<T> InternalFromIReadOnlyList(IReadOnlyList<T> source)
        =>
        source switch
        {
            ImmutableArray<T> immutableArray
            =>
            InternalFromImmutableArray(immutableArray),

            _ =>
            InnerFromIReadOnlyList(source)
        };
}
