namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        public void Fill()
        {
            if (length == default)
            {
                return;
            }

            // Array.Clear uses SpanHelpers but also contains code that handles the non-standard arrays
            // Thus, Span should be more efficient for the standard arrays

            var span = InnerAsSpan();

            span.Clear(); // Fills the items by their default values
        }

        public void Fill(T value)
        {
            if (length == default)
            {
                return;
            }

            // Array.Fill uses Span but also contains code that handles the non-standard arrays
            // Thus, Span should be more efficient for the standard arrays

            var span = InnerAsSpan();

            span.Fill(value);
        }
    }
}
