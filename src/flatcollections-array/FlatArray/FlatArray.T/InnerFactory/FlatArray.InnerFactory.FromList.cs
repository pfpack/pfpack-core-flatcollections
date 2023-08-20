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
        internal static FlatArray<T> FromList(List<T> source, int length)
        {
            Debug.Assert(length >= 0 && length <= source.Count);

            if (length == default)
            {
                return default;
            }

            var array = new T[length];
            source.CopyTo(0, array, 0, length);

            return new(array, default);
        }
    }
}
