using System.Collections.Generic;

namespace System.Linq;

partial class FlatArrayLinqExtensions
{
    public static T First<T>(this FlatArray<T> source)
        =>
        source.IsNotEmpty
            ? source[0]
            : throw InnerExceptionFactory.SourceEmpty();

    public static T? FirstOrDefault<T>(this FlatArray<T> source)
        =>
        source.IsNotEmpty
            ? source[0]
            : default;
}
