using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Builder()
        {
            items = InnerEmptyArray.Value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Builder([AllowNull] params T[] source)
        {
            if (source is null || source.Length == default)
            {
                items = InnerEmptyArray.Value;
                return;
            }

            length = source.Length;
            items = InnerArrayHelper.Copy(source);
        }
    }
}
