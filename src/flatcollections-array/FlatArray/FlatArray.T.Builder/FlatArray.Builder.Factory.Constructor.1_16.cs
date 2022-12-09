using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Builder(T item)
        {
            var items = new[] { item };
            Debug.Assert(items.Length == 1);

            length = items.Length;
            this.items = items;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Builder(
            T item0,
            T item1)
        {
            var items = new[]
            {
                item0,
                item1
            };
            Debug.Assert(items.Length == 2);

            length = items.Length;
            this.items = items;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Builder(
            T item0,
            T item1,
            T item2)
        {
            var items = new[]
            {
                item0,
                item1,
                item2
            };
            Debug.Assert(items.Length == 3);

            length = items.Length;
            this.items = items;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Builder(
            T item0,
            T item1,
            T item2,
            T item3)
        {
            var items = new[]
            {
                item0,
                item1,
                item2,
                item3
            };
            Debug.Assert(items.Length == 4);

            length = items.Length;
            this.items = items;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Builder(
            T item0,
            T item1,
            T item2,
            T item3,
            T item4)
        {
            var items = new[]
            {
                item0,
                item1,
                item2,
                item3,
                item4
            };
            Debug.Assert(items.Length == 5);

            length = items.Length;
            this.items = items;
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
            var items = new[]
            {
                item0,
                item1,
                item2,
                item3,
                item4,
                item5
            };
            Debug.Assert(items.Length == 6);

            length = items.Length;
            this.items = items;
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
            var items = new[]
            {
                item0,
                item1,
                item2,
                item3,
                item4,
                item5,
                item6
            };
            Debug.Assert(items.Length == 7);

            length = items.Length;
            this.items = items;
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
            var items = new[]
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
            Debug.Assert(items.Length == 8);

            length = items.Length;
            this.items = items;
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
            var items = new[]
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
            Debug.Assert(items.Length == 9);

            length = items.Length;
            this.items = items;
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
            var items = new[]
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
            Debug.Assert(items.Length == 10);

            length = items.Length;
            this.items = items;
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
            var items = new[]
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
            Debug.Assert(items.Length == 11);

            length = items.Length;
            this.items = items;
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
            var items = new[]
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
            Debug.Assert(items.Length == 12);

            length = items.Length;
            this.items = items;
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
            var items = new[]
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
            Debug.Assert(items.Length == 13);

            length = items.Length;
            this.items = items;
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
            var items = new[]
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
            Debug.Assert(items.Length == 14);

            length = items.Length;
            this.items = items;
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
            var items = new[]
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
            Debug.Assert(items.Length == 15);

            length = items.Length;
            this.items = items;
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
            var items = new[]
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
            Debug.Assert(items.Length == 16);

            length = items.Length;
            this.items = items;
        }
    }
}
