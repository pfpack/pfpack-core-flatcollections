namespace System;

partial struct FlatArray<T>
{
    public ReadOnlySpan<T> AsSpan()
        =>
        InnerAsSpan();

    public ReadOnlyMemory<T> AsMemory()
        =>
        InnerAsMemory();
}
