namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        // TODO: Make public when dynamic builder is implemented
        internal void Clear()
        {
            if (length == default)
            {
                return;
            }

            // Array.Clear implementation uses Span.Clear
            // Thus, direct using Span should be more efficient

            // Clear the items so that the GC can reclaim the references
            InnerAsSpan().Clear();

            length = default;
        }
    }
}
