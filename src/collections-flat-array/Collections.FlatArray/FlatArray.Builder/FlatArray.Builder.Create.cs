namespace System.Collections.Generic;

partial class FlatArray
{
    partial class Builder
    {
        public static FlatArray<T>.Builder Create<T>(int length)
            =>
            FlatArray<T>.Builder.InternalCreate(length);
    }
}
