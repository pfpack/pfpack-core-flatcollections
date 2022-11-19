using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Builder(T item)
        {
            length = 1;
            items = new[] { item };
            isBuilt = false;

            Debug.Assert(length == items.Length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Builder(
            T item0,
            T item1)
        {
            length = 2;
            items = new[]
            {
                item0,
                item1
            };
            isBuilt = false;

            Debug.Assert(length == items.Length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Builder(
            T item0,
            T item1,
            T item2)
        {
            length = 3;
            items = new[]
            {
                item0,
                item1,
                item2
            };
            isBuilt = false;

            Debug.Assert(length == items.Length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Builder(
            T item0,
            T item1,
            T item2,
            T item3)
        {
            length = 4;
            items = new[]
            {
                item0,
                item1,
                item2,
                item3
            };
            isBuilt = false;

            Debug.Assert(length == items.Length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Builder(
            T item0,
            T item1,
            T item2,
            T item3,
            T item4)
        {
            length = 5;
            items = new[]
            {
                item0,
                item1,
                item2,
                item3,
                item4
            };
            isBuilt = false;

            Debug.Assert(length == items.Length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Builder(
            T item0,
            T item1,
            T item2,
            T item3,
            T item4,
            T item5)
        {
            length = 6;
            items = new[]
            {
                item0,
                item1,
                item2,
                item3,
                item4,
                item5
            };
            isBuilt = false;

            Debug.Assert(length == items.Length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Builder(
            T item0,
            T item1,
            T item2,
            T item3,
            T item4,
            T item5,
            T item6)
        {
            length = 7;
            items = new[]
            {
                item0,
                item1,
                item2,
                item3,
                item4,
                item5,
                item6
            };
            isBuilt = false;

            Debug.Assert(length == items.Length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Builder(
            T item0,
            T item1,
            T item2,
            T item3,
            T item4,
            T item5,
            T item6,
            T item7)
        {
            length = 8;
            items = new[]
            {
                item0,
                item1,
                item2,
                item3,
                item4,
                item5,
                item6,
                item7
            };
            isBuilt = false;

            Debug.Assert(length == items.Length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Builder(
            T item0,
            T item1,
            T item2,
            T item3,
            T item4,
            T item5,
            T item6,
            T item7,
            T item8)
        {
            length = 9;
            items = new[]
            {
                item0,
                item1,
                item2,
                item3,
                item4,
                item5,
                item6,
                item7,
                item8
            };
            isBuilt = false;

            Debug.Assert(length == items.Length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Builder(
            T item0,
            T item1,
            T item2,
            T item3,
            T item4,
            T item5,
            T item6,
            T item7,
            T item8,
            T item9)
        {
            length = 10;
            items = new[]
            {
                item0,
                item1,
                item2,
                item3,
                item4,
                item5,
                item6,
                item7,
                item8,
                item9
            };
            isBuilt = false;

            Debug.Assert(length == items.Length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Builder(
            T item0,
            T item1,
            T item2,
            T item3,
            T item4,
            T item5,
            T item6,
            T item7,
            T item8,
            T item9,
            T item10)
        {
            length = 11;
            items = new[]
            {
                item0,
                item1,
                item2,
                item3,
                item4,
                item5,
                item6,
                item7,
                item8,
                item9,
                item10
            };
            isBuilt = false;

            Debug.Assert(length == items.Length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Builder(
            T item0,
            T item1,
            T item2,
            T item3,
            T item4,
            T item5,
            T item6,
            T item7,
            T item8,
            T item9,
            T item10,
            T item11)
        {
            length = 12;
            items = new[]
            {
                item0,
                item1,
                item2,
                item3,
                item4,
                item5,
                item6,
                item7,
                item8,
                item9,
                item10,
                item11
            };
            isBuilt = false;

            Debug.Assert(length == items.Length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Builder(
            T item0,
            T item1,
            T item2,
            T item3,
            T item4,
            T item5,
            T item6,
            T item7,
            T item8,
            T item9,
            T item10,
            T item11,
            T item12)
        {
            length = 13;
            items = new[]
            {
                item0,
                item1,
                item2,
                item3,
                item4,
                item5,
                item6,
                item7,
                item8,
                item9,
                item10,
                item11,
                item12
            };
            isBuilt = false;

            Debug.Assert(length == items.Length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Builder(
            T item0,
            T item1,
            T item2,
            T item3,
            T item4,
            T item5,
            T item6,
            T item7,
            T item8,
            T item9,
            T item10,
            T item11,
            T item12,
            T item13)
        {
            length = 14;
            items = new[]
            {
                item0,
                item1,
                item2,
                item3,
                item4,
                item5,
                item6,
                item7,
                item8,
                item9,
                item10,
                item11,
                item12,
                item13
            };
            isBuilt = false;

            Debug.Assert(length == items.Length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Builder(
            T item0,
            T item1,
            T item2,
            T item3,
            T item4,
            T item5,
            T item6,
            T item7,
            T item8,
            T item9,
            T item10,
            T item11,
            T item12,
            T item13,
            T item14)
        {
            length = 15;
            items = new[]
            {
                item0,
                item1,
                item2,
                item3,
                item4,
                item5,
                item6,
                item7,
                item8,
                item9,
                item10,
                item11,
                item12,
                item13,
                item14
            };
            isBuilt = false;

            Debug.Assert(length == items.Length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Builder(
            T item0,
            T item1,
            T item2,
            T item3,
            T item4,
            T item5,
            T item6,
            T item7,
            T item8,
            T item9,
            T item10,
            T item11,
            T item12,
            T item13,
            T item14,
            T item15)
        {
            length = 16;
            items = new[]
            {
                item0,
                item1,
                item2,
                item3,
                item4,
                item5,
                item6,
                item7,
                item8,
                item9,
                item10,
                item11,
                item12,
                item13,
                item14,
                item15
            };
            isBuilt = false;

            Debug.Assert(length == items.Length);
        }
    }
}
