namespace System;

partial struct FlatArray<T>
{
    // TODO: Add the tests and make public
    internal FlatArray<TResult>? TryCastArray<TResult>()
    {
        // Safe array cast: 'as' cast

        if (InnerItems() is not TResult[] resultItems)
        {
            return null;
        }

        var resultItemsNormalized = items is null ? null : resultItems;

        return new(length, resultItemsNormalized, default);
    }
}
