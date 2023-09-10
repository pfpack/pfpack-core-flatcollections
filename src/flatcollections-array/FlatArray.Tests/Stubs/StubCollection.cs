using System.Collections;
using System.Collections.Generic;

namespace PrimeFuncPack.Core.Tests;

internal sealed class StubCollection<T> : ICollection<T>
{
    private readonly ICollection<T> sourceCollection;

    internal StubCollection(List<T> sourceCollection)
        =>
        this.sourceCollection = sourceCollection;

    public int Count
        =>
        sourceCollection.Count;

    public bool IsReadOnly
        =>
        sourceCollection.IsReadOnly;

    public void Add(T item)
        =>
        sourceCollection.Add(item);

    public void Clear()
        =>
        sourceCollection.Clear();

    public bool Contains(T item)
        =>
        sourceCollection.Contains(item);

    public void CopyTo(T[] array, int arrayIndex)
        =>
        sourceCollection.CopyTo(array, arrayIndex);

    public bool Remove(T item)
        =>
        sourceCollection.Remove(item);

    public IEnumerator<T> GetEnumerator()
        =>
        sourceCollection.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        =>
        GetEnumerator();
}