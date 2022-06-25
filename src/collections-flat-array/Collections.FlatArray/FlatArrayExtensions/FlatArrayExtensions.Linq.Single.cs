using System.Collections.Generic;

namespace System.Linq;

partial class FlatArrayExtensions
{
    // Overload standard Linq extensions to avoid redundant enumeration

    public static T Single<T>(this FlatArray<T> source)
    {
        _ = source ?? throw new ArgumentNullException(nameof(source));

        return source.Length switch
        {
            1 => source[0],
            > 1 => throw new InvalidOperationException(InnerLinqExceptionMessages.SourceMoreThanOneElement),
            _ => throw new InvalidOperationException(InnerLinqExceptionMessages.SourceEmpty)
        };
    }

    public static T SingleOrDefault<T>(this FlatArray<T> source)
    {
        _ = source ?? throw new ArgumentNullException(nameof(source));

        return source.Length switch
        {
            1 => source[0],
            > 1 => throw new InvalidOperationException(InnerLinqExceptionMessages.SourceMoreThanOneElement),
            _ => default!
        };
    }
}
