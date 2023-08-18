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

            var span = InnerAsSpan();
            span.Clear(); // Fills the items by their default values
        }

        public void Fill(T value)
        {
            if (length == default)
            {
                return;
            }

            var span = InnerAsSpan();
            span.Fill(value);
        }
    }
}
