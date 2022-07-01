namespace System.Collections.Generic;

partial class FlatArray<T>
{
    private sealed class InnerEnumerator : IEnumerator<T>
    {
        private readonly T[] items;

        private int index;

        private T? current;

        internal InnerEnumerator(T[] items)
            =>
            this.items = items;

        public void Dispose() { }

        public bool MoveNext()
        {
            if (index < items.Length)
            {
                current = items[index++];
                return true;
            }

            current = default;
            return false;
        }

        public T Current => current!;

        object IEnumerator.Current => current!;

        public void Reset()
        {
            index = default;
            current = default;
        }
    }
}
