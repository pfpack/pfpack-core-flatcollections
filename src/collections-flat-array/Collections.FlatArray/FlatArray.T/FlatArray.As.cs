namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    public ReadOnlySpan<T> AsSpan()
        =>
        InnerIsNotEmpty ? new(items) : ReadOnlySpan<T>.Empty;

    public ReadOnlyMemory<T> AsMemory()
        =>
        InnerIsNotEmpty ? new(items) : ReadOnlyMemory<T>.Empty;
}
