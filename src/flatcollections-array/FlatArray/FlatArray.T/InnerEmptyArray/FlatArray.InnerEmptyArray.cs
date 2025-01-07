#pragma warning disable IDE0300 // Simplify collection initialization
#pragma warning disable CA1825 // Avoid zero-length array allocations

namespace System;

partial struct FlatArray<T>
{
    private static class InnerEmptyArray
    {
        // Intended for the inner use only, not to pass outside
        // Designed not to expose the inner state of the empty FlatArray and the Builder

        internal static readonly T[] Value = new T[0];
    }
}
