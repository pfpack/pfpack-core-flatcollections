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

            // Create a defensive copy for an arbitrary ICollection implementation
            // that is not as trusted as List or ImmutableArray
            var arrayCopy = InnerArrayHelper.Clone(array);

            return new(arrayCopy, default);
        }
    }
}
