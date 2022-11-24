using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial class InnerFlatList
    {
        private sealed class InnerEnumerator : IEnumerator<T>
        {
            private const int DefaultIndex = -1;

            private readonly T[] items;

            private int index;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal InnerEnumerator(T[] items)
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

            public T Current
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    if (index >= 0 && index < items.Length)
                    {
                        return items[index];
                    }

                    throw InnerExceptionFactory.EnumerationEitherNotStartedOrFinished();
                }
            }

            object IEnumerator.Current => Current!;

            public void Reset() => index = DefaultIndex;

            public void Dispose() { }
        }
    }
}
