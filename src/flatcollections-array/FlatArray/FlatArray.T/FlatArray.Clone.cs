namespace System;

partial struct FlatArray<T>
{
    public FlatArray<T> Clone()
        =>
        new(this);
}
