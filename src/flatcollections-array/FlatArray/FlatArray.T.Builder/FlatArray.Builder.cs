using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    [DebuggerDisplay($"{nameof(Length)} = {{{nameof(Length)}}}")]
    public partial struct Builder
    {
        private int length;

        private T[]? items;

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
        private bool InnerIsValidState() // For only use in Debug.Assert
            =>
            length == default && items is null ||
            length == default && items is not null && items.Length > 0 ||
            length > 0 && items is not null && length <= items.Length;

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
