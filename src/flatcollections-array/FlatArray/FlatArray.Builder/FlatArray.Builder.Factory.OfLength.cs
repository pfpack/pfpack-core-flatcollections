namespace System;

partial class FlatArray
{
    partial class Builder
    {
        public static FlatArray<T>.Builder OfLength<T>(int length)
            =>
            FlatArray<T>.Builder.InternalOfLength(length, nameof(length));
    }
}
