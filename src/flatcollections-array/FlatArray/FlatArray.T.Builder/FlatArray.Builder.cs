using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    [DebuggerDisplay($"{nameof(Length)} = {{{nameof(Length)}}}")]
    public sealed partial class Builder
    {
        private int length;

        private T[] items;

        public int Length
            =>
            length;

        public bool IsNotEmpty
            =>
            length != default;

        public bool IsEmpty
            =>
            length == default;

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
