using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Span<T> InnerAsSpan()
        {
            if (length == default)
            {
#pragma warning disable IDE0301 // Simplify collection initialization
                return Span<T>.Empty;
#pragma warning restore IDE0301 // Simplify collection initialization
            }

            if (length == items.Length)
            {
                return new(items);
            }

            return new(items, 0, length);
        }
    }
}
