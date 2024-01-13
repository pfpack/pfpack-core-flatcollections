namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        // TODO: Add the tests and make public
        internal Builder AddRange(ReadOnlySpan<T> items)
        {
            if (items.IsEmpty)
            {
                return this;
            }

            InnerBuilderBufferHelper.EnsureBufferCapacity(ref this.items, length, items.Length);
            items.CopyTo(new Span<T>(this.items, length, items.Length));
            length += items.Length;

            return this;
        }
    }
}
