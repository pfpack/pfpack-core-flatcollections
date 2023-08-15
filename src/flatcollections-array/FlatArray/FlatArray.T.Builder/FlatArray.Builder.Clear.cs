﻿namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        // TODO: Add the tests and make public
        internal void Clear()
        {
            if (length == default)
            {
                return;
            }

            // Array.Clear implementation uses Span.Clear
            // Thus, direct using Span should be more efficient

            // Clear the items so that the GC can reclaim the references
            // (clear only the items within the actual length;
            // the rest is supposed to be already cleared)
            InnerAsSpan().Clear();

            length = default;
        }
    }
}
