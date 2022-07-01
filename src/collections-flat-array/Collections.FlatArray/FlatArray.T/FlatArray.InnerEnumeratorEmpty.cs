namespace System.Collections.Generic;

partial class FlatArray<T>
{
    private sealed class InnerEnumeratorEmpty : IEnumerator<T>
    {
        internal InnerEnumeratorEmpty() { }

        public void Dispose() { }

        public bool MoveNext() => false;

        public T Current => default!;

        object IEnumerator.Current => default!;

        public void Reset() { }
    }
}
