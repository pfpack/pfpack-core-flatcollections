using System.Collections.Immutable;

namespace System;

partial class FlatArray
{
    partial class Builder
    {
        public static FlatArray<T>.Builder From<T>(ImmutableArray<T> source)
            =>
            FlatArray<T>.Builder.From(source);

        public static FlatArray<T>.Builder From<T>(ImmutableArray<T>? source)
            =>
            FlatArray<T>.Builder.From(source);
    }
}
