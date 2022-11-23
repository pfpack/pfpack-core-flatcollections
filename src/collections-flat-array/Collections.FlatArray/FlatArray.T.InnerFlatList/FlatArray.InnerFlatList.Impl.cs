namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial class InnerFlatList
    {
        bool ICollection<T>.IsReadOnly => true;

        public int Count => items.Length;

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < items.Length)
                {
                    return items[index];
                }

                throw InnerExceptionFactory.IndexOutOfRange(nameof(index), index);
            }
            set
            {
                throw InnerExceptionFactory.NotSupportedOnReadOnlyArray();
            }
        }

        public int IndexOf(T item)
            =>
            Array.IndexOf(items, item);

        public bool Contains(T item)
            =>
            Array.IndexOf(items, item) >= 0;

        public void CopyTo(T[] array, int arrayIndex)
            =>
            Array.Copy(items, 0, array, arrayIndex, items.Length);

        public IEnumerator<T> GetEnumerator()
            =>
            items.Length != default ? new InnerEnumerator(items) : InnerEnumeratorEmptyDefault.Value;

        IEnumerator IEnumerable.GetEnumerator()
            =>
            GetEnumerator();

        private static class InnerEnumeratorEmptyDefault
        {
            internal static readonly InnerEnumeratorEmpty Value = new();
        }
    }
}
