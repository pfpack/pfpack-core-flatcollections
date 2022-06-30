namespace System.Collections.Generic;

partial class FlatArray<T>
{
    public IEnumerator<T> GetEnumerator()
        =>
        items.Length > 0 ? new InnerEnumerator(items) : InnerEnumeratorEmpty.Value;

    IEnumerator IEnumerable.GetEnumerator()
        =>
        GetEnumerator();
}
