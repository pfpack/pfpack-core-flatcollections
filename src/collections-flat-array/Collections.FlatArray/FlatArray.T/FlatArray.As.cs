namespace System.Collections.Generic;

partial class FlatArray<T>
{
    public ReadOnlySpan<T> AsSpan()
        =>
        new(items);

    public ReadOnlyMemory<T> AsMemory()
        =>
        new(items);
}
