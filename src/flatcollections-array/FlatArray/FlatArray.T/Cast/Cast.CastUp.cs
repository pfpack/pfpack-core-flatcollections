namespace System;

partial struct FlatArray<T>
{
    public static FlatArray<T> CastUp<TDerived>(FlatArray<TDerived> array)
        where TDerived : class?, T
        =>
        array.length == default ? default : new(array.length, array.items!);
}
