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
}