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
                return Span<T>.Empty;
            }

            if (length == items.Length)
            {
                return new(items);
            }

            return new(items, 0, length);
        }
    }
}
