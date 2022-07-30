using System.Collections.Generic;

namespace System.Linq;

partial class FlatArrayLinqExtensions
{
    public static T Single<T>(this FlatArray<T> source)
    {
        _ = source ?? throw new ArgumentNullException(nameof(source));

        return source.Length switch
        {
            1 => source[0],
            > 1 => throw InnerExceptionFactory.SourceMoreThanOneElement(),
            _ => throw InnerExceptionFactory.SourceEmpty()
        };
    }

    public static T SingleOrDefault<T>(this FlatArray<T> source)
    {
        _ = source ?? throw new ArgumentNullException(nameof(source));

        return source.Length switch
        {
            1 => source[0],
            > 1 => throw InnerExceptionFactory.SourceMoreThanOneElement(),
            _ => default!
        };
    }
}
