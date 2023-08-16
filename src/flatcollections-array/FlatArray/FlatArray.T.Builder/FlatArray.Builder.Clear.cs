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

            // Array.Clear uses SpanHelpers but also contains code that handles the non-standard arrays
            // Thus, Span should be more efficient for the standard arrays

            var span = InnerAsSpan(); // Build Span before the length is reset

            length = default;

            // Clear the items so that the GC can reclaim the references
            // (clear only the items within the actual length;
            // the rest is supposed to be already cleared)

            span.Clear(); // Fills the items by their default values
        }
    }
}
