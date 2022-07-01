namespace System.Collections.Generic;

partial class FlatArray<T>
{
    private sealed class InnerEnumerator : IEnumerator<T>
    {
        private const int defaultIndex = -1;

        private readonly T[] items;

        private int index = defaultIndex;

        internal InnerEnumerator(T[] items)
            =>
            this.items = items;

        public bool MoveNext()
        {
            if (index + 1 < items.Length)
            {
                index++;
                return true;
            }

            return false;
        }

        public T Current
            =>
            unchecked((uint)index) < (uint)items.Length
            ? items[index]
            : throw new InvalidOperationException();

        object IEnumerator.Current
            =>
            Current!;

        public void Reset()
            =>
            index = defaultIndex;

        public void Dispose() { }
    }
}
