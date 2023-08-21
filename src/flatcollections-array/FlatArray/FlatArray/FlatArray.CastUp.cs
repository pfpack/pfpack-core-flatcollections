namespace System;

partial class FlatArray
{
    // TODO: Add the tests and make public
    internal static FlatArray<T> CastUp<T, TDerived>(FlatArray<TDerived> items) where TDerived : class?, T
        =>
        FlatArray<T>.CastUp(items);
}
