using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        public static Builder Create(int length)
            =>
            InternalCreate(length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Builder InternalCreate(
            int length,
            [CallerArgumentExpression("length")] string paramName = "")
        {
            if (length is not >= 0)
            {
                throw InnerExceptionFactory.LengthOutOfRange(paramName, length);
            }

            return length == default ? default : new(new T[length], default);
        }
    }
}
