using System.Collections.Generic;

namespace System.Linq;

partial class FlatArrayLinqExtensions
{
    public static T Single<T>(this FlatArray<T> source)
        =>
        source.Length switch
        {
            1 => source[0],
            0 => throw InnerExceptionFactory.SourceEmpty(),
            _ => throw InnerExceptionFactory.SourceMoreThanOneElement(),
        };

    public static T? SingleOrDefault<T>(this FlatArray<T> source)
        =>
        source.Length switch
        {
            1 => source[0],
            0 => default,
            _ => throw InnerExceptionFactory.SourceMoreThanOneElement(),
        };
}
