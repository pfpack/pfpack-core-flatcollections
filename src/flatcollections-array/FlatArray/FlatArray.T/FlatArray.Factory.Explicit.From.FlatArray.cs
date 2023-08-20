using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    public static FlatArray<T> From(FlatArray<T> source)
        =>
        InnerFactory.FromFlatArray(source);

    // TODO: Add the tests and make public
    internal static FlatArray<T> From(FlatArray<T> source, int length)
        =>
        InternalFromFlatArrayChecked(source, length);

    public static FlatArray<T> From(FlatArray<T>? source)
        =>
        InnerFactory.FromFlatArray(source.GetValueOrDefault());

    // TODO: Add the tests and make public
    internal static FlatArray<T> From(FlatArray<T>? source, int length)
        =>
        InternalFromFlatArrayChecked(source.GetValueOrDefault(), length);

    internal static FlatArray<T> InternalFromFlatArrayChecked(
        FlatArray<T> source, int length, [CallerArgumentExpression(nameof(length))] string lengthParamName = "")
    {
        if (InnerAllocHelper.IsWithin(length, source.length) is not true)
        {
            throw InnerExceptionFactory.StartSegmentLengthOutOfArrayLength(lengthParamName, length, source.length);
        }

        return InnerFactory.FromFlatArray(source, length);
    }
}
