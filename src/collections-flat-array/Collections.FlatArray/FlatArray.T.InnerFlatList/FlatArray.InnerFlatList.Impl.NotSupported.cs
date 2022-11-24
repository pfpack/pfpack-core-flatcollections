using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial class InnerFlatList
    {
        [DoesNotReturn]
        void ICollection<T>.Add(T item)
            =>
            throw InnerExceptionFactory.NotSupportedOnReadOnlyArray();

        [DoesNotReturn]
        void IList<T>.Insert(int index, T item)
            =>
            throw InnerExceptionFactory.NotSupportedOnReadOnlyArray();

        [DoesNotReturn]
        bool ICollection<T>.Remove(T item)
            =>
            throw InnerExceptionFactory.NotSupportedOnReadOnlyArray();

        [DoesNotReturn]
        void IList<T>.RemoveAt(int index)
            =>
            throw InnerExceptionFactory.NotSupportedOnReadOnlyArray();

        [DoesNotReturn]
        void ICollection<T>.Clear()
            =>
            throw InnerExceptionFactory.NotSupportedOnReadOnlyArray();
    }
}
