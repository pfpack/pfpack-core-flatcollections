namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        public ref T this[int index]
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
}
