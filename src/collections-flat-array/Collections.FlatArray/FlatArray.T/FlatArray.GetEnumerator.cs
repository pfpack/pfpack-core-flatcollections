namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    public Enumerator GetEnumerator()
        =>
        new(InnerIsNotEmpty ? new ReadOnlySpan<T>(items) : ReadOnlySpan<T>.Empty);

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
        =>
        InnerGetEnumeratorObject();

    IEnumerator IEnumerable.GetEnumerator()
        =>
        InnerGetEnumeratorObject();

    private IEnumerator<T> InnerGetEnumeratorObject()
        =>
        InnerIsNotEmpty ? new InnerEnumeratorObject(items) : InnerEnumeratorObjectEmptyDefault.Value;

    private static class InnerEnumeratorObjectEmptyDefault
    {
        internal static readonly InnerEnumeratorObjectEmpty Value = new();
    }
}
