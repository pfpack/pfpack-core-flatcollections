using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class InnerFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static FlatArray<T> FromArray(T[] source)
            =>
            source.Length == default ? default : new(InnerArrayHelper.Copy(source), default);
    }
}
