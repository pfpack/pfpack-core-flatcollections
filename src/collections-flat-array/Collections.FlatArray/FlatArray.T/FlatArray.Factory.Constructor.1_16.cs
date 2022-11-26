using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public FlatArray(T item)
    {
        length = 1;
        items = new[] { item };

        Debug.Assert(length == 1);
        Debug.Assert(items.Length == 1);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public FlatArray(
        T item0,
        T item1)
    {
        length = 2;
        items = new[]
        {
            item0,
            item1
        };

        Debug.Assert(length == 2);
        Debug.Assert(items.Length == 2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public FlatArray(
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

        Debug.Assert(length == 3);
        Debug.Assert(items.Length == 3);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public FlatArray(
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

        Debug.Assert(length == 4);
        Debug.Assert(items.Length == 4);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public FlatArray(
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

        Debug.Assert(length == 5);
        Debug.Assert(items.Length == 5);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public FlatArray(
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

        Debug.Assert(length == 6);
        Debug.Assert(items.Length == 6);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public FlatArray(
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

        Debug.Assert(length == 7);
        Debug.Assert(items.Length == 7);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public FlatArray(
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

        Debug.Assert(length == 8);
        Debug.Assert(items.Length == 8);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public FlatArray(
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

        Debug.Assert(length == 9);
        Debug.Assert(items.Length == 9);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public FlatArray(
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

        Debug.Assert(length == 10);
        Debug.Assert(items.Length == 10);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public FlatArray(
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

        Debug.Assert(length == 11);
        Debug.Assert(items.Length == 11);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public FlatArray(
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

        Debug.Assert(length == 12);
        Debug.Assert(items.Length == 12);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public FlatArray(
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

        Debug.Assert(length == 13);
        Debug.Assert(items.Length == 13);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public FlatArray(
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

        Debug.Assert(length == 14);
        Debug.Assert(items.Length == 14);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public FlatArray(
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

        Debug.Assert(length == 15);
        Debug.Assert(items.Length == 15);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public FlatArray(
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

        Debug.Assert(length == 16);
        Debug.Assert(items.Length == 16);
    }
}
