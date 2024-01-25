using System.Diagnostics;

namespace System;

partial struct FlatArray<T>
{
    public FlatArray<T> Take(int count)
    {
        if (length == default || count <= 0)
        {
            return default;
        }

        if (count >= length)
        {
            return this;
        }

        return new(count, items!);
    }

    // TODO: Add the tests and make public
    internal FlatArray<T> Take(Range range)
    {
        if (length == default)
        {
            return default;
        }

        var start = range.Start.GetOffset(length);
        var end = range.End.GetOffset(length); // the exclusive end index

        if (start >= end)
        {
            return default;
        }

        if (start >= length || end <= 0)
        {
            return default;
        }

        if (start < 0)
        {
            start = 0;
        }

        if (end > length)
        {
            end = length;
        }

        var count = end - start;

        Debug.Assert(count > 0);

        if (start == default)
        {
            return count == length ? this : new(count, items!);
        }

        return new(InnerArrayHelper.CopySegment(items!, start, count), default);
    }
}
