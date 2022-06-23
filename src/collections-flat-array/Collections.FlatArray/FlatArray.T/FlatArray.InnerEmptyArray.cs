namespace System.Collections.Generic;

partial class FlatArray<T>
{
    // Intended for the inner use only, not intended to pass outside
    // Designed to avoid the inner use of the global Array.Empty<T>() instance
    private static class InnerEmptyArray
    {
#pragma warning disable CA1825 // Avoid zero-length array allocations
        internal static readonly T[] Value = new T[0];
#pragma warning restore CA1825 // Avoid zero-length array allocations
    }
}
