using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic;

partial class FlatArray
{
    partial class Builder
    {
        public static FlatArray<T>.Builder From<T>([AllowNull] params T[] source)
            =>
            FlatArray<T>.Builder.From(source);
    }
}
