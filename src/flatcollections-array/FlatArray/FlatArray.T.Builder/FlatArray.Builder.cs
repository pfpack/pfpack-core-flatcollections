using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
#if NET8_0_OR_GREATER
    [CollectionBuilder(typeof(FlatArray.Builder), nameof(FlatArray.Builder.From))]
#endif
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
