namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial class InnerFlatList
    {
        bool ICollection<T>.IsReadOnly => true;

        T IList<T>.this[int index]
        {
            get => items[index];
            set => throw InnerExceptionFactory.NotSupportedOnReadOnlyCollection();
        }
    }
}
