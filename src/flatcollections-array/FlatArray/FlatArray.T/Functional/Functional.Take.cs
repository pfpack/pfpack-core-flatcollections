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

        var (start, end) = (range.Start.GetOffset(length), range.End.GetOffset(length)) switch
        {
            var (startUnsorted, endUnsorted) => startUnsorted <= endUnsorted
            ? (startUnsorted, endUnsorted)
            : (endUnsorted, startUnsorted)
        };

        var effectiveStart = start >= 0 ? start : 0;
        var effectiveEnd = end < length ? end : length - 1;
        var effectiveLength = effectiveEnd - effectiveStart + 1;

        return effectiveStart == default
            ? new(effectiveLength, items!)
            : new(InnerArrayHelper.CopySegment(items!, effectiveStart, effectiveLength), default);
    }
}