using System.Diagnostics.CodeAnalysis;

namespace System;

partial class FlatArray
{
    partial class Builder
    {
        public static FlatArray<T>.Builder From<T>([AllowNull] params T[] source)
            =>
            new(source);
    }
}
