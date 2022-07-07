using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    private static class InnerArrayHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T[] Clone(T[] source)
        {
            var dest = new T[source.Length];
            Array.Copy(source, dest, source.Length);
            return dest;
        }
    }
}
