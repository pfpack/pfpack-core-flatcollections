namespace System;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        public Enumerator GetEnumerator()
            =>
            new(this);
    }
}
