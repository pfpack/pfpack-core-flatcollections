using System.Collections.Generic;

namespace System.Collections.Immutable;

partial class FlatArray<T>
{
    public T[] ToArray()
        =>
        items.Length > 0 ? InnerCopyArray(items) : Array.Empty<T>();

    public List<T> ToList()
        =>
        items.Length > 0 ? new(InnerCopyArray(items)) : new();
}
