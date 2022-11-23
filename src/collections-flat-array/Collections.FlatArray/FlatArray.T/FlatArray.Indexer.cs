namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    public ref readonly T this[int index]
    {
        get
        {
            if (InnerIsNotEmpty)
            {
                if (index >= 0 && index < items.Length)
                {
                    return ref items[index];
                }
            }

            throw InnerExceptionFactory.IndexOutOfRange(nameof(index), index);
        }
    }
}
