namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    public ref struct Enumerator
    {
        private const int DefaultIndex = -1;

        private readonly T[] items;

        private int index;

        internal Enumerator(T[] items)
            =>
            (this.items, index) = (items, DefaultIndex);

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

        public ref readonly T Current
        {
            get
            {
                if (index >= 0 && index < items.Length)
                {
                    return ref items[index];
                }

                throw InnerExceptionFactory.EnumerationEitherNotStartedOrFinished();
            }
        }
    }
}
