namespace System.Collections.Generic;

public static class EquatableArray
{
    public static EquatableArray<T> From<T>(params T[] items)
        =>
        new(items ?? throw new ArgumentNullException(nameof(items)));

    public static bool Equals<T>(EquatableArray<T>? left, EquatableArray<T>? right)
        =>
        EquatableArray<T>.Equals(left, right);
}
