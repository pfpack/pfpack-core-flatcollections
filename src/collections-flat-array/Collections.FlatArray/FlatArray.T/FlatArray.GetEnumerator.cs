using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    public Enumerator GetEnumerator()
        =>
        new(InnerIsNotEmpty ? items : InnerEmptyArray.Value);

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
        =>
        InnerGetEnumeratorObject();

    IEnumerator IEnumerable.GetEnumerator()
        =>
        InnerGetEnumeratorObject();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private IEnumerator<T> InnerGetEnumeratorObject()
        =>
        InnerIsNotEmpty ? new InnerEnumeratorObject(items) : InnerEnumeratorObjectEmptyDefault.Value;

    private static class InnerEnumeratorObjectEmptyDefault
    {
        internal static readonly InnerEnumeratorObjectEmpty Value = new();
    }
}
