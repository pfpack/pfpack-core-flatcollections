namespace System.Collections.Generic;

partial class EquatableArray<T>
{
    int ICollection<T>.Count
        =>
        items.Length;

    bool ICollection<T>.IsReadOnly
        =>
        false;

    void ICollection<T>.Add(T item)
        =>
        throw FixedSizeNotSupportedException();

    void ICollection<T>.Clear()
        =>
        throw FixedSizeNotSupportedException();

    bool ICollection<T>.Contains(T item)
        =>
        ((ICollection<T>)items).Contains(item);

    void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        =>
        items.CopyTo(
            array ?? throw new ArgumentNullException(nameof(array)),
            arrayIndex);

    bool ICollection<T>.Remove(T item)
        =>
        throw FixedSizeNotSupportedException();
}
