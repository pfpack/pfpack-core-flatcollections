namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        // TODO: Add the tests and make public
        internal Builder TrimExcess()
        {
            if (length == items.Length)
            {
                return this;
            }

            Array.Resize(ref items, length);
            return this;
        }
    }
}
