using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic;

partial class FlatList<T>
{
    [DoesNotReturn]
    void ICollection<T>.Add(T item)
        =>
        throw InnerExceptionFactory.NotSupportedOnReadOnlyCollection();

    [DoesNotReturn]
    bool ICollection<T>.Remove(T item)
        =>
        throw InnerExceptionFactory.NotSupportedOnReadOnlyCollection();

    [DoesNotReturn]
    void ICollection<T>.Clear()
        =>
        throw InnerExceptionFactory.NotSupportedOnReadOnlyCollection();

    [DoesNotReturn]
    void IList<T>.Insert(int index, T item)
        =>
        throw InnerExceptionFactory.NotSupportedOnReadOnlyCollection();

    [DoesNotReturn]
    void IList<T>.RemoveAt(int index)
        =>
        throw InnerExceptionFactory.NotSupportedOnReadOnlyCollection();
}
