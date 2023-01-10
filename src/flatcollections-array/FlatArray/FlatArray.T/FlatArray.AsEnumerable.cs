using System.Collections.Generic;

namespace System;

partial struct FlatArray<T>
{
    public IEnumerable<T> AsEnumerable()
        =>
        new FlatList(length, InnerItems());
}
