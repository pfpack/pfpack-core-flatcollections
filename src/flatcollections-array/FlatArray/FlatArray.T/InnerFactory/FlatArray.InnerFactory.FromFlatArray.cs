using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class InnerFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static FlatArray<T> FromFlatArray(FlatArray<T> source)
            =>
            source.length == default ? default : new(InnerArrayHelper.Copy(source.items!, source.length), default);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static FlatArray<T> FromFlatArray(FlatArray<T> source, int start, int length)
        {
            Debug.Assert(InnerAllocHelper.IsSegmentWithin(start, length, source.length));

            return length == default ? default : new(InnerArrayHelper.CopySegment(source.items!, start, length), default);
        }
    }
}
