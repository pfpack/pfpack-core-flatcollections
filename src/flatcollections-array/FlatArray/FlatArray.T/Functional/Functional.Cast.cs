namespace System;

partial struct FlatArray<T>
{
    // TODO: Add the tests and make public
    internal FlatArray<TResult> Cast<TResult>()
    {
        if (length == default)
        {
            return default;
        }

        if (items is TResult[] resultItems)
        {
            return new(length, resultItems);
        }

        resultItems = new TResult[length];

        var counter = 0;
        do
        {
            resultItems[counter] = (TResult)(object)items![counter]!;
        }
        while (++counter < resultItems.Length);

        return new(resultItems, default);
    }
}
