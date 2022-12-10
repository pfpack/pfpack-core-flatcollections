using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        // TODO: Make public when dynamic builder is implemented
        internal void TrimExcess()
            =>
            InnerTrimExcess();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void InnerTrimExcess()
        {
            Debug.Assert(InnerIsValidState());

            var copy = this;

            if (copy.items is null)
            {
                return;
            }

            if (copy.length == default)
            {
                this = default;
                return;
            }

            if (copy.length == copy.items.Length)
            {
                return;
            }

            InnerArrayHelper.TruncateUnchecked(ref copy.items, copy.length);
            this = copy;
        }
    }
}
