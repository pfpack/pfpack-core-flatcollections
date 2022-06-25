using System.Collections.Generic;

namespace System.Linq;

partial class FlatArrayExtensions
{
    // Overload standard Linq extensions to avoid redundant enumeration

    public static int Count<T>(this FlatArray<T> source)
    {
        _ = source ?? throw new ArgumentNullException(nameof(source));

        return source.Length;
    }
}
