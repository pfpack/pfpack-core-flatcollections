using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    [return: MaybeNull, NotNullIfNotNull("flatArray")]
    public static implicit operator T[]([AllowNull] FlatArray<T> flatArray)
        =>
        flatArray?.ToArray();

    [return: MaybeNull, NotNullIfNotNull("flatArray")]
    public static implicit operator List<T>([AllowNull] FlatArray<T> flatArray)
        =>
        flatArray?.ToList();

    public static implicit operator ImmutableArray<T>([AllowNull] FlatArray<T> flatArray)
        =>
        flatArray is not null ? flatArray.ToImmutableArray() : ImmutableArray<T>.Empty;

    [return: NotNullIfNotNull("flatArray")]
    public static implicit operator ImmutableArray<T>?(FlatArray<T>? flatArray)
        =>
        flatArray is not null ? flatArray.ToImmutableArray() : null;
}
