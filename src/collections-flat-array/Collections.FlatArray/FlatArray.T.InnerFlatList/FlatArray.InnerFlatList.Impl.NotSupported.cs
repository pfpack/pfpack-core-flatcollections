using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial class InnerFlatList
    {
        [DoesNotReturn]
        public void Add(T item)
            =>
            throw InnerExceptionFactory.NotSupportedOnReadOnlyArray();

        [DoesNotReturn]
        public void Insert(int index, T item)
            =>
            throw InnerExceptionFactory.NotSupportedOnReadOnlyArray();

        [DoesNotReturn]
        public bool Remove(T item)
            =>
            throw InnerExceptionFactory.NotSupportedOnReadOnlyArray();

        [DoesNotReturn]
        public void RemoveAt(int index)
            =>
            throw InnerExceptionFactory.NotSupportedOnReadOnlyArray();

        [DoesNotReturn]
        public void Clear()
            =>
            throw InnerExceptionFactory.NotSupportedOnReadOnlyArray();
    }
}
