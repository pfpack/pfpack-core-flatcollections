namespace System.Collections.Generic;

partial class EquatableArray<T>
{
    public static EquatableArray<T> From(params T[] items)
        =>
        new(items ?? throw new ArgumentNullException(nameof(items)));

    public static implicit operator EquatableArray<T>(T[] items)
        =>
        new(items ?? throw new ArgumentNullException(nameof(items)));
}
