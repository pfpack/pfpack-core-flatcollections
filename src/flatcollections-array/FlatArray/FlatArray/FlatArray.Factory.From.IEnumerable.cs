using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System;

partial class FlatArray
{
    public static FlatArray<T> From<T>([AllowNull] IEnumerable<T> source)
        =>
        FlatArray<T>.From(source);
}
