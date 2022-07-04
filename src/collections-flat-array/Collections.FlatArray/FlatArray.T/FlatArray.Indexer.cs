namespace System.Collections.Generic;

partial class FlatArray<T>
{
    public T this[int index]
        =>
        unchecked((uint)index) < (uint)items.Length // index >= 0 && index < items.Length
        ? items[index]
        : throw new ArgumentOutOfRangeException(
            nameof(index), InnerExceptionMessages.IndexOutOfRange(index));
}
