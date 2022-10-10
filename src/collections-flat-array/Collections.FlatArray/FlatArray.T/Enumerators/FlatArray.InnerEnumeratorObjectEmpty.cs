namespace System.Collections.Generic;

partial class FlatArray<T>
{
    private sealed class InnerEnumeratorObjectEmpty : IEnumerator<T>
    {
        internal InnerEnumeratorObjectEmpty() { }

        public bool MoveNext() => false;

        public T Current
            =>
            throw InnerExceptionFactory.EnumerationEitherNotStartedOrFinished();

        object IEnumerator.Current
            =>
            throw InnerExceptionFactory.EnumerationEitherNotStartedOrFinished();

        public void Reset() { }

        public void Dispose() { }
    }
}
