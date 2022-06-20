using System.Collections.Generic;

namespace System.Collections.Immutable;

partial class FlatArray<T>
{
    public T[] ToArray()
        =>
        items.Length > 0 ? InnerArrayHelper.Copy(items) : Array.Empty<T>();

    public List<T> ToList()
        =>
        new(InnerArrayHelper.Copy(items));
}
