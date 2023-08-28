namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        public FlatArray<T> MoveToFlatArray()
        {
            var length = this.length;
            var items = this.items;

            this.length = default;
            this.items = InnerEmptyArray.Value;

            if (length == default)
            {
                return default;
            }

            if (InnerAllocHelper.IsHugeCapacity(length, items.Length))
            {
                Array.Resize(ref items, length);
            }

            return new(length, items);
        }
    }
}
