using System.Diagnostics;

namespace System;

partial struct FlatArray<T>
{
    // Initializes an instance without creation of a defensive copy
    // When the input array is empty, the default is returned
    internal static FlatArray<T> InternalCreateOrDefault(T[] items)
    {
        Debug.Assert(items is not null);

        if (items.Length == default)
        {
            return default;
        }

        return new(items, default);
    }
}
