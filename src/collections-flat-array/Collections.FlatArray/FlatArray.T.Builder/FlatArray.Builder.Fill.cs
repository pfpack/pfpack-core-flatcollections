namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        public void Fill()
            =>
            span.Clear(); // Fills the items by their default values

        public void Fill(T value)
            =>
            span.Fill(value);
    }
}
