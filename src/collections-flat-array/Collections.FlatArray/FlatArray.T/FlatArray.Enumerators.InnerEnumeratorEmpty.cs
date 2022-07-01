namespace System.Collections.Generic;

partial class FlatArray<T>
{
    private sealed class InnerEnumeratorEmpty : IEnumerator<T>
    {
        internal InnerEnumeratorEmpty() { }

        public bool MoveNext() => false;

        public T Current
            =>
            throw new InvalidOperationException(InnerExceptionMessages.EnumeratorNotPositioned);

        object IEnumerator.Current
            =>
            throw new InvalidOperationException(InnerExceptionMessages.EnumeratorNotPositioned);

        public void Reset() { }

        public void Dispose() { }
    }
}
