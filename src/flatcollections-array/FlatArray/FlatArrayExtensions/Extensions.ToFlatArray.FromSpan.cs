namespace System;

partial class FlatArrayExtensions
{
    public static FlatArray<T> ToFlatArray<T>(this ReadOnlySpan<T> source)
        =>
        new(source);

    public static FlatArray<T> ToFlatArray<T>(this Span<T> source)
        =>
        new(source);
}
