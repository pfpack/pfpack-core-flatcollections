namespace System.Collections.Generic;

partial class FlatArray<T>
{
    public T this[int index]
        =>
        index >= 0 && index < items.Length
        ? items[index]
        : throw InnerExceptionFactory.IndexOutOfRange(nameof(index), index);
}
