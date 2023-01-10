using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        public T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (InnerAllocHelper.IsIndexInRange(index, length))
                {
                    return items[index];
                }

                throw InnerExceptionFactory.IndexOutOfRange(index, length);
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (InnerAllocHelper.IsIndexInRange(index, length))
                {
                    items[index] = value;
                    return;
                }

                throw InnerExceptionFactory.IndexOutOfRange(index, length);
            }
        }

        // ItemRef is implemented readonly to prevent modification of FlatArray instances
        // initialized by calling 'MoveTo' on the Builder
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref readonly T ItemRef(int index)
        {
            if (InnerAllocHelper.IsIndexInRange(index, length))
            {
                return ref items[index];
            }

            throw InnerExceptionFactory.IndexOutOfRange(index, length);
        }
    }
}
