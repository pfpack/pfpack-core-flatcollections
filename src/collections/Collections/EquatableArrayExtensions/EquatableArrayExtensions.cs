namespace System.Collections.Generic;

public static class EquatableArrayExtensions
{
    public static EquatableArray<T> AsEquatable<T>(this T[] items)
        =>
        new(items ?? throw new ArgumentNullException(nameof(items)));
}
