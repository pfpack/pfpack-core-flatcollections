namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        // TODO: Add the tests and make public
        internal void TrimExcess()
        {
            if (length == items.Length)
            {
                return;
            }

            Array.Resize(ref items, length);
        }
    }
}
