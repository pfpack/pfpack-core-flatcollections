using System.Collections.Immutable;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    public static implicit operator T[](FlatArray<T> flatArray)
        =>
        flatArray.ToArray();

    public static implicit operator List<T>(FlatArray<T> flatArray)
        =>
        flatArray.ToList();

    public static implicit operator ImmutableArray<T>(FlatArray<T> flatArray)
        =>
        flatArray.ToImmutableArray();
}
