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
                if (index >= 0 && index < length)
                {
                    return items[index];
                }

                throw InnerExceptionFactory.IndexOutOfRange(index, length: length);
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (index >= 0 && index < length)
                {
                    items[index] = value;
                }

                throw InnerExceptionFactory.IndexOutOfRange(index, length: length);
            }
        }

        // ItemRef is implemented readonly to prevent modification of FlatArray instances
        // initialized by calling 'MoveTo' on the Builder
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref readonly T ItemRef(int index)
        {
            if (index >= 0 && index < length)
            {
                return ref items[index];
            }

            throw InnerExceptionFactory.IndexOutOfRange(index, length: length);
        }
    }
}
