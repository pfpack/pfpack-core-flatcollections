namespace System;

partial struct FlatArray<T>
{
    public static FlatArray<T> From(ReadOnlySpan<T> source)
        =>
        source.IsEmpty ? default : new(source.ToArray(), default);

    public static FlatArray<T> From(Span<T> source)
        =>
        source.IsEmpty ? default : new(source.ToArray(), default);
}
