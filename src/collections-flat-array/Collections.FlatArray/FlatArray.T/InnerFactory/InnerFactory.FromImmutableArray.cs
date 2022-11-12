using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

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
            source.CopyTo(array, 0);

            return new(array, default);
        }
    }
}
