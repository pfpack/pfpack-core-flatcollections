namespace System;

partial struct FlatArray<T>
{
    public bool CanCastArray<TResult>()
        =>
        InnerItems() is TResult[];
}
