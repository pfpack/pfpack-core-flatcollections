namespace System.Collections.Generic;

partial class FlatArray<T>
{
    public static FlatArray<T> From(ReadOnlySpan<T> source)
        =>
        source.Length > 0 ? new(source.ToArray(), default) : InnerEmptyFlatArray.Value;

    public static FlatArray<T> From(Span<T> source)
        =>
        From((ReadOnlySpan<T>)source);
}
