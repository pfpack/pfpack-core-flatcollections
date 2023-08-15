namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        // TODO: Add the tests and make public
        internal void TrimExcess()
        {
            // Copy the state to reduce the chance of multithreading side effects

            var length = this.length;
            var items = this.items;

            if (items.Length == length)
            {
                return;
            }

            Array.Resize(ref items, length);
            this.items = items;
        }
    }
}
