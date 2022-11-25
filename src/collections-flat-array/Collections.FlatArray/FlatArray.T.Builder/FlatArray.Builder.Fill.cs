namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        public void Fill(T value)
            =>
            span.Fill(value);
    }
}
