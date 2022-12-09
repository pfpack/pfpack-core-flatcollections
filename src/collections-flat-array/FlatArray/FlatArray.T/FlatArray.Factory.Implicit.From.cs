using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace System;

partial struct FlatArray<T>
{
    public static implicit operator FlatArray<T>([AllowNull] T[] source)
        =>
        From(source);

    public static implicit operator FlatArray<T>([AllowNull] List<T> source)
        =>
        From(source);

    public static implicit operator FlatArray<T>(ImmutableArray<T> source)
        =>
        From(source);
}
