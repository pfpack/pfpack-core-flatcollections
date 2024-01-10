namespace System;

partial struct FlatArray<T>
{
    public FlatArray<T> Skip(int count)
    {
        if (length == default || count >= length)
        {
            return default;
        }

        if (count <= 0)
        {
            return this;
        }

        return new(InnerArrayHelper.CopySegment(items!, count, length - count), default);
    }
}