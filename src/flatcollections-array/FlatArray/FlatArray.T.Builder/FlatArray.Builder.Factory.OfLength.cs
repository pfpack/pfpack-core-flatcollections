using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        public static Builder OfLength(int length)
            =>
            InternalOfLength(length, nameof(length));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Builder InternalOfLength(int length, string paramName)
        {
            if (length is not >= 0)
            {
                throw InnerExceptionFactory.LengthOutOfRange(nameof(length), length);
            }

            return new(length, capacity: length);
        }
    }
}
