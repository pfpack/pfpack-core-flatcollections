namespace System;

partial struct FlatArray<T>
{
    // TODO: Add the tests and make public
    internal FlatArray<TResult> CastArray<TResult>()
    {
        // Unsafe array cast: InvalidCastException is expected

        var resultItems = (TResult[])(object)InnerItems();

        var resultItemsNormalized = items is null ? null : resultItems;

        return new(length, resultItemsNormalized, default);
    }
}
