using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    public static FlatArray<T> From([AllowNull] params T[] source)
        =>
        source is null ? default : InnerFactory.FromArray(source);

    // TODO: Add the tests and make public
    internal static FlatArray<T> From([AllowNull] T[] source, int length)
        =>
        InternalFromArrayChecked(source, length);

    internal static FlatArray<T> InternalFromArrayChecked(
        [AllowNull] T[] source, int length, [CallerArgumentExpression(nameof(length))] string lengthParamName = "")
    {
        var actualLength = source?.Length ?? default;

        if (InnerAllocHelper.IsWithin(length, actualLength) is not true)
        {
            throw InnerExceptionFactory.StartSegmentLengthOutOfArrayLength(lengthParamName, length, actualLength);
        }

        return source is null ? default : InnerFactory.FromArray(source, length);
    }
}
