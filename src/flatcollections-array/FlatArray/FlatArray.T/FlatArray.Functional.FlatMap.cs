using System.Collections.Generic;

namespace System;

partial struct FlatArray<T>
{
    public FlatArray<TResult> FlatMap<TResult>(Func<T, FlatArray<TResult>> map)
    {
        _ = map ?? throw new ArgumentNullException(nameof(map));

        if (length == default)
        {
            return default;
        }

        var resultList = new List<TResult>();

        for (int i = 0; i < length; i++)
        {
            var resultArray = map.Invoke(items![i]);

            if (resultArray.IsEmpty)
            {
                continue;
            }

            for (var j = 0; j < resultArray.length; j++)
            {
                resultList.Add(resultArray.items![j]);
            }
        }

        return FlatArray<TResult>.InnerFactory.FromList(resultList);
    }

    public FlatArray<TResult> FlatMap<TResult>(Func<T, int, FlatArray<TResult>> map)
    {
        _ = map ?? throw new ArgumentNullException(nameof(map));

        if (length == default)
        {
            return default;
        }

        var resultList = new List<TResult>();

        for (int i = 0; i < length; i++)
        {
            var resultArray = map.Invoke(items![i], i);

            if (resultArray.IsEmpty)
            {
                continue;
            }

            for (var j = 0; j < resultArray.length; j++)
            {
                resultList.Add(resultArray.items![j]);
            }
        }

        return FlatArray<TResult>.InnerFactory.FromList(resultList);
    }
}