using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    partial class InternalFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FlatArray<T> InnerFrom_FlatArray(FlatArray<T> source)
            =>
            source.items.Length > 0 ? new(InnerArrayHelper.Clone(source.items), default) : InnerEmptyFlatArray.Value;
    }
}
