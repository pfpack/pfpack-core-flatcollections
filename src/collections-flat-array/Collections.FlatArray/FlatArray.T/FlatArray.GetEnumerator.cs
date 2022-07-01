namespace System.Collections.Generic;

partial class FlatArray<T>
{
    public Enumerator GetEnumerator()
        =>
        new(items);

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
        =>
        InnerGetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        =>
        InnerGetEnumerator();

    private IEnumerator<T> InnerGetEnumerator()
        =>
        items.Length > 0 ? new InnerEnumerator(items) : InnerEnumeratorEmptyDefault.Value;

    private static class InnerEnumeratorEmptyDefault
    {
        internal static readonly InnerEnumeratorEmpty Value = new();
    }
}
