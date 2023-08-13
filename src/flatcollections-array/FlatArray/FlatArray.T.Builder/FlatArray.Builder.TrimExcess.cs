namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        // TODO: Make public when dynamic builder is implemented
        internal void TrimExcess()
        {
            // Copy the state to reduce the chance of multithreading side effects

            var length = this.length;
            var items = this.items;

            if (items.Length == length)
            {
                return;
            }

            InnerArrayHelper.TruncateUnchecked(ref items, length);
            this.items = items;
        }
    }
}
