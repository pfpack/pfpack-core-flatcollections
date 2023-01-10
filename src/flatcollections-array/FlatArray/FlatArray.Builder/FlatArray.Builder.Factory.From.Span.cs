namespace System;

partial class FlatArray
{
    partial class Builder
    {
        public static FlatArray<T>.Builder From<T>(ReadOnlySpan<T> source)
            =>
            FlatArray<T>.Builder.From(source);

        public static FlatArray<T>.Builder From<T>(Span<T> source)
            =>
            FlatArray<T>.Builder.From(source);
    }
}
