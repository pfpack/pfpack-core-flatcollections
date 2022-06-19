using System.Collections.Generic;

namespace System.Collections.Immutable;

partial struct EquatableImmutableArray<T>
{
    int ICollection<T>.Count
        =>
        items.Length;

    bool ICollection<T>.IsReadOnly
        =>
        true;

    void ICollection<T>.Add(T item)
        =>
        throw ReadOnlyNotSupportedException();

    void ICollection<T>.Clear()
        =>
        throw ReadOnlyNotSupportedException();

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
        throw ReadOnlyNotSupportedException();
}
