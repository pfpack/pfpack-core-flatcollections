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

        var counter = 0;
        do
        {
            var resultArray = map.Invoke(items![counter]);

            if (resultArray.length == default)
            {
                continue;
            }

            resultList.AddRange(new ArraySegment<TResult>(resultArray.items!, 0, resultArray.length));
        }
        while (++counter < length);

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

        var counter = 0;
        do
        {
            var resultArray = map.Invoke(items![counter], counter);

            if (resultArray.length == default)
            {
                continue;
            }

            resultList.AddRange(new ArraySegment<TResult>(resultArray.items!, 0, resultArray.length));
        }
        while (++counter < length);

        return FlatArray<TResult>.InnerFactory.FromList(resultList);
    }
}