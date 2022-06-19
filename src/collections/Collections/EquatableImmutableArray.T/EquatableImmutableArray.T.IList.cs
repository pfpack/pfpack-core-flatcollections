using System.Collections.Generic;

namespace System.Collections.Immutable;

partial struct EquatableImmutableArray<T>
{
    T IList<T>.this[int index]
    {
        get => items[index];
        set => throw ReadOnlyNotSupportedException();
    }

    int IList<T>.IndexOf(T item)
        =>
        ((IList<T>)items).IndexOf(item);

    void IList<T>.Insert(int index, T item)
        =>
        throw ReadOnlyNotSupportedException();

    void IList<T>.RemoveAt(int index)
        =>
        throw ReadOnlyNotSupportedException();
}
