namespace System;

partial struct FlatArray<T>
{
    private static class InnerEmptyArray
    {
        // Intended for the inner use only, not to pass outside
        // Designed to avoid the extra generic instantiation for Array.Empty<T>()
        // and not to expose the inner state of an empty FlatArray<T>

#pragma warning disable CA1825 // Avoid zero-length array allocations
        internal static readonly T[] Value = new T[0];
#pragma warning restore CA1825 // Avoid zero-length array allocations

        // Intended to pass outside, not for the inner use
        // Designed to avoid the extra generic instantiation for Array.Empty<T>()

#pragma warning disable CA1825 // Avoid zero-length array allocations
        internal static readonly T[] OuterValue = new T[0];
#pragma warning restore CA1825 // Avoid zero-length array allocations
    }
}
