using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    public static FlatArray<T> From(ImmutableArray<T> source)
        =>
        new(source);

    // TODO: Add the tests and make public
    internal static FlatArray<T> From(ImmutableArray<T> source, int start, int length)
    {
        InnerValidateRange();

        if (length == default)
        {
            return default;
        }

        var array = new T[length];
        source.CopyTo(start, array, 0, length);

        return new(array, default);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void InnerValidateRange()
        {
            var sourceLength = source.IsDefault ? default : source.Length;
            if (InnerAllocHelper.IsSegmentWithinBounds(start, length, sourceLength))
            {
                return;
            }
            throw InnerExceptionFactory.SegmentOutsideBounds(start, length, sourceLength);
        }
    }

    public static FlatArray<T> From(ImmutableArray<T>? source)
        =>
        new(source);

    // TODO: Add the tests and make public
    internal static FlatArray<T> From(ImmutableArray<T>? source, int start, int length)
        =>
        From(source.GetValueOrDefault(), start, length);
}
