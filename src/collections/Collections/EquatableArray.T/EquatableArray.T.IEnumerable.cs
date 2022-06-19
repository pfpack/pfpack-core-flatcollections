namespace System.Collections.Generic;

partial class EquatableArray<T>
{
    public IEnumerator<T> GetEnumerator()
        =>
        ((IEnumerable<T>)items).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        =>
        items.GetEnumerator();
}
