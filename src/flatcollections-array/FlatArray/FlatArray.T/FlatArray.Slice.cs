namespace System;

partial struct FlatArray<T>
{
    public FlatArray<T> Slice(int start, int length)
        =>
        InnerFactoryHelper.FromFlatArrayValidated(this, start, length);
}
