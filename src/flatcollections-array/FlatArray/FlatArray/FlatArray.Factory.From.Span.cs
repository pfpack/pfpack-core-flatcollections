namespace System;

partial class FlatArray
{
    public static FlatArray<T> From<T>(ReadOnlySpan<T> source)
        =>
        new(source);

    public static FlatArray<T> From<T>(Span<T> source)
        =>
        new(source);
}
