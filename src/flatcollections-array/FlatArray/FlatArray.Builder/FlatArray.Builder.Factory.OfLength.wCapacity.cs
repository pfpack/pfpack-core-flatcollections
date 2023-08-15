namespace System;

partial class FlatArray
{
    partial class Builder
    {
        // TODO: Add the tests and make public
        internal static FlatArray<T>.Builder OfLength<T>(int length, int capacity)
            =>
            FlatArray<T>.Builder.InternalOfLength(
                length, capacity, nameof(length), nameof(capacity));
    }
}
