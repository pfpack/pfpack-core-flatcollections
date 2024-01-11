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

        return new(length, items is null ? null : resultItems, default);
    }
}
