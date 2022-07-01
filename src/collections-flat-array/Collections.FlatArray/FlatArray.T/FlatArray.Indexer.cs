namespace System.Collections.Generic;

partial class FlatArray<T>
{
    public T this[int index]
        =>
        unchecked((uint)index) < (uint)items.Length
        ? items[index]
        : throw new ArgumentOutOfRangeException(
            nameof(index), index, InnerExceptionMessages.IndexRangeReqs);
}
