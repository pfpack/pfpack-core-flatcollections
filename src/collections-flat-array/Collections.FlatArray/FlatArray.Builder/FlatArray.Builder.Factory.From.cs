﻿using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic;

partial class FlatArray
{
    partial class Builder
    {
        public static FlatArray<T>.Builder From<T>([AllowNull] params T[] source)
            =>
            FlatArray<T>.Builder.From(source);

        public static FlatArray<T>.Builder From<T>(FlatArray<T> source)
            =>
            FlatArray<T>.Builder.From(source);

        public static FlatArray<T>.Builder From<T>(FlatArray<T>? source)
            =>
            FlatArray<T>.Builder.From(source);

        public static FlatArray<T>.Builder From<T>([AllowNull] List<T> source)
            =>
            FlatArray<T>.Builder.From(source);

        public static FlatArray<T>.Builder From<T>(ImmutableArray<T> source)
            =>
            FlatArray<T>.Builder.From(source);

        public static FlatArray<T>.Builder From<T>(ImmutableArray<T>? source)
            =>
            FlatArray<T>.Builder.From(source);
    }
}
