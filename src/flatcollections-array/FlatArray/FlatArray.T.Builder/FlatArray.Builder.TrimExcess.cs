using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        // TODO: Make public when dynamic builder is implemented
        internal void TrimExcess()
            =>
            InnerTrimExcess();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void InnerTrimExcess()
        {
            // Copy the state to reduce the chance of multithreading side effects

            var length = this.length;
            var items = this.items;

            if (length == items.Length)
            {
                return;
            }

            InnerArrayHelper.TruncateUnchecked(ref items, length);
            this.items = items;
        }
    }
}
