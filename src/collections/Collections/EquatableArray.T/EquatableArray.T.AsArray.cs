namespace System.Collections.Generic;

partial class EquatableArray<T>
{
    public T[] AsArray()
        =>
        items;

    public static implicit operator T[](EquatableArray<T> array)
        =>
        (array ?? throw new ArgumentNullException(nameof(array)))
        .items;
}
