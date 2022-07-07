namespace System.Collections.Generic;

partial class FlatArray<T>
{
    public static FlatArray<T> Empty
        =>
        InnerEmptyFlatArray.Value;
}
