﻿using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        public struct Enumerator
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

            public T Current
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
#pragma warning disable IDE0251 // Make member 'readonly'
                get
#pragma warning restore IDE0251 // Make member 'readonly'
                {
                    if (InnerAllocHelper.IsIndexInRange(index, builder.length))
                    {
                        return builder.items[index];
                    }

                    // The builder length may have changed since the last successful MoveNext
                    // Thus, throw IndexOutOfRangeException instead of InvalidOperationException
                    throw InnerExceptionFactory.IndexOutOfRange(index, builder.length);
                }
            }
        }
    }
}
