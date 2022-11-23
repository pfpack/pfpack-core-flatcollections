using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial class InnerFlatList
    {
        [DoesNotReturn]
        public void Add(T item)
            =>
            throw InnerExceptionFactory.NotSupportedOnReadOnlyCollection();

        [DoesNotReturn]
        public void Insert(int index, T item)
            =>
            throw InnerExceptionFactory.NotSupportedOnReadOnlyCollection();

        [DoesNotReturn]
        public bool Remove(T item)
            =>
            throw InnerExceptionFactory.NotSupportedOnReadOnlyCollection();

        [DoesNotReturn]
        public void RemoveAt(int index)
            =>
            throw InnerExceptionFactory.NotSupportedOnReadOnlyCollection();

        [DoesNotReturn]
        public void Clear()
            =>
            throw InnerExceptionFactory.NotSupportedOnReadOnlyCollection();
    }
}
