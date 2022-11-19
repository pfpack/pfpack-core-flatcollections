namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        public static Builder Create(int length)
        {
            if (length is not >= 0)
            {
                throw InnerExceptionFactory.LengthOutOfRange(nameof(length), length);
            }

            return length == default ? default : new(new T[length], default);
        }
    }
}
