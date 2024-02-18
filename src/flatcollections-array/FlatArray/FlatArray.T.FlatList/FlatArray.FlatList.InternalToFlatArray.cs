using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class FlatList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal FlatArray<T> InternalToFlatArray()
        {
            if (length == default)
            {
                return default;
            }

            return new(InnerArrayHelper.Copy(items, length), default);
        }
    }
}
