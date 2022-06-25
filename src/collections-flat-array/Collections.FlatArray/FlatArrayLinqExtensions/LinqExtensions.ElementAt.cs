using System.Collections.Generic;

namespace System.Linq;

partial class FlatArrayLinqExtensions
{
    public static T ElementAt<T>(this FlatArray<T> source, int index)
    {
        _ = source ?? throw new ArgumentNullException(nameof(source));

        // Delegate index checking to the indexer
        return source[index];
    }

    public static T ElementAt<T>(this FlatArray<T> source, Index index)
    {
        _ = source ?? throw new ArgumentNullException(nameof(source));

        // Delegate index checking to the indexer
        return source[index];
    }
}
