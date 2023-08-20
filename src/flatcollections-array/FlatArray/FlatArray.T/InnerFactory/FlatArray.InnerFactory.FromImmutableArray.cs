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
        internal static FlatArray<T> FromImmutableArray(ImmutableArray<T> source, int length)
        {
            //Debug.Assert(length >= 0 && length <= source.Length);

            if (source.IsDefaultOrEmpty)
            {
                return default;
            }

            var array = new T[length];
            source.CopyTo(0, array, 0, length);

            return new(array, default);
        }
    }
}
