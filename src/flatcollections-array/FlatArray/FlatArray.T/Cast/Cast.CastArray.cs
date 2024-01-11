namespace System;

partial struct FlatArray<T>
{
    // TODO: Add the tests and make public
    public FlatArray<TResult> CastArray<TResult>()
    {
        // Unsafe array cast: InvalidCastException is expected
        var resultItems = (TResult[])(object)InnerItems();

        return new(length, items is null ? null : resultItems, default);
    }
}
