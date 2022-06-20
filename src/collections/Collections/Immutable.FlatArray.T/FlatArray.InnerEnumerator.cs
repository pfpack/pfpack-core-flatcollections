using System.Collections.Generic;

namespace System.Collections.Immutable;

partial class FlatArray<T>
{
    private sealed class InnerEnumerator : IEnumerator<T>
    {
        private const int defaultIndex = -1;

        private readonly T[] items;

        private int currentIndex = defaultIndex;

        private T currentItem = default!;

        internal InnerEnumerator(T[] items)
            =>
            this.items = items;

        T IEnumerator<T>.Current => currentItem;

        object IEnumerator.Current => currentItem!;

        void IDisposable.Dispose() { }

        bool IEnumerator.MoveNext()
        {
            if (currentIndex < items.Length && ++currentIndex < items.Length)
            {
                currentItem = items[currentIndex];
                return true;
            }

            return false;
        }

        void IEnumerator.Reset()
            =>
            currentIndex = defaultIndex;
    }
}
