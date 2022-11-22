namespace System.Collections.Generic;

partial class FlatList<T>
{
    bool ICollection<T>.IsReadOnly => true;

    T IList<T>.this[int index]
    {
        get => items[index];
        set => throw InnerExceptionFactory.NotSupportedOnReadOnlyCollection();
    }
}
