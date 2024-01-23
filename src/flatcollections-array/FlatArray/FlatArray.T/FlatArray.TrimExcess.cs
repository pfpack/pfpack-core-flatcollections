namespace System;

partial struct FlatArray<T>
{
    public FlatArray<T> TrimExcess()
    {
        if (items is null || length == default)
        {
            return default;
        }

        if (length == items.Length)
        {
            return this;
        }

        return new(InnerArrayHelper.Copy(items, length), default);
    }
}
