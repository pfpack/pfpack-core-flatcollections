using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class InnerFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static FlatArray<T> FromList(List<T> source)
        {
            var count = source.Count;
            if (count == default)
            {
                return default;
            }

            var array = new T[count];
            source.CopyTo(array);

            return new(array, default);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static FlatArray<T> FromList(List<T> source, int start, int length)
        {
            Debug.Assert(InnerAllocHelper.IsSegmentWithin(start, length, source.Count));

            if (length == default)
            {
                return default;
            }

            var array = new T[length];
            source.CopyTo(start, array, 0, length);

            return new(array, default);
        }
    }
}
