namespace System.Collections.Generic;

partial class FlatArray<T>
{
    internal static FlatArray<T> InternalFromFlatArray(FlatArray<T> source)
        =>
        source.items.Length > 0 ? new(InnerCloneArray(source.items), default) : InnerEmptyFlatArray.Value;
}
