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
            this = default;
            return new(items, default);
        }
    }
}
