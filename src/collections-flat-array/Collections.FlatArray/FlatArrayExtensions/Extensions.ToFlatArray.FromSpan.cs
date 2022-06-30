using System.Collections.Generic;

namespace System.Linq;

partial class FlatArrayExtensions
{
    public static FlatArray<T> ToFlatArray<T>(this ReadOnlySpan<T> source)
        =>
        FlatArray<T>.From(source);

    public static FlatArray<T> ToFlatArray<T>(this Span<T> source)
        =>
        FlatArray<T>.From(source);
}
