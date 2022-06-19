namespace System.Collections.Generic;

public static class EquatableArrayExtensions
{
    public static EquatableArray<T> AsEquatableArray<T>(this T[] items)
        =>
        new(items ?? throw new ArgumentNullException(nameof(items)));
}
