using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        public ref struct Enumerator
        {
            private const int DefaultIndex = -1;

            private readonly Span<T> items;

            private int index;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal Enumerator(Span<T> items)
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

            public ref T Current
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
}
