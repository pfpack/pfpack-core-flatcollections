namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        public Enumerator GetEnumerator()
            =>
            new(this);
    }
}
