using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        public ref T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (index >= 0 && index < length)
                {
                    return ref items![index];
                }

                throw InnerExceptionFactory.IndexOutOfRange(index, length: length);
            }
        }
    }
}
