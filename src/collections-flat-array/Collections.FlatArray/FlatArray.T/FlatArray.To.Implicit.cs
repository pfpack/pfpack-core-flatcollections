using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    public static implicit operator T[]([AllowNull] FlatArray<T> flat)
        =>
        flat is not null ? flat.ToArray() : Array.Empty<T>();

    public static implicit operator List<T>([AllowNull] FlatArray<T> flat)
        =>
        flat is not null ? flat.ToList() : new();
}
