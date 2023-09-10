namespace System;

partial class FlatArray
{
    public static FlatArray<T> From<T>(FlatArray<T> source)
        =>
        new(source);

    public static FlatArray<T> From<T>(FlatArray<T>? source)
        =>
        new(source);

    // TODO: Add the tests and make public
    internal static FlatArray<T> From<T>(FlatArray<T> source, int start, int length)
        =>
        FlatArray<T>.From(source, start, length);

    // TODO: Add the tests and make public
    internal static FlatArray<T> From<T>(FlatArray<T>? source, int start, int length)
        =>
        FlatArray<T>.From(source, start, length);
}
