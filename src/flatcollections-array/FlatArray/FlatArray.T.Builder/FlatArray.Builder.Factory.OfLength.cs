using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        public static Builder OfLength(int length)
            =>
            InternalOfLengthChecked(length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Builder InternalOfLengthChecked(
            int length, [CallerArgumentExpression(nameof(length))] string paramName = "")
        {
            if (length < 0)
            {
                throw InnerBuilderExceptionFactory.LengthOutOfRange(paramName, length);
            }

            return new(length: length, default);
        }
    }
}
