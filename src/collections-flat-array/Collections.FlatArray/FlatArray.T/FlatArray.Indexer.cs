namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    public T this[int index]
    {
        get
        {
            if (InnerIsNotEmpty)
            {
                if (index >= 0 && index < items.Length)
                {
                    return items[index];
                }
            }

            throw InnerExceptionFactory.IndexOutOfRange(nameof(index), index);
        }
    }
}
