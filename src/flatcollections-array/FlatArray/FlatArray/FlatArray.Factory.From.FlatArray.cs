namespace System;

partial class FlatArray
{
    public static FlatArray<T> From<T>(FlatArray<T> source)
        =>
        FlatArray<T>.From(source);

    // TODO: Add the tests and make public
    internal static FlatArray<T> From<T>(FlatArray<T> source, int start, int length)
        =>
        FlatArray<T>.InternalFromFlatArrayChecked(source, start, length);

    public static FlatArray<T> From<T>(FlatArray<T>? source)
        =>
        FlatArray<T>.From(source);

    // TODO: Add the tests and make public
    internal static FlatArray<T> From<T>(FlatArray<T>? source, int start, int length)
        =>
        FlatArray<T>.InternalFromFlatArrayChecked(source.GetValueOrDefault(), start, length);
}
