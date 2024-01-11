namespace System;

partial struct FlatArray<T>
{
    public static FlatArray<T> CastUp<TDerived>(FlatArray<TDerived> items)
        where TDerived : class?, T
        =>
        new(items.length, items.items, default);
}
