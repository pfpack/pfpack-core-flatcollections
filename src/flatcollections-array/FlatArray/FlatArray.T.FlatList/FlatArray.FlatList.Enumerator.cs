using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class FlatList
    {
        private sealed class Enumerator : IEnumerator<T>
        {
            private const int DefaultIndex = -1;

            private readonly int length;

            private readonly T[] items;

            private int index;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal Enumerator(int length, T[] items)
            {
                Debug.Assert(length >= 0 && length <= items.Length);

                this.length = length;
                this.items = items;
                index = DefaultIndex;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext()
            {
                if (index < length)
                {
                    if (++index < length)
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
                    if (InnerAllocHelper.IsIndexInRange(index, length))
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
