using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial class InnerFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static FlatArray<T> FromICollection(ICollection<T> source)
        {
            var count = source.Count;
            if (count is not > 0)
            {
                return default;
            }

            var array = new T[count];
            source.CopyTo(array, 0);

            // Make a defensive copy for an arbitrary implementation of ICollection
            // (not as trusted as List or ImmutableArray)

            return new(InnerArrayHelper.Clone(array), default);
        }
    }
}
