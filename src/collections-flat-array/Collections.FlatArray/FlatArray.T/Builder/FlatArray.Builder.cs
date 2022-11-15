using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    public readonly ref partial struct Builder
    {
        private readonly int length;

        private readonly T[]? items;

        public Builder(int length)
        {
            if (length is not >= 0)
            {
                throw InnerExceptionFactory.LengthOutOfRange(nameof(length), length);
            }

            if (length == default)
            {
                this = default;
                return;
            }

            this.length = length;
            items = new T[length];
        }

        public int Length
            =>
            length;

        public bool IsNotEmpty
            =>
            length != default;

        public bool IsEmpty
            =>
            length == default;

        // Inner state helpers:

        [MemberNotNullWhen(returnValue: true, nameof(items))]
        private bool InnerIsNotEmpty
            =>
            length != default;

        [MemberNotNullWhen(returnValue: false, nameof(items))]
        private bool InnerIsEmpty
            =>
            length == default;

        public FlatArray<T> Build()
            =>
            InnerIsNotEmpty ? new FlatArray<T>(items, default) : default;
    }
}
