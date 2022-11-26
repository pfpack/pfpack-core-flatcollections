namespace System.Collections.Generic;

partial struct FlatArray<T>
{
#pragma warning disable IDE0064 // Make readonly fields writable
    public ref partial struct Builder
#pragma warning restore IDE0064 // Make readonly fields writable
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
