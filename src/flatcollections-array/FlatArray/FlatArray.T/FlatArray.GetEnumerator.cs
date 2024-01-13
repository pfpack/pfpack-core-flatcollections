namespace System;

partial struct FlatArray<T>
{
    public Enumerator GetEnumerator()
        =>
        new(length, InnerItems);
}
