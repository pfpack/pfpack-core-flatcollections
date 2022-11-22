namespace System.Collections.Generic;

partial class FlatList<T>
{
    private sealed class InnerEnumeratorEmpty : IEnumerator<T>
    {
        internal InnerEnumeratorEmpty() { }

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
