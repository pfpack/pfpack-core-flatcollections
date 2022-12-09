using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    [DebuggerDisplay($"{nameof(Length)} = {{{nameof(Length)}}}")]
    public ref partial struct Builder
    {
        private readonly int length;

        private readonly T[]? items;

        public int Length
            =>
            length;

        public bool IsNotEmpty
            =>
            length != default;

        public bool IsEmpty
            =>
            length == default;

        [MemberNotNullWhen(returnValue: true, nameof(items))]
        private bool InnerIsNotEmpty
            =>
            length != default;

        [MemberNotNullWhen(returnValue: false, nameof(items))]
        private bool InnerIsEmpty
            =>
            length == default;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Span<T> InnerAsSpan()
            =>
            InnerIsNotEmpty ? new(items, 0, length) : Span<T>.Empty;
    }
}
