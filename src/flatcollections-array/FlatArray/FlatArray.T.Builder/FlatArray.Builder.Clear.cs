namespace System;

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

            // Clear the items so that the GC can reclaim the references
            // (clear only the items within the actual length;
            // the rest is supposed to be already cleared)

            var span = InnerAsSpan(); // Build Span before the length is reset
            length = default;
            span.Clear(); // Fills the items by their default values
        }
    }
}
