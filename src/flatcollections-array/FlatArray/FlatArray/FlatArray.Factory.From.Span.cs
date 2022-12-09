namespace System;

partial class FlatArray
{
    public static FlatArray<T> From<T>(ReadOnlySpan<T> source)
        =>
        FlatArray<T>.From(source);

    public static FlatArray<T> From<T>(Span<T> source)
        =>
        FlatArray<T>.From(source);
}
