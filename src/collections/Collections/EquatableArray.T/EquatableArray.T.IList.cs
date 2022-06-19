namespace System.Collections.Generic;

partial class EquatableArray<T>
{
    int IList<T>.IndexOf(T item)
        =>
        ((IList<T>)items).IndexOf(item);

    void IList<T>.Insert(int index, T item)
        =>
        throw FixedSizeNotSupportedException();

    void IList<T>.RemoveAt(int index)
        =>
        throw FixedSizeNotSupportedException();
}
