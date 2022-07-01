namespace System.Collections.Generic;

partial class FlatArray<T>
{
    public struct Enumerator
    {
        private readonly T[] items;

        private int index;

        internal Enumerator(T[] items)
            =>
            (this.items, index) = (items, -1);

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
            unchecked((uint)index) < (uint)items.Length // index >= 0 && index < items.Length
            ? items[index]
            : throw new InvalidOperationException(InnerExceptionMessages.EnumeratorNotPositioned);
    }
}
