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

            var copy = this;
            this = default;
            return new(copy.length, copy.items);
        }
    }
}
