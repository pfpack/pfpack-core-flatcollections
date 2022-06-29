namespace System.Collections.Generic;

partial class FlatArray<T>
{
    private static FlatArray<T> InnerFromFlatArray(FlatArray<T> source)
        =>
        source.items.Length > 0 ? new(InnerCloneArray(source.items), default) : InnerEmptyFlatArray.Value;
}
