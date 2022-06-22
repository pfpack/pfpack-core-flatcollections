namespace System.Collections.Generic;

partial class FlatArray<T>
{
    private static class InnerEmptyFlatArray
    {
        internal static readonly FlatArray<T> Value = new();
    }
}
