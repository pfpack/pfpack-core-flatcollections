using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class InnerFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static FlatArray<T> FromArray(T[] source)
            =>
            source.Length == default ? default : new(InnerArrayHelper.Copy(source), default);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static FlatArray<T> FromArray(T[] source, int start, int length)
        {
            Debug.Assert(InnerAllocHelper.IsSegmentWithinLength(start, length, source.Length));

            return length == default ? default : new(InnerArrayHelper.CopySegment(source, start, length), default);
        }
    }
}
