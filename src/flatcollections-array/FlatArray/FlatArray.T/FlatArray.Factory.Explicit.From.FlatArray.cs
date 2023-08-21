namespace System;

partial struct FlatArray<T>
{
    public static FlatArray<T> From(FlatArray<T> source)
        =>
        InnerFactory.FromFlatArray(source);

    // TODO: Add the tests and make public
    internal static FlatArray<T> From(FlatArray<T> source, int start, int length)
        =>
        InternalFromFlatArrayChecked(source, start, length);

    public static FlatArray<T> From(FlatArray<T>? source)
        =>
        InnerFactory.FromFlatArray(source.GetValueOrDefault());

    // TODO: Add the tests and make public
    internal static FlatArray<T> From(FlatArray<T>? source, int start, int length)
        =>
        InternalFromFlatArrayChecked(source.GetValueOrDefault(), start, length);

    internal static FlatArray<T> InternalFromFlatArrayChecked(FlatArray<T> source, int start, int length)
    {
        if (InnerAllocHelper.IsSegmentWithin(start, length, source.length) is not true)
        {
            throw InnerExceptionFactory.SegmentIsNotWithinArray(start, length, source.length);
        }

        return InnerFactory.FromFlatArray(source, start, length);
    }
}
