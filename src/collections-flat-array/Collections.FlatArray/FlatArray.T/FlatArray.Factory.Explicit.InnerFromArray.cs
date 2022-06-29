namespace System.Collections.Generic;

partial class FlatArray<T>
{
    private static FlatArray<T> InnerFromArray(T[] source)
        =>
        source.Length > 0 ? new(InnerCloneArray(source), default) : InnerEmptyFlatArray.Value;
}
