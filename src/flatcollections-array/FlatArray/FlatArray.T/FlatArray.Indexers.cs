using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            if (InnerAllocHelper.IsIndexInRange(index, length))
            {
                return items![index];
            }

            throw InnerExceptionFactory.IndexOutOfRange(index, length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ref readonly T ItemRef(int index)
    {
        if (InnerAllocHelper.IsIndexInRange(index, length))
        {
            return ref items![index];
        }

        throw InnerExceptionFactory.IndexOutOfRange(index, length);
    }

    // TODO: Add the tests and make public
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal ref readonly T ItemRef(Index index)
        =>
        ref ItemRef(index.GetOffset(length));
}
