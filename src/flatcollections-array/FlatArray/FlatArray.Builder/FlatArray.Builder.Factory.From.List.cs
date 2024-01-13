using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System;

partial class FlatArray
{
    partial class Builder
    {
        public static FlatArray<T>.Builder From<T>([AllowNull] List<T> source)
            =>
            FlatArray<T>.Builder.From(source);
    }
}
