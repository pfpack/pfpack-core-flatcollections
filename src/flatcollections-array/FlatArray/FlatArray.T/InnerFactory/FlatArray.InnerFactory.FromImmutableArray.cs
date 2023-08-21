using System.Collections.Immutable;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class InnerFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static FlatArray<T> FromImmutableArray(ImmutableArray<T> source)
        {
            if (source.IsDefaultOrEmpty)
            {
                return default;
            }

            var array = new T[source.Length];
            source.CopyTo(array);

            return new(array, default);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static FlatArray<T> FromImmutableArray(ImmutableArray<T> source, int start, int length)
        {
            Debug.Assert(InnerAllocHelper.IsSegmentWithin(start, length, source.IsDefault ? default : source.Length));

            if (source.IsDefaultOrEmpty)
            {
                return default;
            }

            var array = new T[length];
            source.CopyTo(start, array, 0, length);

            return new(array, default);
        }
    }
}
