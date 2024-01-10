using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Builder(T item0)
        {
            length = 1;
#pragma warning disable IDE0300 // Simplify collection initialization
            items = new[] { item0 };
#pragma warning restore IDE0300 // Simplify collection initialization

            Debug.Assert(length == 1);
            Debug.Assert(items.Length == 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Builder(
            T item0,
            T item1)
        {
            length = 2;
#pragma warning disable IDE0300 // Simplify collection initialization
            items = new[]
            {
                item0,
                item1
            };
#pragma warning restore IDE0300 // Simplify collection initialization

            Debug.Assert(length == 2);
            Debug.Assert(items.Length == 2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Builder(
            T item0,
            T item1,
            T item2)
        {
            length = 3;
#pragma warning disable IDE0300 // Simplify collection initialization
            items = new[]
            {
                item0,
                item1,
                item2
            };
#pragma warning restore IDE0300 // Simplify collection initialization

            Debug.Assert(length == 3);
            Debug.Assert(items.Length == 3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Builder(
            T item0,
            T item1,
            T item2,
            T item3)
        {
            length = 4;
#pragma warning disable IDE0300 // Simplify collection initialization
            items = new[]
            {
                item0,
                item1,
                item2,
                item3
            };
#pragma warning restore IDE0300 // Simplify collection initialization

            Debug.Assert(length == 4);
            Debug.Assert(items.Length == 4);
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
#pragma warning disable IDE0300 // Simplify collection initialization
            items = new[]
            {
                item0,
                item1,
                item2,
                item3,
                item4
            };
#pragma warning restore IDE0300 // Simplify collection initialization

            Debug.Assert(length == 5);
            Debug.Assert(items.Length == 5);
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
#pragma warning disable IDE0300 // Simplify collection initialization
            items = new[]
            {
                item0,
                item1,
                item2,
                item3,
                item4,
                item5
            };
#pragma warning restore IDE0300 // Simplify collection initialization

            Debug.Assert(length == 6);
            Debug.Assert(items.Length == 6);
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
#pragma warning disable IDE0300 // Simplify collection initialization
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
#pragma warning restore IDE0300 // Simplify collection initialization

            Debug.Assert(length == 7);
            Debug.Assert(items.Length == 7);
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
#pragma warning disable IDE0300 // Simplify collection initialization
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
#pragma warning restore IDE0300 // Simplify collection initialization

            Debug.Assert(length == 8);
            Debug.Assert(items.Length == 8);
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
#pragma warning disable IDE0300 // Simplify collection initialization
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
#pragma warning restore IDE0300 // Simplify collection initialization

            Debug.Assert(length == 9);
            Debug.Assert(items.Length == 9);
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
#pragma warning disable IDE0300 // Simplify collection initialization
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
#pragma warning restore IDE0300 // Simplify collection initialization

            Debug.Assert(length == 10);
            Debug.Assert(items.Length == 10);
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
#pragma warning disable IDE0300 // Simplify collection initialization
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
#pragma warning restore IDE0300 // Simplify collection initialization

            Debug.Assert(length == 11);
            Debug.Assert(items.Length == 11);
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
#pragma warning disable IDE0300 // Simplify collection initialization
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
#pragma warning restore IDE0300 // Simplify collection initialization

            Debug.Assert(length == 12);
            Debug.Assert(items.Length == 12);
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
#pragma warning disable IDE0300 // Simplify collection initialization
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
#pragma warning restore IDE0300 // Simplify collection initialization

            Debug.Assert(length == 13);
            Debug.Assert(items.Length == 13);
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
#pragma warning disable IDE0300 // Simplify collection initialization
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
#pragma warning restore IDE0300 // Simplify collection initialization

            Debug.Assert(length == 14);
            Debug.Assert(items.Length == 14);
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
#pragma warning disable IDE0300 // Simplify collection initialization
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
#pragma warning restore IDE0300 // Simplify collection initialization

            Debug.Assert(length == 15);
            Debug.Assert(items.Length == 15);
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
#pragma warning disable IDE0300 // Simplify collection initialization
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
#pragma warning restore IDE0300 // Simplify collection initialization

            Debug.Assert(length == 16);
            Debug.Assert(items.Length == 16);
        }
    }
}
