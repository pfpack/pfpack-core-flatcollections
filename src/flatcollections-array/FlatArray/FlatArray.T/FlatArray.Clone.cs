namespace System;

partial struct FlatArray<T>
{
    public FlatArray<T> Clone()
        =>
        InnerFactory.FromFlatArray(this);
}
