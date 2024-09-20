namespace System;

partial struct FlatArray<T>
{
    public FlatArray<FlatArray<T>> Chunk(int size)
    {
        if (size < 1)
        {
            throw InnerExceptionFactory.ChunkSizeOutsideBounds(nameof(size), size);
        }

        if (length == default)
        {
            return default;
        }

        var chunks = length % size == default ? new FlatArray<T>[length / size] : new FlatArray<T>[length / size + 1];
        var start = 0;

        for (var i = 0; i < chunks.Length; i++)
        {
            var effectiveSize = length - start;
            if (effectiveSize > size)
            {
                effectiveSize = size;
            }

            var chunkItems = InnerArrayHelper.CopySegment(items!, start, effectiveSize);
            chunks[i] = new(chunkItems, default);

            start += effectiveSize;
        }

        return new(chunks, default);
    }
}