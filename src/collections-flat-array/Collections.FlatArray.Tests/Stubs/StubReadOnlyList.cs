using System.Collections;
using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Tests;

internal sealed class StubReadOnlyList<T> : IReadOnlyList<T>
{
    private readonly IReadOnlyList<T> source;

    internal StubReadOnlyList(List<T> source)
        =>
        this.source = source;

    public T this[int index]
        =>
        source[index];

    public int Count
        =>
        source.Count;

    public IEnumerator<T> GetEnumerator()
        =>
        source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        =>
        ((IEnumerable)source).GetEnumerator();
}