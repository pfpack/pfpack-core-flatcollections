namespace System.Collections.Generic;

partial class FlatArray<T>
{
    public Enumerator GetEnumerator()
        =>
        new(items);

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
        =>
        InnerCreateEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        =>
        InnerCreateEnumerator();

    private IEnumerator<T> InnerCreateEnumerator()
        =>
        items.Length > 0 ? new InnerEnumerator(items) : new InnerEnumeratorEmpty();
}
