namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    public ref partial struct Builder
    {
        private readonly Span<T> span;

        private readonly T[]? items;

        public int Length
            =>
            span.Length;

        public bool IsNotEmpty
            =>
            span.IsEmpty is not true;

        public bool IsEmpty
            =>
            span.IsEmpty;
    }
}
