namespace System;

partial struct FlatArray<T>
{
    public IEnumerable<T> AsEnumerable()
        =>
        new InnerFlatList(length, InnerItems());
}
