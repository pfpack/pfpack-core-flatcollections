namespace System.Collections.Immutable;

partial class FlatArray<T>
{
    // To avoid inner use of the global empty instance
    private static class InnerEmptyArray
    {
#pragma warning disable CA1825 // Avoid zero-length array allocations
        internal static readonly T[] Value = new T[0];
#pragma warning restore CA1825 // Avoid zero-length array allocations
    }
}
