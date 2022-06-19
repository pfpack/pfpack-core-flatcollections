using System.Collections.Generic;

namespace System.Collections.Immutable;

partial struct EquatableImmutableArray<T>
{
    IEnumerator<T> IEnumerable<T>.GetEnumerator()
        =>
        ((IEnumerable<T>)items).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        =>
        ((IEnumerable)items).GetEnumerator();
}
