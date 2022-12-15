namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        public static Builder From(ReadOnlySpan<T> source)
            =>
            source.IsEmpty ? new() : new(source.ToArray(), default);

        public static Builder From(Span<T> source)
            =>
            source.IsEmpty ? new() : new(source.ToArray(), default);
    }
}
