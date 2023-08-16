using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        public static Builder OfLength(int length)
            =>
            InternalOfLengthChecked(length, nameof(length));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Builder InternalOfLengthChecked(int length, string paramName)
        {
            if (length is not >= 0)
            {
                throw InnerBuilderExceptionFactory.LengthOutOfRange(paramName, length);
            }

            return new(length: length, default);
        }
    }
}
