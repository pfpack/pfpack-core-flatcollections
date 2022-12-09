namespace System;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        public FlatArray<T> MoveToArray()
        {
            if (InnerIsEmpty)
            {
                return default;
            }

            var length = this.length;
            var items = this.items;

            // Clear the builder before moving the items to the result array
            this = default;

            return new(length, items);
        }
    }
}
