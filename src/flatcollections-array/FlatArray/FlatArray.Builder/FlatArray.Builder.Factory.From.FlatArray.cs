namespace System;

partial class FlatArray
{
    partial class Builder
    {
        public static FlatArray<T>.Builder From<T>(FlatArray<T> source)
            =>
            FlatArray<T>.Builder.From(source);

        public static FlatArray<T>.Builder From<T>(FlatArray<T>? source)
            =>
            FlatArray<T>.Builder.From(source);
    }
}
