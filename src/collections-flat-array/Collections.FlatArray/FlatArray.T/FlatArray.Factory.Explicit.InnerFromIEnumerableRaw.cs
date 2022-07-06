namespace System.Collections.Generic;

partial class FlatArray<T>
{
    private static FlatArray<T> InnerFromIEnumerableRaw(IEnumerable<T> source, int estimatedCapacity = default)
    {
        using var enumerator = source.GetEnumerator();

        if (enumerator.MoveNext() is false)
        {
            return InnerEmptyFlatArray.Value;
        }

        int actualCount = 0;

        const int defaultCapacity = 4;
        var array = new T[estimatedCapacity > 0 ? estimatedCapacity : defaultCapacity];

        int maxCapacity = Math.Max(Array.MaxLength, array.Length);

        do
        {
            if (actualCount < array.Length)
            {
                array[actualCount++] = enumerator.Current;
            }
            else if (actualCount < maxCapacity)
            {
                int newCapacity = unchecked(array.Length * 2);
                if (unchecked((uint)newCapacity) > (uint)maxCapacity)
                {
                    newCapacity = maxCapacity;
                }

                var newArray = new T[newCapacity];
                Array.Copy(array, newArray, array.Length);
                array = newArray;

                array[actualCount++] = enumerator.Current;
            }
            else
            {
                throw new OutOfMemoryException("The input collection is too large to allocate.");
            }
        }
        while (enumerator.MoveNext());

        if (actualCount < array.Length)
        {
            var newArray = new T[actualCount];
            Array.Copy(array, newArray, newArray.Length);
            array = newArray;
        }

        return new(array, default);
    }
}
