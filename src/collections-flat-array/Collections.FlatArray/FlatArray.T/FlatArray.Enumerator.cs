using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    public ref struct Enumerator
    {
        private const int DefaultIndex = -1;

        private readonly ReadOnlySpan<T> items;

        private int index;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal Enumerator(ReadOnlySpan<T> items)
        {
            this.items = items;
            index = DefaultIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
        {
            if (index < items.Length)
            {
                if (++index < items.Length)
                {
                    return true;
                }
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
