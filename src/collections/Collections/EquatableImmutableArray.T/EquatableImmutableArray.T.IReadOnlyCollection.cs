using System.Collections.Generic;

namespace System.Collections.Immutable;

partial struct EquatableImmutableArray<T>
{
    int IReadOnlyCollection<T>.Count
        =>
        items.Length;
}
