namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    public ReadOnlySpan<T> AsSpan()
        =>
        InnerAsSpan();

    public ReadOnlyMemory<T> AsMemory()
        =>
        InnerAsMemory();
}
