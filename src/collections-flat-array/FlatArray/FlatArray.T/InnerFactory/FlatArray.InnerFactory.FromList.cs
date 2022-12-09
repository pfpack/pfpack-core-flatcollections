using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class InnerFactory
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
            source.CopyTo(array, 0);

            return new(array, default);
        }
    }
}
