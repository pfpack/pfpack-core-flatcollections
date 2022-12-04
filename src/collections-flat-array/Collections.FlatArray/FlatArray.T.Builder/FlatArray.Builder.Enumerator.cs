using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        public ref struct Enumerator
        {
            private const int DefaultIndex = -1;

            private readonly Builder builder;

            private int index;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal Enumerator(Builder builder)
            {
                this.builder = builder;
                index = DefaultIndex;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext()
            {
                if (index < builder.length)
                {
                    if (++index < builder.length)
                    {
                        return true;
                    }
                }

                return false;
            }

            public ref T Current
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    if (index >= 0 && index < builder.length)
                    {
                        return ref builder.items![index];
                    }

                    // The builder length may have changed since the last successful MoveNext
                    // Thus, throw IndexOutOfRangeException instead of InvalidOperationException
                    throw InnerExceptionFactory.IndexOutOfRange(nameof(index), index);
                }
            }
        }
    }
}
