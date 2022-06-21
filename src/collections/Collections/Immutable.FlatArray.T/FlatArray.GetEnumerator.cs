using System.Collections.Generic;

namespace System.Collections.Immutable;

partial class FlatArray<T>
{
    public IEnumerator<T> GetEnumerator()
        =>
        new InnerEnumerator(items);

    IEnumerator IEnumerable.GetEnumerator()
        =>
        new InnerEnumerator(items);
}
