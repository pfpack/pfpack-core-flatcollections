namespace System;

partial struct FlatArray<T>
{
    public FlatArray<FlatArray<T>> Chunk(int size)
    {
        if (size < 1)
        {
            throw InnerExceptionFactory.SizeOutsideBounds(nameof(size), size);
        }

        if (length == default)
        {
            return default;
        }

        var chunksLength = length / size;
        if (length % size != default)
        {
            chunksLength++;
        }

        var chunks = new FlatArray<T>[chunksLength];
        for (var i = 0; i < chunks.Length; i++)
        {
            var start = i * size;

            var chunkLength = length - start;
            if (chunkLength > size)
            {
                chunkLength = size;
            }

            var chunkItems = InnerArrayHelper.CopySegment(items!, start, chunkLength);
            chunks[i] = new(chunkLength, chunkItems);
        }

        return chunks;
    }
}