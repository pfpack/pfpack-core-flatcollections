namespace System.Collections.Generic;

partial class FlatArray<T>
{
    public static implicit operator T[](FlatArray<T> flatArray)
        =>
        (flatArray ?? throw new ArgumentNullException(nameof(flatArray)))
        .ToArray();

    public static implicit operator List<T>(FlatArray<T> flatArray)
        =>
        (flatArray ?? throw new ArgumentNullException(nameof(flatArray)))
        .ToList();
}
