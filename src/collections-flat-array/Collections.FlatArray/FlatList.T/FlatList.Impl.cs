namespace System.Collections.Generic;

partial class FlatList<T>
{
    public int Count => items.Length;

    public T this[int index] => items[index];

    public int IndexOf(T item)
        =>
        Array.IndexOf(items, item);

    public bool Contains(T item)
        =>
        Array.IndexOf(items, item) >= 0;

    public void CopyTo(T[] array, int arrayIndex)
        =>
        Array.Copy(items, 0, array, arrayIndex, items.Length);

    public IEnumerator<T> GetEnumerator()
        =>
        items.Length != default ? new InnerEnumerator(items) : InnerEnumeratorEmptyDefault.Value;

    IEnumerator IEnumerable.GetEnumerator()
        =>
        GetEnumerator();

    private static class InnerEnumeratorEmptyDefault
    {
        internal static readonly InnerEnumeratorEmpty Value = new();
    }
}
