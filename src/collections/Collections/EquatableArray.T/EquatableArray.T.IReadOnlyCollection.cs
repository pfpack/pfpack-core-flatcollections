namespace System.Collections.Generic;

partial class EquatableArray<T>
{
    int IReadOnlyCollection<T>.Count
        =>
        items.Length;
}
