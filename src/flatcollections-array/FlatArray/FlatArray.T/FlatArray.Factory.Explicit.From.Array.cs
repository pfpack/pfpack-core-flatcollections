using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    public static FlatArray<T> From([AllowNull] params T[] source)
        =>
        source is null ? default : InnerFactory.FromArray(source);

    // TODO: Add the tests and make public
    internal static FlatArray<T> From([AllowNull] T[] source, int start, int length)
        =>
        InternalFromArrayChecked(source, start, length);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static FlatArray<T> InternalFromArrayChecked([AllowNull] T[] source, int start, int length)
    {
        var sourceLength = source?.Length ?? default;

        if (InnerAllocHelper.IsSegmentWithinLength(start, length, sourceLength) is not true)
        {
            throw InnerExceptionFactory.SegmentIsNotWithinArray(start, length, sourceLength);
        }

        return source is null ? default : InnerFactory.FromArray(source, start, length);
    }
}
