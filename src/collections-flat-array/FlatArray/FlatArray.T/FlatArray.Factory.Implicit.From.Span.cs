namespace System;

partial struct FlatArray<T>
{
    public static implicit operator FlatArray<T>(ReadOnlySpan<T> source)
        =>
        From(source);

    public static implicit operator FlatArray<T>(Span<T> source)
        =>
        From(source);
}
