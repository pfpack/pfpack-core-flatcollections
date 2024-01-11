namespace System;

partial class FlatArray
{
    public static FlatArray<T> CastUp<T, TDerived>(FlatArray<TDerived> items)
        where TDerived : class?, T
        =>
        FlatArray<T>.CastUp(items);
}
