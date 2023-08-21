namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        // TODO: Add the tests and make public
        internal Builder Add(T item)
        {
            if (length == items.Length)
            {
                InnerBufferHelper.EnlargeBuffer(ref items);
            }

            items[length++] = item;
            return this;
        }
    }
}
