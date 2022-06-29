namespace System.Collections.Generic;

partial class FlatArray<T>
{
    private static FlatArray<T> InnerFromIReadOnlyList(IReadOnlyList<T> source)
    {
        var count = source.Count;
        if (count is not > 0)
        {
            return InnerEmptyFlatArray.Value;
        }

        int actualCount = 0;
        var array = new T[count];

        do
        {
            if (actualCount < array.Length)
            {
                array[actualCount] = source[actualCount];
            }
            else
            {
                var newArray = new T[count];
                Array.Copy(array, newArray, array.Length);
                array = newArray;

                array[actualCount] = source[actualCount];
            }
        }
        while (++actualCount < (count = source.Count));

        if (actualCount < array.Length)
        {
            var newArray = new T[actualCount];
            Array.Copy(array, newArray, newArray.Length);
            array = newArray;
        }

        return new(array, default);
    }
}
