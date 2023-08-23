namespace System;

partial class FlatArrayExtensions
{
    public static FlatArray<T> ToFlatArray<T>(this FlatArray<T> source)
        =>
        FlatArray<T>.From(source);

    public static FlatArray<T> ToFlatArray<T>(this FlatArray<T>? source)
        =>
        FlatArray<T>.From(source);
}
