using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial class InnerFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static FlatArray<T> FromArray(T[] source)
            =>
            source.Length == default ? default : new(InnerArrayHelper.Clone(source), default);
    }
}
