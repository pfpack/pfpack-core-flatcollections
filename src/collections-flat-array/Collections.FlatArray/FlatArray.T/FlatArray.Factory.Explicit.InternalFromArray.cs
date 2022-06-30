namespace System.Collections.Generic;

partial class FlatArray<T>
{
    internal static FlatArray<T> InternalFromArray(T[] source)
        =>
        source.Length > 0 ? new(InnerCloneArray(source), default) : InnerEmptyFlatArray.Value;
}
