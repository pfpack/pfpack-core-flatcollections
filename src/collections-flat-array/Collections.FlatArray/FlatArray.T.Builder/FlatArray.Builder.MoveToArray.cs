namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        public FlatArray<T> MoveToArray()
        {
            if (span.IsEmpty)
            {
                return default;
            }

            var items = this.items!;

            // Clear the builder before moving the items to the result array
            this = default;

            return new(span.Length, items);
        }
    }
}
