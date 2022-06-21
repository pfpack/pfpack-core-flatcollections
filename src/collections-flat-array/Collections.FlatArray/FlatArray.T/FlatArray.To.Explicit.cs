namespace System.Collections.Generic;

partial class FlatArray<T>
{
    public T[] ToArray()
        =>
        items.Length > 0 ? InnerCloneArray(items) : Array.Empty<T>();

    public List<T> ToList()
        =>
        items.Length > 0 ? new(InnerCloneArray(items)) : new();
}
