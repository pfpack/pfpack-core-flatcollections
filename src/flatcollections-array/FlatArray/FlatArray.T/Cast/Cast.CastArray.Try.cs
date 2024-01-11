namespace System;

partial struct FlatArray<T>
{
    public FlatArray<TResult>? TryCastArray<TResult>()
    {
        // Safe array cast: 'as' cast

        if (InnerItems() is not TResult[] resultItems)
        {
            return null;
        }

        return new(length, items is null ? null : resultItems, default);
    }
}
