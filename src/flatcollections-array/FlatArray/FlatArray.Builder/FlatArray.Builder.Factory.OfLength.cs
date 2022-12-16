namespace System;

partial class FlatArray
{
    partial class Builder
    {
        // TODO: Make public when the test is implemented
        internal static FlatArray<T>.Builder OfLength<T>(int length)
            =>
            FlatArray<T>.Builder.InternalOfLength(length, nameof(length));
    }
}
