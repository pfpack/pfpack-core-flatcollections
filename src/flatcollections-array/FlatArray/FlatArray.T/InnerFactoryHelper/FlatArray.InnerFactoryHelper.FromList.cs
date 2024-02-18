using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class InnerFactoryHelper
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
#if NET8_0_OR_GREATER
            source.CopyTo(new Span<T>(array));
#else
            source.CopyTo(array);
#endif

            return new(array, default);
        }
    }
}
