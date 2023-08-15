namespace System;

partial struct FlatArray<T>
{
    private static class InnerEmptyArray
    {
        // Intended for the inner use only, not to pass outside
        // Designed to not expose the inner state of the empty FlatArray and the Builder

#pragma warning disable CA1825 // Avoid zero-length array allocations
        internal static readonly T[] Value = new T[0];
#pragma warning restore CA1825 // Avoid zero-length array allocations
    }
}
