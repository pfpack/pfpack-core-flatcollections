namespace System;

partial struct FlatArray<T>
{
    public FlatArray<TResult> CastArray<TResult>()
    {
        // Unsafe array cast: InvalidCastException is expected
        var resultItems = (TResult[])(object)InnerItems;

        return length == default ? default : new(length, resultItems);
    }
}
