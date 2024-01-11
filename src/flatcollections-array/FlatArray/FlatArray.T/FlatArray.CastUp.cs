namespace System;

partial struct FlatArray<T>
{
    // TODO: Add the tests and make public
    internal static FlatArray<T> CastUp<TDerived>(FlatArray<TDerived> items)
        where TDerived : class?, T
        =>
        new(items.length, items.items, default);
}
