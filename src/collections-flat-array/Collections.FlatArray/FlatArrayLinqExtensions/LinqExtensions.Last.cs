using System.Collections.Generic;

namespace System.Linq;

partial class FlatArrayLinqExtensions
{
    public static T Last<T>(this FlatArray<T> source)
        =>
        source.IsNotEmpty
            ? source[^1]
            : throw InnerExceptionFactory.SourceEmpty();

    public static T? LastOrDefault<T>(this FlatArray<T> source)
        =>
        source.IsNotEmpty
            ? source[^1]
            : default;
}
