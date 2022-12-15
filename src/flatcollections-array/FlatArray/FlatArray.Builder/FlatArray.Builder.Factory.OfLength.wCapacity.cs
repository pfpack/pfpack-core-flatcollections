namespace System;

partial class FlatArray
{
    partial class Builder
    {
        // TODO: Make public when dynamic builder is implemented
        internal static FlatArray<T>.Builder OfLength<T>(int length, int capacity)
            =>
            FlatArray<T>.Builder.InternalOfLength(
                length, capacity, nameof(length), nameof(capacity));
    }
}
