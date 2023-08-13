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

        InternalForEach(
            item =>
            {
                var resultArray = map.Invoke(item);

                if (resultArray.length == default)
                {
                    return;
                }

                resultList.AddRange(new ArraySegment<TResult>(resultArray.items!, 0, resultArray.length));
            });

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

        InternalForEach(
            (i, item) =>
            {
                var resultArray = map.Invoke(item, i);

                if (resultArray.length == default)
                {
                    return;
                }

                resultList.AddRange(new ArraySegment<TResult>(resultArray.items!, 0, resultArray.length));
            });

        return FlatArray<TResult>.InnerFactory.FromList(resultList);
    }
}