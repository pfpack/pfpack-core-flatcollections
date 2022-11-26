using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        public static Builder OfLength(int length)
            =>
            InternalOfLength(length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Builder InternalOfLength(
            int length,
            [CallerArgumentExpression(nameof(length))] string paramName = "")
        {
            if (length is not >= 0)
            {
                throw InnerExceptionFactory.LengthOutOfRange(paramName, length);
            }

            return length == default ? default : new(new T[length], default);
        }
    }
}
