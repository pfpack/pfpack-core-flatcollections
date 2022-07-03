namespace System.Collections.Generic;

partial class FlatArray<T>
{
    public Enumerator GetEnumerator()
        =>
        new(items);

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
        =>
        InnerGetEnumeratorObject();

    IEnumerator IEnumerable.GetEnumerator()
        =>
        InnerGetEnumeratorObject();

    private IEnumerator<T> InnerGetEnumeratorObject()
        =>
        items.Length > 0 ? new InnerEnumeratorObject(items) : InnerEnumeratorObjectEmptyDefault.Value;

    private static class InnerEnumeratorObjectEmptyDefault
    {
        internal static readonly InnerEnumeratorObjectEmpty Value = new();
    }
}
