using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class InnerFactoryHelper
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

            // Create a defensive copy for the case of an arbitrary collection implementation
            var arrayCopy = InnerArrayHelper.Copy(array);

            return new(arrayCopy, default);
        }
    }
}
