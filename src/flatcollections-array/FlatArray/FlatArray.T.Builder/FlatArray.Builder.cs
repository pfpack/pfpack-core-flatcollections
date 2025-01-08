using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    [CollectionBuilder(typeof(FlatArray.Builder), nameof(FlatArray.Builder.From))]
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
    }
}
