using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System;

partial struct FlatArray<T>
{
    partial class InnerFlatList
    {
        [DoesNotReturn]
        void ICollection<T>.Add(T item)
            =>
            throw InnerListExceptionFactory.NotSupportedOnReadOnlyArray();

        [DoesNotReturn]
        void IList<T>.Insert(int index, T item)
            =>
            throw InnerListExceptionFactory.NotSupportedOnReadOnlyArray();

        [DoesNotReturn]
        bool ICollection<T>.Remove(T item)
            =>
            throw InnerListExceptionFactory.NotSupportedOnReadOnlyArray();

        [DoesNotReturn]
        void IList<T>.RemoveAt(int index)
            =>
            throw InnerListExceptionFactory.NotSupportedOnReadOnlyArray();

        [DoesNotReturn]
        void ICollection<T>.Clear()
            =>
            throw InnerListExceptionFactory.NotSupportedOnReadOnlyArray();
    }
}
