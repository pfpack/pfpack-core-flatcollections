using System.Collections.Generic;

namespace System.Linq;

partial class FlatArrayExtensions
{
    // Overload standard Linq extensions to avoid redundant enumeration

    public static T Last<T>(this FlatArray<T> source)
    {
        _ = source ?? throw new ArgumentNullException(nameof(source));

        return source.Length > 0
            ? source[^1]
            : throw new InvalidOperationException(InnerLinqExceptionMessages.SourceEmpty);
    }

    public static T LastOrDefault<T>(this FlatArray<T> source)
    {
        _ = source ?? throw new ArgumentNullException(nameof(source));

        return source.Length > 0
            ? source[^1]
            : default!;
    }
}
