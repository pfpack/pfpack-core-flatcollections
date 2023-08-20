using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    public static FlatArray<T> From([AllowNull] List<T> source)
        =>
        source is null ? default : InnerFactory.FromList(source);

    // TODO: Add the tests and make public
    internal static FlatArray<T> From([AllowNull] List<T> source, int length)
        =>
        InternalFromListChecked(source, length);

    internal static FlatArray<T> InternalFromListChecked(
        [AllowNull] List<T> source, int length, [CallerArgumentExpression(nameof(length))] string lengthParamName = "")
    {
        var actualLength = source?.Count ?? default;

        if (InnerAllocHelper.IsWithin(length, actualLength) is not true)
        {
            throw InnerExceptionFactory.StartSegmentLengthOutOfArrayLength(lengthParamName, length, actualLength);
        }

        return source is null ? default : InnerFactory.FromList(source, length);
    }
}
