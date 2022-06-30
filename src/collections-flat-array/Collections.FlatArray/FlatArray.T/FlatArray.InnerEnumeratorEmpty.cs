namespace System.Collections.Generic;

partial class FlatArray<T>
{
    private sealed class InnerEnumeratorEmpty : IEnumerator<T>
    {
        private InnerEnumeratorEmpty() { }

        internal static readonly InnerEnumeratorEmpty Value = new();

        public void Dispose() { }

        public bool MoveNext() => false;

        public T Current => default!;

        object IEnumerator.Current => default!;

        public void Reset() { }
    }
}
