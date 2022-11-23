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
        InnerIsNotEmpty ? new InnerEnumerator(items) : InnerEnumeratorEmptyDefault.Value;

    private static class InnerEnumeratorEmptyDefault
    {
        internal static readonly InnerEnumeratorEmpty Value = new();
    }
}
