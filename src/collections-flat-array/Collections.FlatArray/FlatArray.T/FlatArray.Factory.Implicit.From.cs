using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    [return: MaybeNull, NotNullIfNotNull("source")]
    public static implicit operator FlatArray<T>([AllowNull] T[] source)
        =>
        source is null ? null : InternalFromArray(source);

    [return: MaybeNull, NotNullIfNotNull("source")]
    public static implicit operator FlatArray<T>([AllowNull] List<T> source)
        =>
        source is null ? null : InternalFromList(source);

    public static implicit operator FlatArray<T>(ImmutableArray<T> source)
        =>
        InternalFromImmutableArray(source);

    [return: NotNullIfNotNull("source")]
    public static implicit operator FlatArray<T>?(ImmutableArray<T>? source)
        =>
        source is null ? null : InternalFromImmutableArray(source.Value);
}
