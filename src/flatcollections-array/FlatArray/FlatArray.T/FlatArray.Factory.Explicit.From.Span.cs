namespace System;

partial struct FlatArray<T>
{
    public static FlatArray<T> From(ReadOnlySpan<T> source)
        =>
        new(source);

    public static FlatArray<T> From(Span<T> source)
        =>
        new(source);
}
