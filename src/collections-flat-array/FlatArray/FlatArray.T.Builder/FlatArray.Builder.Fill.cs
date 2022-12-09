namespace System;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        public void Fill()
        {
            if (InnerIsEmpty)
            {
                return;
            }

            // Array.Clear implementation uses Span.Clear
            // Thus, direct using Span should be more efficient

            // Fills the items by their default values
            InnerAsSpan().Clear();
        }

        public void Fill(T value)
        {
            if (InnerIsEmpty)
            {
                return;
            }

            // Array.Fill implementation uses Span.Fill
            // Thus, direct using Span should be more efficient

            InnerAsSpan().Fill(value);
        }
    }
}
