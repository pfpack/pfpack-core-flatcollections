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
}
