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
            var items = new[] { item };
            Debug.Assert(items.Length == 1);

            span = new(items);
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

            span = new(items);
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

            span = new(items);
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

            span = new(items);
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

            span = new(items);
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

            span = new(items);
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

            span = new(items);
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

            span = new(items);
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

            span = new(items);
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

            span = new(items);
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

            span = new(items);
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

            span = new(items);
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

            span = new(items);
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

            span = new(items);
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

            span = new(items);
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

            span = new(items);
            this.items = items;
        }
    }
}
