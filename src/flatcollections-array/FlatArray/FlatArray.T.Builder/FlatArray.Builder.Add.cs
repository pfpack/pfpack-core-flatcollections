namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        // TODO: Add the tests and make public
        internal Builder Add(T item)
        {
            if (items.Length == length)
            {
                InnerBufferHelper.EnlargeBuffer(ref items);
            }

            items[length++ - 1] = item;
            return this;
        }
    }
}
