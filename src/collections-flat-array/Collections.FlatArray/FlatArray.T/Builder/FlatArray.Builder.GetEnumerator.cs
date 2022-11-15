namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        public Enumerator GetEnumerator()
            =>
            new(InnerIsNotEmpty ? new ReadOnlySpan<T>(items) : ReadOnlySpan<T>.Empty);
    }
}
