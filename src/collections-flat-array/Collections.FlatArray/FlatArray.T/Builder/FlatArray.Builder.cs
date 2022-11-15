using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    public ref partial struct Builder
    {
        private readonly int length;

        private readonly T[]? items;

        private bool isBuilt;

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
        private ReadOnlySpan<T> InnerAsReadOnlySpan()
            =>
            InnerIsNotEmpty ? new(items) : ReadOnlySpan<T>.Empty;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Span<T> InnerAsSpan()
            =>
            InnerIsNotEmpty ? new(items) : Span<T>.Empty;
    }
}
