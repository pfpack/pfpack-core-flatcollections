namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    public ref readonly T this[int index]
    {
        get
        {
            if (InnerIsEmpty)
            {
                throw InnerExceptionFactory.IndexOutOfRange(nameof(index), index);
            }

            if (index >= 0 && index < items.Length)
            {
                return ref items[index];
            }

            throw InnerExceptionFactory.IndexOutOfRange(nameof(index), index);
        }
    }
}
