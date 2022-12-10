using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            if (index >= 0 && index < length)
            {
                return items![index];
            }

            throw InnerExceptionFactory.IndexOutOfRange(index, length: length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ref readonly T ItemRef(int index)
    {
        if (index >= 0 && index < length)
        {
            return ref items![index];
        }

        throw InnerExceptionFactory.IndexOutOfRange(index, length: length);
    }
}
