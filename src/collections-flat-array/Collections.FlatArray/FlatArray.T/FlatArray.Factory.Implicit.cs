using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    public static implicit operator FlatArray<T>([AllowNull] T[] source)
        =>
        new(source);

    public static implicit operator FlatArray<T>([AllowNull] List<T> source)
        =>
        new(source);
}
