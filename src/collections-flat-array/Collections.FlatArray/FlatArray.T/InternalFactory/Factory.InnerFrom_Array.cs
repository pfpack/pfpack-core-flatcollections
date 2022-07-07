using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    partial class InternalFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FlatArray<T> InnerFrom_Array(T[] source)
            =>
            source.Length > 0 ? new(InnerArrayHelper.Clone(source), default) : InnerEmptyFlatArray.Value;
    }
}
