namespace System.Collections.Generic;

partial class FlatArray<T>
{
    public struct Enumerator
    {
        private const int defaultIndex = -1;

        private readonly T[] items;

        private int index;

        internal Enumerator(T[] items)
            =>
            (this.items, index) = (items, defaultIndex);

        public bool MoveNext()
        {
            int next = index + 1;
            if (next < items.Length)
            {
                index = next;
                return true;
            }

            return false;
        }

        public T Current
            =>
            unchecked((uint)index) < (uint)items.Length // index >= 0 && index < items.Length
            ? items[index]
            : throw new InvalidOperationException(
                InnerExceptionMessages.EnumerationEitherNotStartedOrFinished);
    }
}
