using System.Collections.Generic;

namespace System;

partial struct FlatArray<T>
{
    public FlatArray<TResult> FlatMap<TResult>(Func<T, FlatArray<TResult>> map)
    {
        ArgumentNullException.ThrowIfNull(map);

        if (IsEmpty)
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

        if (resultList.Count is 0)
        {
            return default;
        }

        return new(resultList.ToArray(), default);
    }

    public FlatArray<TResult> FlatMap<TResult>(Func<T, int, FlatArray<TResult>> map)
    {
        ArgumentNullException.ThrowIfNull(map);

        if (IsEmpty)
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

        if (resultList.Count is 0)
        {
            return default;
        }

        return new(resultList.ToArray(), default);
    }
}