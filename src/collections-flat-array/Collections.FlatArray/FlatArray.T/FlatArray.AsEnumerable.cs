namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    public IEnumerable<T> AsEnumerable()
        =>
        new InnerFlatList(InnerAsArray());
}
